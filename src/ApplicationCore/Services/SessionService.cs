using Entities;
using SessionInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using ApplicationCoreInterface.Services;

namespace ApplicationCore.Services
{
    public class SessionService : ISessionService
    {
        private IAdministratorService _administratorService;
        private static IDictionary<string, string> _tokenRepository;
        private readonly string InvalidEmailOrPasswordMessage = "Invalid email or password.";
        
        public SessionService(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
            _tokenRepository ??= new Dictionary<string, string>();
        }

        public bool IsCorrectToken(string token)
        {
            return _tokenRepository.ContainsKey(token);
        }

        public string Login(string email, string password)
        {
            Administrator admin = GetAdmin(email, password);
            if (admin == null)
            {
                throw new InvalidCredentialException(InvalidEmailOrPasswordMessage);
            }

            return GenerateAndInsertToken(admin);
        }

        private Administrator GetAdmin(string email, string password)
        {
            IEnumerable<Administrator> admins = _administratorService.GetAll();
            return admins.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        private string GenerateAndInsertToken(Administrator admin)
        {
            var token = Guid.NewGuid().ToString();
            _tokenRepository.Add(token, admin.Email);
            return token;
        }

        public bool Logout(string token)
        {
            return _tokenRepository.Remove(token);
        }
    }
}
