using PocTaskLoader.Core.Services.Interfaces;
using ReactiveUI;
using Sharpnado.TaskLoaderView;
using System.Reactive;

namespace PocTaskLoader.Core.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly IUserService _userService;

    public LoginViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
    {
        _userService = userService;

        LoginCommand = new TaskLoaderCommand(OnLoginCommand);

        Loader = new();

        CompositeNotifier = new(Loader, LoginCommand.Notifier);

    }

    #region Life cycle

    protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await base.OnNavigatedToAsync(parameters);
    }

    #endregion

    #region Properties

    #region Username
    private string _username;
    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }
    #endregion

    #region Password
    private string _password;
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
    #endregion

    public TaskLoaderNotifier Loader { get; private set; }
    public CompositeTaskLoaderNotifier CompositeNotifier { get; set; }

    #endregion

    #region Methods & Commands

    public TaskLoaderCommand LoginCommand { get; private set; }
    private async Task OnLoginCommand()
    {
        var isSucess = await _userService.LoginAsync(Username, Password);
    }

    #endregion
}
