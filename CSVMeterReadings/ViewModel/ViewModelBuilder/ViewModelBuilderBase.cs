using System.Threading.Tasks;

namespace CSVMeterReadings.ViewModel.ViewModelBuilder
{
    internal interface IViewModelBuilder<TViewModel, TInput> where TViewModel : class, new()
    {
        internal void SetInputObject(TInput input);
        internal abstract Task BuildViewModelAsync();
        internal ViewModel<TViewModel> ViewModel();
    }

    internal abstract class ViewModelBuilderBase<TViewModel, TInput> : IViewModelBuilder<TViewModel, TInput> where TViewModel : class, new()
    {
        protected ViewModel<TViewModel> _ViewModel;

        protected TInput _InputObject;

        public void SetInputObject(TInput input) => _InputObject = input;

        public abstract Task BuildViewModelAsync();

        public virtual ViewModel<TViewModel> ViewModel() => _ViewModel;

    }

}
