using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePack.Core.RepositoryInterfaces;

namespace ePack.ApplicationServices.Connector
{
    public interface IPostalCodeRetrieverService
    {
        string FindCityFromPostalCode(string postalCode);
    }

    public class PostalCodeRetrieverService : IPostalCodeRetrieverService
    {
        private readonly IPostalCodeRepository _ipostalCodeRepository;

        public PostalCodeRetrieverService(IPostalCodeRepository postalCodeRepository)
        {
            _ipostalCodeRepository = postalCodeRepository;
        }
        /// <summary>
        /// Finds a postal code in the Intranet database
        /// </summary>
        /// <param name="postalCode">Postal Code</param>
        /// <returns>Null if not found, otherwise the city name is provided.</returns>
        public string FindCityFromPostalCode(string postalCode)
        {
            string city = _ipostalCodeRepository.PostalCodeLocation(postalCode);
            return city;
        }
    }
}
