using System.Security.Claims;
using Business.Abstract;
using Entities.Concrete.School;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Business.Security
{
    public class AuthHelper
    {
        readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthHelper(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public List<Claim> GetUserClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.EMail),
                new Claim(ClaimTypes.Email,user.EMail),
                new Claim(ClaimTypes.NameIdentifier,user.FirstName+" "+user.LastName),
            };

            var operationClaims = _userService.GetOperationClaims(user.Id);

            foreach (var claim in operationClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, claim.Name));
            }

            return claims;
        }

        public async Task<bool> SecureSignInAsync(string userName, string password)
        {
            var user = _userService.GetUserByEmailAndPassword(userName, password);

            if (user!=null)
            {
                var claims = GetUserClaims(user);

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext.SignInAsync(claimsPrincipal);

                return true;
            }

            

            return false;
        }

        public async Task SecureSignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }


    }
}
