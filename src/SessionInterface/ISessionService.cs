namespace SessionInterface
{
    public interface ISessionService
    {
        bool IsCorrectToken(string token);
        string Login(string email, string password);
        bool Logout(string token);
    }
}
