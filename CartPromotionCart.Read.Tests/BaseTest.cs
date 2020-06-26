using CartPromotionEngine.Read.Controllers;
using CartPromotionEngine.Service.Read;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartPromotionCart.Read.Tests
{
    public class BaseTest 
    {
        protected CartPromtionEngineController _classUnderTest;
        [TestInitialize]
        public virtual void __Initialize()
        {
            _classUnderTest = new CartPromtionEngineController(new CartPromotionEngineService());
        }
    }
}
