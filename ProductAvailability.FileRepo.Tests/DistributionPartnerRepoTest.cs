using System;
using ProductAvailability.FileRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductAvailability.FileRepo.Tests
{
    [TestClass]
    public class DistributionPartnerRepoTest
    {
        [TestMethod]
        public void should_parse_distribution_partner()
        {
            //Partner|Usage

            // arrange
            var partner = "test partner";
            var usage = "test usage";
            var repo = new DistributionPartnerFileRepo("test");

            // act
            var result = repo.Parse($"{partner}|{usage}");

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(partner, result.Partner);
            Assert.AreEqual(usage, result.Usage);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void should_throw_error_for_incorrect_input()
        {
            // arrange
            var partner = "test partner";
            var usage = "test usage";
            var repo = new DistributionPartnerFileRepo("test");

            // act
            var result = repo.Parse($"{partner}|{usage}|");

            // assert
            Assert.Fail("error should occur");
        }

    }
}
