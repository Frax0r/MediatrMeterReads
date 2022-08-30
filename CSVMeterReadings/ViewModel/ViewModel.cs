namespace CSVMeterReadings.ViewModel
{
    public class ViewModel<TView> where TView : class, new()
    {
        public TView Core;
    }
}