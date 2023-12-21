using System;
using System.Threading.Tasks;

namespace FamilyBudget.Infrastructure.Services
{
    public class AuthenticationService
    {

        public AuthenticationService()
        {
            // Инициализация сервиса
        }

        public async Task<bool> RegisterUserAsync(string username, string password)
        {
            // Реализация регистрации пользователя
            throw new NotImplementedException();
        }

        public async Task<bool> LoginUserAsync(string username, string password)
        {
            // Реализация входа пользователя
            throw new NotImplementedException();
        }

        public void Logout()
        {
            // Реализация выхода пользователя
            throw new NotImplementedException();
        }

    }
}
