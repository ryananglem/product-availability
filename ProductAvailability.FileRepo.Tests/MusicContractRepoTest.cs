using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProductAvailability.Core;
using Moq;

namespace ProductAvailability.FileRepo.Tests
{
    [TestClass]
    public class MusicContractRepoTest
    {      
        [TestMethod]
        public void should_parse_music_contract()
        {
            // Artist | Title | Usages | StartDate | EndDate

            // arrange   
            var mockDateService = new Mock<IDateService>();
            mockDateService.Setup(x => x.ParseLongDateFormat(It.IsAny<string>()))
                .Returns(new DateTime(2012, 2, 1));
            var repo = new MusicContractsFileRepo("test", mockDateService.Object);
            var partners = new List<DistributionPartner> { new DistributionPartner("partner", "streaming") };


            // act
            var result = repo.Parse("Tinie Tempah | Frisky(Live from SoHo) | digital download, streaming | 1st Feb 2012 |", partners);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Tinie Tempah", result.Artist);
            Assert.AreEqual("Frisky(Live from SoHo)", result.Title);
            Assert.AreEqual("partner", result.Usages[0].Partner);
            Assert.AreEqual(new DateTime(2012, 2, 1), result.StartDate);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void should_throw_error_for_incorrect_input()
        {
            // arrange
            var mockDateService = new Mock<IDateService>();
            var repo = new MusicContractsFileRepo("test", mockDateService.Object);
            var list = new List<DistributionPartner>();

            // act
            var result = repo.Parse("|", list);

            // assert
            Assert.Fail("error should occur");
        }

        [TestMethod]
        
        public void should_parse_date()
        {
            // arrange
            var mockDateService = new Mock<IDateService>();
            mockDateService.Setup(x => x.ParseLongDateFormat(It.IsAny<string>()))
                    .Returns(new DateTime(2012, 2, 1));
            var repo = new MusicContractsFileRepo("test", mockDateService.Object);

            // act
            var result = repo.ParseEndDate("1st Jan 2012");

            // assert
            Assert.AreEqual(new DateTime(2012, 2, 1), result);
        }
        [TestMethod]

        public void should_parse_null_date()
        {
            // arrange
            var mockDateService = new Mock<IDateService>();
            var repo = new MusicContractsFileRepo("test", mockDateService.Object);

            // act
            var result = repo.ParseEndDate("");

            // assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]

        public void should_parse_partner_list()
        {
            // arrange
            var mockDateService = new Mock<IDateService>();
            var repo = new MusicContractsFileRepo("test", mockDateService.Object);
            var partnerList = new List < DistributionPartner > { new DistributionPartner("test partner", "test1") };

            // act
            var result = repo.ParsePartnerList("test1, test2", partnerList);

            // assert
            Assert.AreEqual("test partner", result[0].Partner);
        }

    }
}
