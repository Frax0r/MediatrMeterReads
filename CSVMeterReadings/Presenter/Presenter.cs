using System.Threading.Tasks;
using CSVMeterReadings.ViewModel;
using CSVMeterReadings.ViewModel.ViewModelBuilder;

namespace CSVMeterReadings.Presenter
{
    public interface IPresenter<TViewModel, TInput> where TViewModel : class, new()
    {
        internal Task<ViewModel<TViewModel>> GetViewModelAsync(TInput inputObject);

    }

    internal class Presenter<TViewModel, TInput> : IPresenter<TViewModel, TInput> where TViewModel : class, new()
    {
        private readonly IViewModelBuilder<TViewModel, TInput> _vmBuilder;

        public Presenter(IViewModelBuilder<TViewModel, TInput> vmBuilder)
        {
            _vmBuilder = vmBuilder;
        }

        public async Task<ViewModel<TViewModel>> GetViewModelAsync(TInput inputObject)
        {
            _vmBuilder.SetInputObject(inputObject);

            await _vmBuilder.BuildViewModel();

            return _vmBuilder.ViewModel();

        }

    }

}

