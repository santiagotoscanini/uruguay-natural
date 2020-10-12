using InfrastructureInterface.Data.Repositories;
using SessionInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Services
{
    public class SessionService : ISessionService
    {
        private IAdministratorRepository _repository;
        private static IDictionary<string, string> _tokenRepository = null;

        public SessionService(IAdministratorRepository repository)
        {
            _repository = repository;
            if (_tokenRepository == null)
            {
                _tokenRepository = new Dictionary<string, string>();
            }
        }

        public bool IsCorrectToken(string token)
        {
            return _tokenRepository.ContainsKey(token);
        }

        public string Login(string email, string password)
        {
            var admins = _repository.GetAll();
            var admin = admins.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (admin == null)
            {
                return null;
            }

            var token = Guid.NewGuid().ToString();
            _tokenRepository.Add(token, admin.Email);
            return token;
        }

        public bool Logout(string token)
        {
            if (!_tokenRepository.Remove(token))
            {
                return false;
            }
            return true;
        }
    }
}
