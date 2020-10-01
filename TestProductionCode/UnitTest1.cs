using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;
using Moq;
using NUnit.Framework;
using ProductionCode.BE;
using ProductionCode.Core.Service;
using ProductionCode.DataAccess;

namespace TestProductionCode
{
    public class Tests
    {

        [Test]
        public void Setup()
        {

            

        }

        [Test]
        public void Test1()
        {
            Mock<IFakeRepository> m = new Mock<IFakeRepository>();

            BERating[] returnValue = { new BERating { Reviewer = 1, Movie = 2, Rate = 3 },
                                       new BERating { Reviewer = 2, Movie = 2, Rate = 4 } };

            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            DataAccess mService = new DataAccess(m.Object);

            int actualResult = mService.GetNumberOfReviewsFromReviewer(2);

            m.Verify(m => m.GetAll(), Times.Once);

            

            Assert.IsTrue(actualResult == 1);
        }
    }
}