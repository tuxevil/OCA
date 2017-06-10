using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;

namespace ePack.Core
{
    public class InternetActivity : Entity
    {
        [Length(20)]
        public virtual string Descrition { get; set; }
    }
}