using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoodPelletsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib.Tests
{
    [TestClass()]
    public class WoodPelletTests
    {
        private WoodPellet woodPellet = new WoodPellet { Id = 1, Brand = "ExtremePellets", Price = 6495, Quality = 5};
        private WoodPellet woodPelletBrandNull = new WoodPellet { Id = 2, Brand = null, Price = 5995, Quality = 3 };
        private WoodPellet woodPelletBrandToShort = new WoodPellet { Id = 3, Brand = "G", Price = 4999, Quality = 2 };
        private WoodPellet woodPelletPriceNegative = new WoodPellet { Id = 4, Brand = "GreatPellets", Price = -1, Quality = 3 };
        private WoodPellet woodPelletQualityToLow = new WoodPellet { Id = 5, Brand = "GoodPellets", Price = 5695, Quality = 0 };
        private WoodPellet woodPelletQualityToHigh = new WoodPellet { Id = 6, Brand = "GodlyPellets", Price = 8999, Quality = 6 };

        [TestMethod()]
        public void ToStringTest()
        {
            string str = woodPellet.ToString();
            Assert.AreEqual("1 ExtremePellets 6495 5", str);
        }

        [TestMethod()]
        public void ValidateBrandTest()
        {
            woodPellet.ValidateBrand();
            Assert.ThrowsException<ArgumentNullException>(() => woodPelletBrandNull.ValidateBrand());
            Assert.ThrowsException<ArgumentException>(() => woodPelletBrandToShort.ValidateBrand());
        }

        [TestMethod]
        public void ValidatePriceTest()
        {
            woodPellet.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletPriceNegative.ValidatePrice());
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(4)]
        [DataRow(5)]
        public void ValidateQualityTest(int quality)
        {
            woodPellet.Quality = quality;
            woodPellet.ValidateQuality();
        }

        [TestMethod()]
        public void ValidateQualityOutOfRangeTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityToLow.ValidateQuality());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityToHigh.ValidateQuality());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            woodPellet.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => woodPelletBrandNull.ValidateBrand());
            Assert.ThrowsException<ArgumentException>(() => woodPelletBrandToShort.ValidateBrand());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletPriceNegative.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityToLow.ValidateQuality());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => woodPelletQualityToHigh.ValidateQuality());

        }
    }
}