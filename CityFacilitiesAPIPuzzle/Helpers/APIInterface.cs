﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using CityFacilitiesAPIPuzzle.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CityFacilitiesAPIPuzzle.Helpers
{
    public class APIInterface<T>
    {
        /// <summary>
        /// Method that submits a request to the given API URL.
        /// </summary>
        /// <param name="apiURL"> URL of API to be queried. </param>
        /// <param name="headers"> Optional parameter containing KeyValuePairs of headers and header values to be added to API call. </param>
        /// <returns> Returns a list of objects from the API response. Returns an empty list if the API call is unsuccessful.</returns>
        public IEnumerable<T> CallAPI(string apiURL, IDictionary<string, string> headers = null)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.UseDefaultCredentials = true;

                using (var client = new HttpClient(handler))
                {
                    var uri = new Uri(apiURL);

                    // Add headers to API request if any are provided
                    if (headers != null)
                    {
                        foreach (KeyValuePair<string, string> keyValuePair in headers)
                        {
                            client.DefaultRequestHeaders.Add(keyValuePair.Key, keyValuePair.Value);
                        }
                    }
                    var response = client.GetAsync(uri); // Should move this to Task to be proper async

                    if (!response.Result.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine("API call failed.");
                        System.Diagnostics.Debug.WriteLine($"Error: {response.Result.Content.ReadAsStringAsync().Result}");

                        // Return empty list if API call fails
                        return new List<T>();
                    }
                    System.Diagnostics.Debug.WriteLine("API call successful.");

                    // Convert API response to usable List<T> by deserializing it
                    var jsonString = response.Result.Content.ReadAsStringAsync().Result;
                    var productList = JsonConvert.DeserializeObject<List<T>>(jsonString);

                    return productList;
                }
            }  
        }
    }
}