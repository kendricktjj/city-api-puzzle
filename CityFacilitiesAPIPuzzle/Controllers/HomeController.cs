using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using CityFacilitiesAPIPuzzle.Models;
using Newtonsoft.Json;
using CityFacilitiesAPIPuzzle.Helpers;

namespace CityFacilitiesAPIPuzzle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            APIInterface<Product> apiI = new APIInterface<Product>();
            string apiURL = "https://alltheclouds.com.au/api/Products";
            // Add API request HTTP headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("api-key", "API-DJTRTIJCPRXKA2R");

            var productList = (List<Product>) apiI.CallAPI(apiURL, headers);

            return View(productList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}