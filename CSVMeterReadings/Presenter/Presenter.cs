using System.Threading.Tasks;
using CSVMeterReadings.ViewModel;
using CSVMeterReadings.ViewModel.ViewModelBuilder;

namespace CSVMeterReadings.Presenter
{
    internal class Presenter<TViewModel, TInput> : IPresenter<TViewModel, TInput> where TViewModel : class, new()
    {
        private readonly IViewModelBuilder<TViewModel, TInput> _vmBuilder;

        public Presenter(IViewModelBuilder<TViewModel, TInput> vmBuilder)
        {
            _vmBuilder = vmBuilder;
        }

        public async Task<ViewModel<TViewModel>> GetViewModel(TInput inputObject)
        {
            _vmBuilder.SetInputObject(inputObject);

            await _vmBuilder.BuildViewModel();

            return _vmBuilder.ViewModel();

        }

    }

    public interface IPresenter<TViewModel, TInput> where TViewModel : class, new()
    {
        internal Task<ViewModel<TViewModel>> GetViewModel(TInput inputObject);

    }
}

