using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace Tiers.Service
{
    public class UserWebApiClient
    {
        protected readonly string _endpoint;

        /// <summary>
        /// Quick and dirty web api client for consumers to use
        /// </summary>
        /// <param name="endpoint"></param>
        public UserWebApiClient(string endpoint = "http://localhost:58228/api/users")
        {
            _endpoint = endpoint;
        }

        public string Get()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(_endpoint).Result;

                // This works:
                var result1 = response.Content.ReadAsStringAsync().Result;
                return result1.ToString();
            }
        }
    }
}
