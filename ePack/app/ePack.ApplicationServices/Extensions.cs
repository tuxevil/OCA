using ePack.Core;
using Nybble.Messaging;

namespace ePack.ApplicationServices
{
    public static class DomainExtensions
    {
        public static IUserInfo ToUserInfo(this User user)
        {
            return new UserInfo(user.FirstName, user.LastName, user.Email);
        }
    }
}