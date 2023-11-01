using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib
{
    public class WoodPellet
    {
        public int Id { get; set; } // Must be number
        public string Brand { get; set; } // minimum 2 char
        public int Price { get; set; } //must be positiv
        public int Quality { get; set; } //Number between 1-5

        public WoodPellet()
        {

        }

        public void ValidateBrand()
        {
            if (Brand == null)
            {
                throw new ArgumentNullException(nameof(Brand), "Brand Cannot be null");
            }
            if (Brand.Length < 2)
            {
                throw new ArgumentException("Brand must be at least 2 characters long", nameof(Brand));
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Price must be a positiv number");
            }
        }

        public void ValidateQuality()
        {
            if (Quality < 1 || Quality > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(Quality), "Quality must be between 1 & 5");
            }
        }

        public void Validate()
        {
            ValidateBrand();
            ValidatePrice();
            ValidateQuality();
        }

        public override string ToString()
        {
            return $"{Id} {Brand} {Price} {Quality}";
        }

    }
}
