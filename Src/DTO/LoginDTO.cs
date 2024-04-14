using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace courses_dotnet_api.Src.DTO
{
    public class LoginDTO
    {
        [EmailAddress]
        public required string Email { get; set; }

        [StringLength(
            20,
            MinimumLength = 8,
            ErrorMessage = "Password must be between 8 and 20 characters"
        )]
        public required string Password { get; set; }
    }
}