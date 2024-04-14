using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using courses_dotnet_api.Src.DTO;
using courses_dotnet_api.Src.Interfaces;
using courses_dotnet_api.Src.Models;
using Microsoft.EntityFrameworkCore;

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
            Student? student = await _dataContext
            .Students.Where(student => student.Email == email)
            .FirstOrDefaultAsync();

            if (student == null)
            {
                return null;
            }

            AccountDTO accountDto =
                new()
                {
                    Rut = student.Rut,
                    Name = student.Name,
                    Email = student.Email,
                    Token = _tokenService.CreateToken(user.Rut)
                };

            return accountDto;
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