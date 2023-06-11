using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using CityFacilitiesAPIPuzzle.Models;
using System.Collections.ObjectModel;

namespace CityFacilitiesAPIPuzzle.Helpers
{
    public class APIInterface<T>
    {
        private static HttpClientHandler handler = new HttpClientHandler();
        private static HttpClient client = new HttpClient(handler);

        /// <summary>
        /// Method that submits a request to the given API URL.
        /// </summary>
        /// <param name="apiURL"> URL of API to be queried. </param>
        /// <param name="headers"> Optional parameter containing KeyValuePairs of headers and header values to be added to API call. </param>
        /// <returns> Returns a list of objects. Returns an empty list if the API call is unsuccessful.</returns>
        public IEnumerable<T> CallAPI(string apiURL, IDictionary<string, string> headers = null)
        {
            handler.UseDefaultCredentials = true;
            var uri = new Uri(apiURL);

            // Add headers to API request if any are provided
            if(headers != null)
            {
                foreach (KeyValuePair<string, string> keyValuePair in headers)
                {
                    client.DefaultRequestHeaders.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
            var response = client.GetAsync(uri); // Should move this to Task to be proper async
            //response.Result.EnsureSuccessStatusCode();

            if (!response.Result.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("API call failed.");
                System.Diagnostics.Debug.WriteLine($"Error: {response.Result.Content.ReadAsStringAsync().Result}");

                return new List<T>();
            }
            System.Diagnostics.Debug.WriteLine("API call successful.");

            var jsonString = response.Result.Content.ReadAsStringAsync().Result;
            var productList = JsonConvert.DeserializeObject<List<T>>(jsonString);

            return productList;
        }
    }
}