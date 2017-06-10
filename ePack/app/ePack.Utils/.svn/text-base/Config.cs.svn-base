using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ePack.Utils
{
    public class Config
    {
        public static string IntranetConnection
        {
            get { return ConfigurationManager.ConnectionStrings["OcaIntranet"].ToString(); }
        }

        public static string GoogleUser
        {
            get
            {

                if (ConfigurationManager.AppSettings["Gmail_User"] != null)
                    return ConfigurationManager.AppSettings["Gmail_User"];

                throw new Exception("Gmail user not defined in webconfig.");
            }
        }

        public static string GooglePass
        {
            get
            {

                if (ConfigurationManager.AppSettings["Gmail_Pass"] != null)
                    return ConfigurationManager.AppSettings["Gmail_Pass"];

                throw new Exception("Gmail password not defined in webconfig.");

            }
        }

        public static string ContactMail
        {
            get
            {

                if (ConfigurationManager.AppSettings["Contact_Mail"] != null)
                    return ConfigurationManager.AppSettings["Contact_Mail"];

                throw new Exception("Contact_Mail not defined in webconfig.");

            }
        }
    }
}
