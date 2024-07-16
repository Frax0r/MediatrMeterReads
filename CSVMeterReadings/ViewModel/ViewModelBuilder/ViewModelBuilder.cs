using System.Threading.Tasks;

namespace CSVMeterReadings.ViewModel.ViewModelBuilder
{
    internal abstract class ViewModelBuilder<TViewModel, TInput> : IViewModelBuilder<TViewModel, TInput> where TViewModel : class, new()
    {
        protected ViewModel<TViewModel> _ViewModel;

        protected TInput _InputObject;

        public void SetInputObject(TInput input) => _InputObject = input;

        public abstract Task BuildViewModel();

        public virtual ViewModel<TViewModel> ViewModel() => _ViewModel;

    }

    internal interface IViewModelBuilder<TViewModel, TInput> where TViewModel : class, new()
    {
        internal void SetInputObject(TInput input);

        internal abstract Task BuildViewModel();

        internal ViewModel<TViewModel> ViewModel();

    }
}
