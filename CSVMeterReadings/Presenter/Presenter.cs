using System.Threading.Tasks;
using CSVMeterReadingsAPI.ViewModel;
using CSVMeterReadingsAPI.ViewModel.ViewModelBuilder;

namespace CSVMeterReadingsAPI.Presenter
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

