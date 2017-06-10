using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ePack.ApplicationServices;
using Nybble.Messaging;
using Rhino.Mocks;
using ePack.Core;
using SharpArch.Testing;
using ePack.ApplicationServices.Views;
using Nybble.Utils;

namespace Tests.ApplicationServices
{
    [TestFixture]
    public class SignInTest : ServiceTest
    {
        [Test]
        public void CanSignIn()
        {
            CreateSignInService().Login(1, "owner", "pass1234");
        }

        [Test]
        [ExpectedException(typeof(InvalidCredentialsException))]
        public void CanNotSignInInactive()
        {
            CreateSignInService().Login(1, "owner2", "pass1234");
        }

        [Test]
        [ExpectedException(typeof(InvalidCredentialsException))]
        public void CanNotSignInBadUserName()
        {
            CreateSignInService().Login(1, "owner2", "pass1234");
        }

        [Test]
        [ExpectedException(typeof(InvalidCredentialsException))]
        public void CanNotSignInBadPassword()
        {
            CreateSignInService().Login(1, "owner", "p333ass1234");
        }

        [Test]
        public void CanGenerateValidPasswordToken()
        {
            SignInService service = CreateSignInService();
            string token = service.SendResetPasswordEmail(1, "owner");
            Assert.IsNotNull(token);

            string newPassword = service.ResetPassword(token);
            Assert.IsNotNull(newPassword);

            User u = service.Login(1, "owner", newPassword);
            Assert.IsNotNull(u);
        }

        [Test]
        public void CanChangePassword()
        {
            SignInService service = CreateSignInService();

            string newPassword = "pass4321";
            service.ChangePassword(1, "owner", "pass1234", newPassword);
            User u = service.Login(1, "owner", newPassword);
            Assert.IsNotNull(u);
        }

        private SignInService CreateSignInService()
        {
            IUserRepository userRepository = MockRepository.GenerateMock<IUserRepository>();
            IMessageSenderService messageService = MockRepository.GenerateMock<IMessageSenderService>();

            User user = new User();
            user.FirstName = "First Name";
            user.LastName = "Last Name";
            user.SetPassword("pass1234");
            user.UserName = "owner";
            user.Activate();
            user.Sites.Add(new Site { LegalName = "nybblegroup", SiteAddress = "nybblegroup" });

            User inactiveUser = new User();
            inactiveUser.FirstName = "First Name";
            inactiveUser.LastName = "Last Name";
            inactiveUser.SetPassword("pass1234");
            inactiveUser.UserName = "owner2";
            inactiveUser.Sites.Add(new Site { LegalName = "nybblegroup", SiteAddress = "nybblegroup" });

            IDictionary<string, object> propertyValues = new Dictionary<string, object>();
            propertyValues.Add("UserName", "owner".Trim().ToLower());
            userRepository.Expect(r => r.FindOne(propertyValues)).Return(user);

            propertyValues = new Dictionary<string, object>();
            propertyValues.Add("UserName", "owner2".Trim().ToLower());
            userRepository.Expect(r => r.FindOne(propertyValues)).Return(inactiveUser);


            return new SignInService(messageService, userRepository, new BasicPasswordGenerator(), new ExpireTokenizer());
        }
    }
}
