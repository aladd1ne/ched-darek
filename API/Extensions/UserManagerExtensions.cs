using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
           public static  async Task<AppUser> FindUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> input,ClaimsPrincipal user)
        {
             var email = user.FindFirstValue(ClaimTypes.Email);

             return await input.Users.Include(x => x.Adress).SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<AppUser> FindByEmailClaimsPrinciple(this UserManager<AppUser> input,ClaimsPrincipal user)
        {
             var email = user.FindFirstValue(ClaimTypes.Email);
              return await input.Users.Include(x => x.Adress).SingleOrDefaultAsync(x => x.Email == email);

        }
    }
}



 