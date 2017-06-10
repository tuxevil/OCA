using Nybble.Utils;
using SharpArch.Core.DomainModel;

namespace ePack.Core
{
    public class UserRole : Entity
    {
        protected int _role;
        public virtual User User { get; set; }

        public virtual Role Role
        {
            get { return Enumeration.FromValue<Role>(_role); }
            set { _role = value.Value; }
        }

        public virtual Site Site { get; set; }
    }
}