using Core.Entities.Identity;

namespace Core.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}