using ChallengeOneRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOneUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddNNewMenuItem_ShouldGetCorrectBoolean()
        {
            Menu menu = new Menu();
            MenuRepo menuRepo = new MenuRepo();

            bool addResult = menuRepo.AddNewMenuItem(menu);
            Assert.IsTrue(addResult);
        }


        private MenuRepo _menuRepoTest;
        private Menu _menuTest;
        public List<string> ingredients = new List<string>();
        [TestInitialize]
        public void Arrange()
        {
            _menuRepoTest = new MenuRepo();

            _menuTest = new Menu(1, "Hummus", "tasty like crazy", 3.99, new List<string>{"Chickepeas"});

            _menuRepoTest.AddNewMenuItem(_menuTest);
        }

        [TestMethod]
        public void GetMealByNumber_ShouldBeCorrect()
        {
            Menu menuTest = _menuRepoTest.GetMealByNumber(1);
            Assert.AreEqual(_menuTest, menuTest);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            Menu menu = _menuRepoTest.GetMealByNumber(1);

            bool removeResult = _menuRepoTest.DeleteMenuItem(1);

            Assert.IsTrue(removeResult);
        }
    }
}
