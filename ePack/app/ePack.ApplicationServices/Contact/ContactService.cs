using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePack.Core;
using ePack.ApplicationServices.Views;
using Nybble.Utils;
using Nybble.Messaging;
using ePack.Utils;

namespace ePack.ApplicationServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMessageSenderService _messageSenderService;

        public ContactService(IContactRepository contactRepository, IMessageSenderService messageSenderService)
        {
            _contactRepository = contactRepository;
            _messageSenderService = messageSenderService;
        }

        public Contact Create(IContactView view)
        {
            Contact c = new Contact();

            c.Comment = view.Comment;
            c.Company = view.Company;
            c.Email = view.Email;
            c.FirstName = view.FirstName;
            c.LastName = view.LastName;
            c.Phone = view.Phone;
            c.WebSite = view.WebSite;
            c.PostalCode = view.PostalCode;

            if(!c.IsValid())
                throw new InvalidDomainModelException(c.ValidationResults());

            IUserInfo u = new UserInfo("Contactos", "OCA", Config.ContactMail);

            var data = new AskData
           {
               FullName = string.Format("{0} {1}", c.FirstName, c.LastName),
               Contact = c
            };

            var template = new FileMessageTemplate { Discriminator = "ask", Owner = u };
            template.SystemData = data;
            _messageSenderService.Send(template, u);

            _contactRepository.SaveOrUpdate(c);

            return c;
        }

        private class AskData
        {
            public string FullName { get; set; }
            public Contact Contact { get; set; }
        }

    }
}
