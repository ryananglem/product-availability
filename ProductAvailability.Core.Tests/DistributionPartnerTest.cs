using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductAvailability.Core;
using System;

namespace ProductAvailability.Core.Tests
{
    [TestClass]
    public class DistributionPartnerTest
    {
        [TestMethod]
        public void should_construct_distribution_partner()
        {
            // arrange
            var result = new DistributionPartner("partner", "usage");

            // assert
            Assert.IsNotNull(result);

        }
    }
}
