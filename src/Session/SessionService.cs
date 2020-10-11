using SessionInterface;

namespace Session
{
    public class SessionService : ISessionService
    {
        public bool IsCorrectToken(string token)
        {
            return true;
        }
    }
}
