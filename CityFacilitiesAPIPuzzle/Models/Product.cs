using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityFacilitiesAPIPuzzle.Models
{
    public class Product
    {
        private double _unitPrice = 0;

        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                // Mark-up product display price by 20%
                UnitPriceWithMarkup = Math.Round(value * 1.2, 2);
            }
        }
        public double UnitPriceWithMarkup { get; set; } = 0;
        public int? MaximumQuantity { get; set; }
    }
}