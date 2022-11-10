using ReactiveUI;
using Sharpnado.Tasks;

namespace PocTaskLoader.Core.ViewModels;

public class BaseViewModel : ReactiveObject, INavigatedAware, IInitializeAsync
{
    protected INavigationService NavigationService { get; private set; }

    public BaseViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }


    #region LifeCycle

    public Task InitializeAsync(INavigationParameters parameters)
    {
        return Task.FromResult(0);
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
        TaskMonitor.Create(OnNavigatedToAsync(parameters),
                           whenFaulted: t => {
                               t.Exception.Handle(ex => {
                                   Console.WriteLine($"OnNavigatedTo error : {ex.Message}");
                                   return true;
                               });
                           });
    }

    protected virtual Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        return Task.FromResult(0);
    }


    public void OnNavigatedFrom(INavigationParameters parameters)
    {
        TaskMonitor.Create(OnNavigatedFromAsync(parameters),
                           whenFaulted: t => {
                               t.Exception.Handle(ex => {
                                   Console.WriteLine($"OnNavigatedFrom error : {ex.Message}");
                                   return true;
                               });
                           });
    }
    protected virtual Task OnNavigatedFromAsync(INavigationParameters parameters)
    {
        return Task.FromResult(0);
    }

    #endregion
}
