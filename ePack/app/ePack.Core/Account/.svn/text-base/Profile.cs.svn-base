using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;

namespace ePack.Core
{
    public class Profile
    {
        [Length(100)]
        public virtual string Company { get; set; }
        [Length(100)]
        public virtual string Industry { get; set; }
        [Length(50)]
        public virtual string Website { get; set; }
        [Length(100)]
        public virtual string Position { get; set; }

        public virtual string PrePhone { get; set; }
        [Length(20)]
        public virtual string Phone { get; set; }
       
        public virtual string PreCelPhone { get; set; }
        [Length(20)]
        public virtual string CelPhone { get; set; }
        [NotNullNotEmpty]
        
        public virtual InternetActivity InternetActivity { get; set; }
        [Length(50)]
        public virtual string CuitNumber { get; set; }
        [Length(50)]
        public virtual string OcaNumber { get; set; }
        public virtual bool ContactMe { get; set; }
        public virtual bool GetInformation { get; set; }
        [Length(8)]
        public virtual string PostalCode { get; set; }
    }
}
