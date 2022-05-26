using System.Security.Claims;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebUI.DataAccess.EFRepository.DalLayer;

namespace WebUI.AuthHelpers
{
    public class AuthHelper
    {
        private IUserDal _userDal;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthHelper(IUserDal userDal, IHttpContextAccessor httpContextAccessor)
        {
            _userDal = userDal;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Claim> GetUserClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.EMail),
                new Claim(ClaimTypes.Email,user.EMail),
                new Claim(ClaimTypes.NameIdentifier,user.FirstName+" "+user.LastName),
            };

            var operationClaims = _userDal.GetOperationClaims(user.Id);

            foreach (var claim in operationClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, claim.Name));
            }

            return claims;
        }

        public async Task<bool> SecureSignInAsync(string userName, string password)
        {
            var user = _userDal.GetUserByEmailAndPassword(userName, password);

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
