using System.Threading.Tasks;

namespace CSVMeterReadings.ViewModel.ViewModelBuilder
{
    public abstract class ViewModelBuilder<TView, TInput> where TView : class, new()
    {
        protected ViewModel<TView> _ViewModel;

        protected TInput _InputObject;

        public void SetInputObject(TInput input) => _InputObject = input;

        public abstract Task BuildViewModel();

        public virtual ViewModel<TView> GetViewModel() => _ViewModel;

    }
}
