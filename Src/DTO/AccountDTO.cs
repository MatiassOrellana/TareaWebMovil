using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courses_dotnet_api.Src.DTO
{
    public class AccountDTO
    {
        
        public required string Rut { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Token { get; set; }
    }
}