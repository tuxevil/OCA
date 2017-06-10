using NHibernate.Validator.Constraints;

namespace ePack.Core
{
    public class PhoneNumber
    {
        [NotNullNotEmpty]
        public string AreaCode;

        [NotNullNotEmpty]
        public string LineNumber;
    }
}