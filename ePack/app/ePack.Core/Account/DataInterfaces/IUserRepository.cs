using SharpArch.Core.PersistenceSupport;

namespace ePack.Core
{
    public interface IUserRepository : IRepository<User>
    {
    }

    public interface IInternetActivityRepository : IRepository<InternetActivity>
    {
    }
}