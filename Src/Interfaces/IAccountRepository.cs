using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courses_dotnet_api.Src.DTO;

namespace courses_dotnet_api.Src.Interfaces
{
    public interface IAccountRepository
    {
        /*method to save the changes so async*/
        public Task<bool> SaveChangesAsync();
        
        /*method to registerUsers users so async*/
        public Task AddUserAsync(RegisterDTO regUserDTO);

        public Task<AccountDTO?> GetAccountAsync(string email);
    }
}