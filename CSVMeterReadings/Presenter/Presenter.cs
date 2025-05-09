using System.Threading.Tasks;
using CSVMeterReadings.ViewModel;
using CSVMeterReadings.ViewModel.ViewModelBuilder;

namespace CSVMeterReadings.Presenter
{
    public interface IPresenter<TViewModel, TInput> where TViewModel : class, new()
    {
        internal Task<ViewModel<TViewModel>> GetViewModelAsync(TInput inputObject);

    }

    internal class Presenter<TViewModel, TInput>(IViewModelBuilder<TViewModel, TInput> vmBuilder) : IPresenter<TViewModel, TInput> where TViewModel : class, new()
    {
        public async Task<ViewModel<TViewModel>> GetViewModelAsync(TInput inputObject)
        {
            vmBuilder.SetInputObject(inputObject);

            await vmBuilder.BuildViewModelAsync();

            return vmBuilder.ViewModel();

        }

    }

}

