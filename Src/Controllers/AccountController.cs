using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courses_dotnet_api.Src.DTO;
using courses_dotnet_api.Src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace courses_dotnet_api.Src.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IStudentRepository _studentRepository;

        public AccountController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult> ([FromBody] LoginDTO loginDTO){

            
            return Ok();

        }

        [HttpPost("register")]
    public async Task<IResult> Register(RegisterDTO registerDto)
    {
        if (
            await _studentRepository.GetStudentByEmailAsync(registerDto.Email)
            || await _studentRepository.GetStudentByRutAsync(registerDto.Rut)
        )
        {
            return TypedResults.BadRequest("User already exists");
        }

        await _accountRepository.AddAccountAsync(registerDto);

        if (!await _accountRepository.SaveChangesAsync())
        {
            return TypedResults.BadRequest("Failed to save user");
        }

        AccountDto? accountDto = await _accountRepository.GetAccountAsync(registerDto.Email);

        return TypedResults.Ok(accountDto);
    }

    }
}