using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePack.Core;
using Nybble.Messaging;
using Nybble.Utils;

namespace ePack.ApplicationServices
{
    public class SignInService : ISignInService
    {
        #region Private Properties & Constructor

        private const int HoursToExpire = 48;
        private const int PasswordGenerationLength = 10;
        private readonly IMessageSenderService _messageSenderService;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly ITokenizer _tokenizer;

        public SignInService(IMessageSenderService messageSenderService, IUserRepository userRepository, IPasswordGenerator passwordGenerator
            ,ITokenizer tokenizer)
        {
            _messageSenderService = messageSenderService;
            _userRepository = userRepository;
            _passwordGenerator = passwordGenerator;
            _tokenizer = tokenizer;
        }

        #endregion

        #region Login Methods

        public User Login(int siteAddressId, string userName, string password)
        {
            User u = FindUser(siteAddressId, userName);
            if (u != null && u.MatchPassword(password))
                return u;

            throw new InvalidCredentialsException();
        }

        #endregion

        #region Reset Password Methods

        /// <summary>
        /// Send a reset email for the user password.
        /// </summary>
        /// <param name="siteAddress">Site address</param>
        /// <param name="userNameOrEmail">User name or Email address</param>
        /// <returns>Token generated</returns>
        public string SendResetPasswordEmail(int siteAddressId, string userName)
        {
            User u = FindUser(siteAddressId, userName);

            string token = CreateResetPasswordToken(siteAddressId, userName);

            IMessage m = new Message {Body = string.Format("Your token is: {0}.", token), Subject = "Subject"};
            _messageSenderService.Send(m, u.ToUserInfo());

            return token;
        }

        /// <summary>
        /// Creates a token to allow resetting the user password with a 3 hours expire limit by default.
        /// </summary>
        /// <param name="siteAddress">Site address</param>
        /// <param name="userNameOrEmail">User name or Email address</param>
        /// <returns>Token generated</returns>
        private string CreateResetPasswordToken(int siteAddressId, string userNameOrEmail)
        {
            return CreateResetPasswordToken(siteAddressId, userNameOrEmail, HoursToExpire);
        }

        /// <summary>
        /// Creates a token to allow resetting the user password
        /// </summary>
        /// <param name="siteAddress">Site address</param>
        /// <param name="userNameOrEmail">User name or Email address</param>
        /// <param name="hoursToExpire">Hours to expire the token from now</param>
        /// <returns>Token generated</returns>
        private string CreateResetPasswordToken(int siteAddressId, string userName, int hoursToExpire)
        {
            User u = FindUser(siteAddressId, userName);
            if (u != null)
                return _tokenizer.CreateToken(string.Format("{0},{1}", siteAddressId, userName));
                

            return null;
        }

        /// <summary>
        /// Resets a user password using the generated token.
        /// </summary>
        /// <param name="token">Token provided by the system</param>
        /// <returns>The new password generated.</returns>
        public string ResetPassword(string token)
        {
            string unencoded = _tokenizer.ValidateToken(token);
            string[] parameters = unencoded.Split(',');

            int siteAddressId = Convert.ToInt32(parameters[0]);
            string userName = parameters[1];

            User u = FindUser(siteAddressId, userName);
            if (u != null)
            {
                string password = _passwordGenerator.GeneratePassword(PasswordGenerationLength);
                u.ChangePassword(password);
                _userRepository.SaveOrUpdate(u);
                return password;
            }

            throw new InvalidCredentialsException();
        }

        #endregion

        #region Change Current Password

        public void ChangePassword(int siteAddressId, string userName, string oldPassword, string newPassword)
        {
            User u = FindUser(siteAddressId, userName);
            if (u != null && u.MatchPassword(oldPassword))
            {
                u.ChangePassword(newPassword);

                IMessage m = new Message {Body = "Your password has been changed", Subject = "Subject"};
                _messageSenderService.Send(m, u.ToUserInfo());

                _userRepository.SaveOrUpdate(u);

                return;
            }

            throw new InvalidCredentialsException();
        }

        #endregion

        #region Activation 

        public User ActivateUser(string token)
        {
            string unencoded = Encoding.Unicode.GetString(Convert.FromBase64String(token));
            string[] parameters = unencoded.Split(',');

            string userName = parameters[0];

            User u = FindUser(userName);

            if (u != null)
            {
                u.Activate();
                _userRepository.SaveOrUpdate(u);

                return u;
            }

            throw new InvalidCredentialsException();
        }

        private class ContactData
        {
            public string FullName { get; set; }
        }
        #endregion

        #region Helper Methods

        private User FindUser(int siteAddressId, string userName)
        {
            IDictionary<string, object> propertyValues = new Dictionary<string, object>();
            propertyValues.Add("UserName", userName.Trim().ToLower());
            User u = _userRepository.FindOne(propertyValues);

            if (u != null && u.IsActive())
                if (u.Sites.FirstOrDefault(x=> x.Id == siteAddressId) != null)
                    return u;

            throw new InvalidCredentialsException();
        }

        private User FindUser(string userName)
        {
            IDictionary<string, object> propertyValues = new Dictionary<string, object>();
            propertyValues.Add("UserName", userName.Trim().ToLower());
            return _userRepository.FindOne(propertyValues);
        }

        #endregion
    }

    public class InvalidCredentialsException : Exception
    {
    }
}