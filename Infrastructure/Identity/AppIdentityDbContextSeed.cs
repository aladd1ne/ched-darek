using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any()) {
                var user = new AppUser
                {
                    DisplayName = "Aladdine",
                    Email = "ala@test.com",
                    UserName = "aladdin@test.com",
                    Adress = new Address
                    {
                        FirstName  = "aladdine",
                        LastName = "Saidi",
                        Street = "Madda",
                        City = "Bizerte",
                        State = "Tunisie",
                        ZipCode = "7000",
                    }
                };

                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}