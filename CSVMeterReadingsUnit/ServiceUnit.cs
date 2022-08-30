using Autofac.Extras.Moq;
using CSVMeterReadings.Models;
using CSVMeterReadings.Service;
using CSVMeterReadingsService.ValidationRules;
using CSVMeterReadingsUnit.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace CSVMeterReadingsUnit
{
    [TestClass]
    public class ServiceUnit
    {
        Mock<IRepository<Account>> _accountRepo;
        Mock<IRepository<MeterReading>> _readingRepo;
        AutoMock _mock;
        CSVUploadService _CSVUploadService;
        List<MeterReading> _existingReadings;
        List<Account> _existingAccounts;
        CSVUploadFile _csvUploadFile;
        CSVUploadFile _csvUploadFile2;
        FileInfo _readings2;
        FileInfo _readings3;

        [TestInitialize]
        public void SetUp()
        {
            _mock = AutoMock.GetLoose();

            /* Unit tests should be able to be run in any order, in isolation, be idempotent and determined,
             * instead of adding new things to our existing collections for each test we will create new unchanging collections specifically for each testmethod */

            _existingReadings = InitialiseMeterReadingsList();
                     
            _existingAccounts = InitialiseAccountList();
                   

            /* Here we will mock our repository methods, we can see that this is mocking correctly, 
             * we know this as the code under test is using the lists we have provided here privately just for test purposes, putting breakpoints in the "real" application
             * repository methods are never hit, which is correct.
             * this means it is behaving as expected and in a real world situation these mocked test repos would not hitting our database for either 'accounts' or 'meter readings' as is required 
             * we are mocking the GetByID and Find Methods of _accountRepo and  _readingRepo, both using our private lists
             * to return pre-determined immutable data */
        
            _accountRepo = _mock.Mock<IRepository<Account>>();
            _accountRepo.Setup(i => i.GetAll()).Returns(_existingAccounts);
            _accountRepo.Setup(i => i.GetByID(It.IsAny<uint>())).Returns<uint>(id => { return _existingAccounts.Where(i => id == i.AccountId).FirstOrDefault(); });
            _accountRepo.Setup(i => i.Insert(It.IsAny<Account>())).Returns(true);
           // _accountRepo.Setup(i => i.InsertList(It.IsAny<IEnumerable<Account>>())).Returns(true);
            _accountRepo.Setup(i => i.SaveChanges());

       
            _readingRepo = _mock.Mock<IRepository<MeterReading>>();
            _readingRepo.Setup(i => i.GetAll()).Returns(_existingReadings);
            _readingRepo.Setup(i => i.Find(It.IsAny<object[]>())).Returns<object[]>(keys => { return _existingReadings.Where(i => (uint)keys[0] == i.AccountId && (DateTime)keys[1] == i.MeterReadingDateTime ).FirstOrDefault(); });
            _readingRepo.Setup(i => i.Insert(It.IsAny<MeterReading>())).Returns(true);
           // _readingRepo.Setup(i => i.InsertList(It.IsAny<IEnumerable<MeterReading>>())).Returns(true);
            _readingRepo.Setup(i => i.SaveChanges());


            /* Grab test files and convert to IformFile */
            _readings2 = new FileInfo("mockFiles/Meter_Reading2.csv");

            // Use an extension method to mock a IFormFile
            IFormFile formFile = _readings2.AsMockIFormFile();

            using (Stream stream = formFile.OpenReadStream())
            {
                _csvUploadFile = new CSVUploadFile(stream, formFile.FileName);
            }

            // And again
            _readings3 = new FileInfo("mockFiles/Meter_Reading3.txt");
          
            formFile = _readings3.AsMockIFormFile();

            using (Stream stream = formFile.OpenReadStream())
            {
                _csvUploadFile2 = new CSVUploadFile(stream, formFile.FileName);
            }

            //The code under test. The only public facing method for checkoutservice is purchase items. We can consider the unit to be the public transaction
            _CSVUploadService = _mock.Create<CSVUploadService>();

        }

        [TestMethod]
        public void TestCSVUploadFileValidation()
        {

            CSVFileValidFormatRule vfr = new CSVFileValidFormatRule();
            Assert.AreEqual("Does Not Have Required Column Headers", vfr.Validate(_csvUploadFile).Message);
            Assert.AreEqual(false, vfr.Validate(_csvUploadFile).Passed);
        }

        [TestMethod]
        public void TestCSVUpload()
        {

            CSVFileValidTypeRule vfr = new CSVFileValidTypeRule();

            Assert.AreEqual("Valid", vfr.Validate(_csvUploadFile).Message);
            Assert.AreEqual(true, vfr.Validate(_csvUploadFile).Passed);
        }


        [TestMethod]
        public void TestCSVUploadExtensionValidation()
        {            

            CSVFileValidTypeRule vfr = new CSVFileValidTypeRule();

            Assert.AreEqual("Uploaded File Is Not A CSV", vfr.Validate(_csvUploadFile2).Message);
            Assert.AreEqual(false, vfr.Validate(_csvUploadFile2).Passed);
        }


        private static List<MeterReading> InitialiseMeterReadingsList()
        {

            MeterReading A = new MeterReading(1, DateTime.Parse("01 Jan 2020 9:15"), 12345);
            MeterReading B = new MeterReading(2, DateTime.Parse("02 Jan 2020 9:15"), 56789);
            MeterReading C = new MeterReading(3, DateTime.Parse("03 Jan 2020 9:15"), 98765);
            MeterReading D = new MeterReading(4, DateTime.Parse("04 Jan 2020 9:15"), 56677);
            MeterReading E = new MeterReading(5, DateTime.Parse("05 Jan 2020 9:15"), 45678);

            return new List<MeterReading>() { A, B, C, D, E };
        }

        private static List<Account> InitialiseAccountList()
        {

            Account A = new Account(1, "Chris", "Sawyer");
            Account B = new Account(2, "Steve", "Wozniak");
            Account C = new Account(3, "Robert", "Martin");
            Account D = new Account(4, "Josh", "Sawyer");
            Account E = new Account(5, "Zoran", "Horvat");

            return new List<Account>() { A, B, C, D, E };
        }

      
    }
}
