using ChallengeThreeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddNewBadge_ShouldGetCorrectBoolean()
        {
            Badge badgeContentTest = new Badge();
            BadgeRepo badgeRepositoryTest = new BadgeRepo();

            bool addResult = badgeRepositoryTest.AddNewBadge(badgeContentTest);

            Assert.IsTrue(addResult);
        }


        private BadgeRepo _badgeRepoTest;
        private Badge _badgeTest;


        [TestInitialize]
        public void Arrange()
        {
            _badgeRepoTest = new BadgeRepo();

            _badgeTest = new Badge(1, new List<string> {"A3"}  );

            _badgeRepoTest.AddNewBadge(_badgeTest);
        }
        [TestMethod]
        public void GetBadgeByKey_ShouldBeCorrect()
        {
            Badge badgeContentTest = _badgeRepoTest.GetBadgeByKey(1);
            Assert.AreEqual(_badgeTest, badgeContentTest);
        }

        [TestMethod]
        public void UpdateBadgeByKey_ShouldReturnTrue()
        {
            Badge newBadgeContentTest = new Badge(1, new List<string>{ "B5"});
            bool updatedResult = _badgeRepoTest.UpdateBadgeByKey(1, newBadgeContentTest);
        }
    }
}
