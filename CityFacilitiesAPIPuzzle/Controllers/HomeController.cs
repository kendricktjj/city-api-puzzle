using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using CityFacilitiesAPIPuzzle.Models;
using Newtonsoft.Json;
using CityFacilitiesAPIPuzzle.Helpers;
using System.Threading.Tasks;

namespace CityFacilitiesAPIPuzzle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
             * Start the program with a blank list of products.
             * Add a single dummy product to help with refreshing the table after data is loaded.
             * There's probably a better way to do this, but I don't have the time to look into it.
             */
            Product dummy = new Product();
            var initialList = new List<Product>();
            initialList.Add(dummy);

            return View(initialList);
        }

        [HttpPost]
        public ActionResult GetProducts()
        {
            APIInterface<Product> apiI = new APIInterface<Product>();
            string apiURL = "https://alltheclouds.com.au/api/Products";
            // Add API request HTTP headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("api-key", "API-DJTRTIJCPRXKA2R");

            var productList = (List<Product>) apiI.CallAPI(apiURL, headers);

            return Json(productList);
        }
    }
}