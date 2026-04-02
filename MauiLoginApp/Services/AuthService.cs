using MauiLoginApp.Models;

namespace MauiLoginApp.Services;

public class AuthService
{
    private static List<User> _users = new List<User>();

    public Task<bool> Register(string username, string password, string email)
    {
        if (_users.Any(u => u.Username == username))
            return Task.FromResult(false);

        _users.Add(new User { Username = username, Password = password, Email = email });
        return Task.FromResult(true);
    }

    public Task<User> Login(string username, string password)
    {
        var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        return Task.FromResult(user);
    }
}
