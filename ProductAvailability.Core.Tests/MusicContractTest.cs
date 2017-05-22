using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductAvailability.Core.Tests
{
    [TestClass]
    public class MusicContractTest
    {
        [TestMethod]
        public void should_construct_music_contract()
        {
            // arrange
            var result = new MusicContract("artist", "title", new System.Collections.Generic.List<DistributionPartner>(), DateTime.Now, DateTime.Now);

            // assert
            Assert.IsNotNull(result);
        }
    }
}
