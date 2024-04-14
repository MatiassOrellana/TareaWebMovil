using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using courses_dotnet_api.Src.DTO;
using courses_dotnet_api.Src.Interfaces;
using courses_dotnet_api.Src.Models;

namespace courses_dotnet_api.Src.Data
{
    public class AccountRepository : IAccountRepository
    {

        private readonly DataContext _dataContext;

        //public readonly ITokenService _tokenService;

        public AccountRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddUserAsync(RegisterDTO regDTO)
        {

            using var hmac = new HMACSHA512();
            Student student =
            new()
            {
                Rut = regDTO.Rut,
                Name = regDTO.Name,
                Email = regDTO.Email,
                PasswordEncrypt = hmac.ComputeHash(Encoding.UTF8.GetBytes(regDTO.Password)),
                Salt = hmac.Key
            };

            await _dataContext.Students.AddAsync(student);//the user is added
        }

        public async Task<AccountDTO?> GetAccountAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return 0 < await _dataContext.SaveChangesAsync();
        }
    }

    internal interface IMapper
    {
    }
}