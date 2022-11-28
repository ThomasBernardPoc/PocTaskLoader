using PocTaskLoader.Core.Services.Interfaces;

namespace PocTaskLoader.Core.Services;

public class MockedUserService : IUserService
{
    public async Task<bool> LoginAsync(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            throw new ArgumentNullException("username or password must be filled");

        await Task.Delay(2000);

        if (new Random().Next(3) == 2)
            throw new HttpRequestException("Can't connect to server");

        return (username == "admin" && password == "admin");
    }
}
