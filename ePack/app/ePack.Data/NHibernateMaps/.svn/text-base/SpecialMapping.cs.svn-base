using ePack.Core;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;

namespace ePack.Data.NHibernateMaps
{
    #region Account Mapping

    public class UserRoleOverride : IAutoMappingOverride<UserRole>
    {
        #region IAutoMappingOverride<UserRole> Members

        public void Override(AutoMapping<UserRole> mapping)
        {
            mapping.Map(x => x.Role)
                .CustomType(typeof (int))
                .Access.CamelCaseField(Prefix.Underscore);
        }

        #endregion
    }

    public class UserMap : IAutoMappingOverride<User>
    {
        #region IAutoMappingOverride<User> Members

        public void Override(AutoMapping<User> mapping)
        {
            mapping.HasManyToMany(x => x.Functions);
            mapping.Map(x => x.PasswordSalt).Nullable();
        }
        
        #endregion
    }

    public class ProfileMap : IAutoMappingOverride<Profile>
    {
        public void Override(AutoMapping<Profile> mapping)
        {
            mapping.Map(m => m.Website).Nullable();
            mapping.Map(m => m.Position).Nullable();
            mapping.Map(m => m.Phone).Nullable();
            mapping.Map(m => m.PrePhone).Nullable();
            mapping.Map(m => m.OcaNumber).Nullable();
            mapping.Map(m => m.Industry).Nullable();
            mapping.Map(m => m.CuitNumber).Nullable();
            mapping.Map(m => m.Company).Nullable();
            mapping.Map(m => m.PreCelPhone).Nullable();
            mapping.Map(m => m.CelPhone).Nullable();
        }

    }

    public class ContactMap : IAutoMappingOverride<Contact>
    {
        public void Override(AutoMapping<Contact> mapping)
        {
            mapping.Map(m => m.WebSite).Nullable();
            mapping.Map(m => m.Company).Nullable();
        }

    }

    public class SiteMap : IAutoMappingOverride<Site>
    {
        #region IAutoMappingOverride<Site> Members

        public void Override(AutoMapping<Site> mapping)
        {
            mapping.HasManyToMany(x => x.Users).Cascade.AllDeleteOrphan();
            mapping.HasMany(x => x.Functions).Cascade.AllDeleteOrphan();
        }

        #endregion
    }

    #endregion

}