namespace PocTaskLoader.Core.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Login a user
    /// </summary>
    /// <returns>True if login success else, return false</returns>
    /// <exception cref="ArgumentNullException">If username or password are null</exception>
    /// <exception cref="HttpRequestException">If application can't connect to API</exception>
    Task<bool> LoginAsync(string username, string password);
}
