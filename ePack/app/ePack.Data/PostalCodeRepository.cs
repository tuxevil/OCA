using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SharpArch.Data.NHibernate;
using ePack.Core.RepositoryInterfaces;
using ePack.Utils;

namespace ePack.ApplicationServices
{
    public class PostalCodeRepository : IPostalCodeRepository
    {
        private static string connectionString = Config.IntranetConnection;

        public string PostalCodeLocation(string postalCode)
        {
            string location = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = string.Format("select Distinct TOP 1 Descripcion from Canalizador where CodigoPostal = '{0}'", postalCode.Trim());

                conn.Open();
                object locFound = command.ExecuteScalar();
                if (locFound != null)
                    location = locFound.ToString();
            }

            return location;
        }
    }
}
