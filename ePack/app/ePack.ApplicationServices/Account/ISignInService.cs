using ePack.Core;

namespace ePack.ApplicationServices
{
    public interface ISignInService
    {
        User Login(int siteAddressId, string userName, string password);
        User ActivateUser(string token);
    }
}