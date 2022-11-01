using AirBnb.BL.DTOs.AuthenticationDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageAuthentication
{
    public interface IAuthenticationManager
    {
        Task<TokenDto> LoginUser(UserLoginDTO model);
        string GenerateToken(IEnumerable<Claim> myClaims, SigningCredentials credentials);
    }
}
