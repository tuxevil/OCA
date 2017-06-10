using System.Collections.Generic;
using System.Collections.ObjectModel;
using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;
using SharpArch.Core.NHibernateValidator;

namespace ePack.Core
{
    [HasUniqueDomainSignature]
    public class Site : Entity
    {
        public Site()
        {
            Users = new Collection<User>();
            Functions = new Collection<Function>();
        }

        public Site(int id)
        {
            Id = id;

            Users = new Collection<User>();
            Functions = new Collection<Function>();
        }

        [NotNullNotEmpty]
        [Length(50)]
        public virtual string LegalName { get; set; }

        [NotNullNotEmpty]
        [DomainSignature]
        [Length(20)]
        public virtual string SiteAddress { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Function> Functions { get; set; }

        public virtual void AddUser(User user)
        {
            if (user != null && !Users.Contains(user))
                Users.Add(user);
        }

        public virtual void AddFunction(Function function)
        {
            if (function != null && !Functions.Contains(function))
                Functions.Add(function);
        }
    }
}