using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courses_dotnet_api.Src.DTO;

namespace courses_dotnet_api.Src.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AccountDTO accountDTO);
    }
}