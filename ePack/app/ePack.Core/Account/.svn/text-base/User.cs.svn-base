using System.Collections.Generic;
using System.Collections.ObjectModel;
using NHibernate.Validator.Constraints;
using Nybble.Utils;
using SharpArch.Core.DomainModel;
using SharpArch.Core.NHibernateValidator;
using Microsoft.Practices.ServiceLocation;

namespace ePack.Core
{
    [HasUniqueDomainSignature]
    public class User : Entity
    {
        private static IEncryptionHelper EncryptionHelper
        {
            get { return ServiceLocator.Current.GetInstance<IEncryptionHelper>(); }
        }

        private UserStatus _status = UserStatus.Inactive;
        private ICollection<Site> _sites = new Collection<Site>();
        private ICollection<Function> _functions = new Collection<Function>();
        private ICollection<UserRole> _roles = new Collection<UserRole>();

        [NotNullNotEmpty]
        [Length(20)]
        [DomainSignature]
        public virtual string UserName { get; set; }

        [NotNullNotEmpty]
        public virtual string Password { get; protected set; }

        public virtual string PasswordSalt { get; protected set; }

        [NotNullNotEmpty]
        [Length(50)]
        public virtual string Email { get; set; }

        [NotNullNotEmpty]
        [Length(50)]
        public virtual string FirstName { get; set; }

        [NotNullNotEmpty]
        [Length(50)]
        public virtual string LastName { get; set; }

        [NotNull]
        public virtual Profile Profile
        {
            get;
            set;
        }

        [Size(Min = 1)]
        public virtual ICollection<Site> Sites
        {
            get { return _sites; }
            set { _sites = value; }
        }

        [NotNull]
        public virtual UserStatus Status
        {
            get { return _status; }
            protected set { _status = value; }
        }

        public virtual Company Company { get; set; }

        public virtual ICollection<Function> Functions
        {
            get { return _functions; }
            set { _functions = value; }
        }

        public virtual ICollection<UserRole> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        #region Logic Methods

        public virtual void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(Password))
            {
                //PasswordSalt = EncryptionHelper.SaltGenerator.CreateSalt();
                Password = EncryptionHelper.StringEncryptor.EncryptString(password);
            }
        }

        public virtual void ChangePassword(string password)
        {
//            PasswordSalt = EncryptionHelper.SaltGenerator.CreateSalt();
            Password = EncryptionHelper.StringEncryptor.EncryptString(password);
//            Password = EncryptionHelper.HashGenerator.CreateHash(password, PasswordSalt);
        }

        public virtual bool MatchPassword(string password)
        {
            return (Password == EncryptionHelper.StringEncryptor.EncryptString(password));
        }

        public virtual void AddFunction(Function r)
        {
            if (r != null && !Functions.Contains(r))
                Functions.Add(r);
        }

        public virtual void RemoveFunction(Function r)
        {
            if (Functions.Contains(r))
                Functions.Remove(r);
        }

        public virtual void AddRole(UserRole r)
        {
            if (r != null && !Roles.Contains(r))
                Roles.Add(r);
        }

        public virtual void RemoveRole(UserRole r)
        {
            if (Roles.Contains(r))
                Roles.Remove(r);
        }

        public virtual void Activate()
        {
            Status = UserStatus.Active;
        }

        public virtual void Deactivate()
        {
            Status = UserStatus.Inactive;
        }

        public virtual void Ban()
        {
            Status = UserStatus.Banned;
        }

        public virtual bool IsActive()
        {
            return Status == UserStatus.Active;
        }

        #endregion
    }
}