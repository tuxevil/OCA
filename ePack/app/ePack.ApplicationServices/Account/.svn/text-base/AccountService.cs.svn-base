using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nybble.Messaging;
using Nybble.Utils;
using ePack.Core;
using ePack.ApplicationServices.Views;
using System.Web.Mvc;
using System.Web;

namespace ePack.ApplicationServices
{
    public class AccountService : IAccountService
    {
        #region Constructors

        private readonly IMessageSenderService _messageSenderService;
        private readonly ISiteRepository _siteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordGenerator _passwordGenerator;

        public AccountService(ISiteRepository siteRepository, IUserRepository userRepository,
                              IMessageSenderService messageSenderService, IPasswordGenerator passwordGenerator)
        {
            _siteRepository = siteRepository;
            _userRepository = userRepository;
            _messageSenderService = messageSenderService;
            _passwordGenerator = passwordGenerator;
        }

        #endregion

        #region Site Methods

        public Site CreateSite(string legalName, string siteAddress)
        {
            var c = new Site();
            c.LegalName = legalName;
            c.SiteAddress = siteAddress.Trim().ToLower();

            if (!c.IsValid())
                throw new InvalidDomainModelException(c.ValidationResults());

            _siteRepository.SaveOrUpdate(c);

            return c;
        }

        public Site Register(IRegisterView view)
        {
            User u = FindUser(view.UserName);
            if (u != null)
                throw new UserAlreadyExistException();

            u = FindByEmail(view.EmailAddress);
            if (u != null)
                throw new EmailAlreadyExistException();

            if (view.Password != view.PasswordConfirm)
                throw new PasswordNotMatchException();

            Site c = _siteRepository.Get(1);

            var o = new User();
            o.FirstName = view.FirstName;
            o.LastName = view.LastName;
            o.Email = view.EmailAddress.Trim().ToLower();
            o.UserName = view.UserName.Trim().ToLower();
            o.SetPassword(view.Password);

            var p = new Profile();
            p.PreCelPhone = view.PreCelPhone;
            p.CelPhone = view.CelPhone;
            p.Company = view.Company;
            p.ContactMe = view.ContactMe;
            p.CuitNumber = view.CuitNumber;
            p.GetInformation = view.GetInformation;
            p.Industry = view.Industry;
            p.InternetActivity = view.InternetActivity;
            p.OcaNumber = view.OcaNumber;
            p.PrePhone = view.PrePhone;
            p.Phone =view.Phone;
            p.Position = view.Position;
            p.Website = view.Website;
            p.PostalCode = view.PostalCode;
           
            o.Profile = p;

            o.Sites.Add(c);

            if (!o.IsValid())
                throw new InvalidDomainModelException(o.ValidationResults());

            c.AddUser(o);

            if (!c.IsValid())
                throw new InvalidDomainModelException(c.ValidationResults());

            SendConfirmationToken(o);

            _siteRepository.SaveOrUpdate(c);

            return c;
        }

        #endregion

        #region Register Users

        public Site RegisterUser(int siteId,
                                 string memberName,
                                 string firstName,
                                 string lastName,
                                 string emailAddress,
                                 string userName)
        {
            return RegisterUser(siteId, memberName, firstName, lastName, emailAddress, userName, null);
        }

        public Site RegisterUser(int siteId,
                                 string memberName,
                                 string firstName,
                                 string lastName,
                                 string emailAddress,
                                 string userName,
                                 string password)
        {
            User u = FindUser(userName);
            if (u != null)
                throw new UserAlreadyExistException();

            Site c = _siteRepository.Get(siteId);

            var m = new User();
            m.UserName = memberName;
            m.FirstName = firstName;
            m.LastName = lastName;
            if (!string.IsNullOrEmpty(password))
                m.SetPassword(password);
            else
                m.SetPassword(_passwordGenerator.GeneratePassword(10));
            m.Email = emailAddress.Trim().ToLower();
            m.UserName = userName.Trim().ToLower();
            c.AddUser(m);

            SendConfirmationToken(m);

            _siteRepository.SaveOrUpdate(c);

            return c;
        }

        

        #endregion

        #region Functions Methods

        public Site AssignFunctionToUser(int siteId, string userName, string functionName)
        {
            Site customer = _siteRepository.Get(siteId);
            Function role = customer.Functions.SingleOrDefault(x => x.Name == functionName.Trim());
            User user = customer.Users.SingleOrDefault(x => x.UserName == userName.Trim());

            if (user != null && role != null)
                user.AddFunction(role);

            _siteRepository.SaveOrUpdate(customer);

            return customer;
        }

        public Site AddFunctionToSite(int siteId, string functionName)
        {
            Site customer = _siteRepository.Get(siteId);
            Function role = customer.Functions.SingleOrDefault(x => x.Name == functionName.Trim());

            if (role == null)
                customer.AddFunction(new Function {Name = functionName, Site = customer});

            _siteRepository.SaveOrUpdate(customer);

            return customer;
        }

        #endregion

        #region Helper Methods

        private User FindUser(string userName)
        {
            IDictionary<string, object> propertyValues = new Dictionary<string, object>();
            propertyValues.Add("UserName", userName.Trim().ToLower());
            return _userRepository.FindOne(propertyValues);
        }

        private User FindByEmail(string email)
        {
            IDictionary<string, object> propertyValues = new Dictionary<string, object>();
            propertyValues.Add("Email", email.Trim().ToLower());
            return _userRepository.FindOne(propertyValues);
        }
        #endregion

        #region Creation of Confirmation Token

        private void SendConfirmationToken(User u)
        {
            var data = new ActivateData
            {
                ConfirmUrl = string.Format(@"/Validation/ConfirmEmail/default.aspx?token={0}", HttpUtility.UrlEncode(CreateUserConfirmationToken(u))),
                                            FullName = string.Format ("{0} {1}", u.FirstName, u.LastName)};

            var template = new FileMessageTemplate { Discriminator = "activate", Owner = u.ToUserInfo() };
            template.SystemData = data;
            _messageSenderService.Send(template, u.ToUserInfo());
        }

        private class ActivateData
        {
            public string ConfirmUrl { get; set; }
            public string FullName { get; set; }
        }

        /// <summary>
        /// Creates a token to allow resetting the user password
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Token generated</returns>
        private string CreateUserConfirmationToken(User user)
        {
            string token = string.Format("{0},{1}", user.UserName, user.Email);
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(token));
        }

        #endregion
    }

    public class InternetActivityService : IInternetActivityService
    {
        private readonly IInternetActivityRepository _internetActivityRepository;

        public InternetActivityService(IInternetActivityRepository internetActivityRepository)
        {
            _internetActivityRepository = internetActivityRepository;
        }
        public List<SelectListItem> InternetActivityList()
        {
            IList<InternetActivity> lst = _internetActivityRepository.GetAll();
            List<SelectListItem> iaLst = new List<SelectListItem>();
            foreach (InternetActivity item in lst)
            {
                SelectListItem ia = new SelectListItem();
                ia.Selected = true;
                ia.Text = item.Descrition;
                ia.Value = item.Id.ToString();

                iaLst.Add(ia);
            }
            return iaLst;
        }
    }
    public class UserAlreadyExistException : Exception
    {
    }

    public class EmailAlreadyExistException : Exception
    {
    }

    public class PasswordNotMatchException : Exception
    {
    }

}