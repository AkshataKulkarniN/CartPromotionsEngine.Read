using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices.ComTypes;

namespace CartPromotionCart.Read.Tests
{
    [TestClass]
    public class CartPromotionApiTests : BaseTest
    {
        string cartItems = "";
        string promotionCode = "";

        [TestMethod]
        public void SenarioATest()
        {
            cartItems = "ABC";
            promotionCode = "";
            var result = _classUnderTest.GetTotalValueOFCart(cartItems, promotionCode);
            Assert.IsNotNull(result);
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void SenarioBTest()
        {
            cartItems = "ABCAAAABBBB";
            promotionCode = "3AFor130";
            var result = _classUnderTest.GetTotalValueOFCart(cartItems, promotionCode);
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result);
        }

        [TestMethod]
        public void SenarioCTest()
        {
            cartItems = "AAABBBBBCD";
            promotionCode = "CDFor30";
            var result = _classUnderTest.GetTotalValueOFCart(cartItems, promotionCode);
            Assert.IsNotNull(result);
            Assert.AreEqual(330, result);
        }

    }
}
