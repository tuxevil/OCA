using Nybble.Utils;

namespace ePack.Core
{
    public class Role : Enumeration
    {
        public static Role Member = new MemberRole();
        public static Role Administrator = new AdministratorRole();
        public static Role Owner = new OwnerRole();

        public Role()
        {
        }

        public Role(int value, string displayName) : base(value, displayName)
        {
        }

        #region Nested type: AdministratorRole

        private class AdministratorRole : Role
        {
            public AdministratorRole() : base(0, "Administrator")
            {
            }
        }

        #endregion

        #region Nested type: MemberRole

        private class MemberRole : Role
        {
            public MemberRole() : base(0, "Member")
            {
            }
        }

        #endregion

        #region Nested type: OwnerRole

        private class OwnerRole : Role
        {
            public OwnerRole() : base(0, "Owner")
            {
            }
        }

        #endregion
    }
}