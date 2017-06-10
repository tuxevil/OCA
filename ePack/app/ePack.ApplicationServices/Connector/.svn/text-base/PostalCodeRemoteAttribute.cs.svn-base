using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nybble.Validators;
using Microsoft.Practices.ServiceLocation;

namespace ePack.ApplicationServices.Connector
{
    public class PostalCodeRemoteAttribute : RemoteAttribute
    {
        public PostalCodeRemoteAttribute(string action, string controller) : base(action, controller) { }
        public PostalCodeRemoteAttribute(string action, string controller, string successFunction) : base(action, controller, successFunction) { }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            return ValidatePostalCode(value.ToString());
        }

        public static bool ValidatePostalCode(string postalCode)
        {
            IPostalCodeRetrieverService ipcs = ServiceLocator.Current.GetInstance<IPostalCodeRetrieverService>();
            return (!string.IsNullOrEmpty(ipcs.FindCityFromPostalCode(postalCode)));
        }
    }
}
