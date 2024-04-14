using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courses_dotnet_api.Src.DTO;
using courses_dotnet_api.Src.Interfaces;

namespace courses_dotnet_api.Src.Data
{
    public class AccountRepository : IAccountRepository
    {
        public Task AddUserAsync(RegisterDTO regUserDTO)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDTO?> GetAccountAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}