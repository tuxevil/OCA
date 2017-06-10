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
    public class AccountTest : ServiceTest
    {
        [Test]
        public void CanCreateSite()
        {
            Site s = CreateCustomerService().CreateSite("nybbleGroup2", "siteAddress2");
            Assert.IsNotNull(s);
        }

        [Test]
        public void CanRegisterSite()
        {
            RegisterView rv = new RegisterView();
            rv.LegalName = "Company Name";
            rv.EmailAddress = "email@email.com";
            rv.FirstName = "First Name";
            rv.LastName = "Last Name";
            rv.Password = "pwd";
            rv.SiteAddress = "Site Address";
            rv.UserName = "Owner";

            Site c = CreateCustomerService().Register(rv);

            Assert.IsNotNull(c);
            Assert.IsNotNull(c.Users.First().Password);
            Assert.IsNotNull(c.Users.First().PasswordSalt);
            Assert.IsTrue(c.LegalName == "Company Name");
            Assert.IsTrue(c.Users.First().UserName == "owner");
        }

        [Test]
        public void CanAddMember()
        {
            Site c = CreateCustomerService().RegisterUser(1,
                "Member1",
                "First Name",
                "Last Name",
                "email@email.com",
                "Owner");

            Assert.IsNotNull(c);
            Assert.IsTrue(c.Users.First().UserName == "owner");
        }

        private AccountService CreateCustomerService()
        {
            ISiteRepository repository = MockRepository.GenerateMock<ISiteRepository>();
            IUserRepository userRepository = MockRepository.GenerateMock<IUserRepository>();
            IMessageSenderService messageService = MockRepository.GenerateMock<IMessageSenderService>();
            repository.Expect(r => r.Get(1)).Return(CreateCustomer(1));
            return new AccountService(repository, userRepository, messageService, new BasicPasswordGenerator());
        }

        private Site CreateCustomer(int id)
        {
            Site c = new Site();
            c.SetIdTo(id);
            c.LegalName = "Legal Name";
            c.SiteAddress = "nybblegroup";
            return c;
        }
    }
}
