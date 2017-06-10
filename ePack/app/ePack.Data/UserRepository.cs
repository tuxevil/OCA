using ePack.Core;
using SharpArch.Data.NHibernate;

namespace ePack.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
    }

    public class InternetActivityRepository : Repository<InternetActivity>, IInternetActivityRepository
    { }
}