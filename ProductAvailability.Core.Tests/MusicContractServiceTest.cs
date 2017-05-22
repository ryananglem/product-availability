using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ProductAvailability.Core.Tests
{
    [TestClass]
    public class MusicContractServiceTest
    {
        [TestMethod]
        public void should_get_active_contracts()
        {
            // arrange
            var repo = new Mock<IMusicContractsRepo>();
            var dpList = new List<DistributionPartner>
            {
               new DistributionPartner("test", "test")
            };
            repo.Setup(x => x.GetList(It.IsAny<List<DistributionPartner>>()))
                .Returns(new List<MusicContract>
                {
                    new MusicContract("art", "titl", dpList, new DateTime(2017, 01, 01), null)
                });

            var service = new MusicContractService(repo.Object);
            

            // act
            var result = service.GetActiveList(dpList, new DateTime(2017, 03, 01), "test");

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

        }
    }
}
