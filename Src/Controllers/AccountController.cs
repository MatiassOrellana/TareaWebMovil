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

            


        }

    }
}