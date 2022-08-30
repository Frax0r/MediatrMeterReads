using System.Threading.Tasks;

namespace CSVMeterReadings.ViewModel.ViewModelBuilder
{
    internal abstract class ViewModelBuilder<TView, TInput> where TView : class, new()
    {
        protected ViewModel<TView> _ViewModel;

        protected TInput _InputObject;

        internal void SetInputObject(TInput input) => _InputObject = input;

        internal abstract Task BuildViewModel();

        internal virtual ViewModel<TView> GetViewModel() => _ViewModel;

    }
}
