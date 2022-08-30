using System.Threading.Tasks;
using CSVMeterReadings.ViewModel;
using CSVMeterReadings.ViewModel.ViewModelBuilder;

namespace CSVMeterReadings.Presenter
{
    public class Presenter
    {
        internal async Task<ViewModel<TView>> GetViewModel<TView, TInput>(ViewModelBuilder<TView, TInput> vmBuilder, TInput inputObject) where TView : class, new()
        {

            vmBuilder.SetInputObject(inputObject);

            await vmBuilder.BuildViewModel();

            return vmBuilder.GetViewModel();

        }

    }
}

