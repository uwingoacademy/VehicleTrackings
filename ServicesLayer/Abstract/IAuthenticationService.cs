using EntitiesLayer.Abstract;
using EntitiesLayer.Contract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistrationDto);
        Task<bool> ValidateUser(UserForAuthenticationDTO userForAuthenticationDto);
        Task<TokenDTO> CreateToken(bool populateExp);
        Task<TokenDTO> RefreshToken(TokenDTO tokenDto);
        Task<User> GetUserByUserName(string userName);

    }
}
