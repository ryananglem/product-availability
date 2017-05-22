using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductAvailability.Core;
using Moq;
using System.Collections.Generic;

namespace ProductAvailability.Tests
{
    [TestClass]
    public class BootstrapperTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.Exception), "invalid arguments. please supply <partner name> and <date> in the format d-nth MMM yyyy")]
        public void should_check_for_args()
        {
            // arrange
            var consoleMock = new Mock<IConsoleWriter>();
            var dpServiceMock = new Mock<IDistributionPartnerService>();
            var dateServiceMock = new Mock<IDateService>();
            var mcServiceMock = new Mock<IMusicContractService>();
            var main = new Bootstrapper(consoleMock.Object, dpServiceMock.Object, dateServiceMock.Object, mcServiceMock.Object);                        

            var args = new string[0];

            // act
            main.Start(args);

            // assert
            Assert.Fail("should fail");
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception), "please supply a valid partner")]
        public void should_check_for_partners()
        {
            // arrange
            var consoleMock = new Mock<IConsoleWriter>();
            var dpServiceMock = new Mock<IDistributionPartnerService>();
            dpServiceMock.Setup(x => x.GetList()).Returns(new List<DistributionPartner> { new DistributionPartner("x", "y") });
            var dateServiceMock = new Mock<IDateService>();
            var mcServiceMock = new Mock<IMusicContractService>();
            var main = new Bootstrapper(consoleMock.Object, dpServiceMock.Object, dateServiceMock.Object, mcServiceMock.Object);

            string[] args = { "test" };

            // act
            main.Start(args);

            // assert
            Assert.Fail("should fail");
        }


    }
}
