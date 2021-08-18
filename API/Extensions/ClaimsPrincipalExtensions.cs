using System.Security.Claims;

namespace API.Errors
{
    public static class ClaimsPrincipalExtensions
    {
        public static string RetrievEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }
}