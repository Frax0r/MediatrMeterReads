namespace CSVMeterReadingsAPI.ViewModel
{
    public class ViewModel<TViewModel> where TViewModel : class, new()
    {
        public TViewModel Model;
    }
}