using ChallengeTwoRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwoUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddClaimToQueue_ShouldGetCorrectBoolean()
        {
            Claim content = new Claim();
            ClaimRepo repo = new ClaimRepo();

            bool addResult = repo.AddClaimToQueue(content);
            Assert.IsTrue(addResult);
       
        }

        private Claim _contentTest;
        private ClaimRepo _repoTest;

        [TestInitialize]
        public void Arrange()
        {
            _repoTest = new ClaimRepo();

            _contentTest = new Claim(1, ClaimType.Car, "Car crash", 2000, DateTime.Parse("2020, 01, 30"), DateTime.Parse("2020, 02, 27"));

            _repoTest.AddClaimToQueue(_contentTest);
        }

        [TestMethod]
        public void GetClaimByID_ShouldBeCorrect()
        {
            Claim claimTest = _repoTest.GetClaimByID(1);
            Assert.AreEqual(_contentTest, claimTest);
        }


        [TestMethod]
        public void PullClaim_ShouldReturnTrue()
        {
            Claim contentTest = _repoTest.GetClaimByID(1);
            bool pullResult = _repoTest.PullClaim();

            Assert.IsTrue(pullResult);
        }
        

    }
}
