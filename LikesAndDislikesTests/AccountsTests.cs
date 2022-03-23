using Microsoft.VisualStudio.TestTools.UnitTesting;
using LikesAndDislikes.Models;

namespace LikesAndDislikesTests
{
    [TestClass]
    public class AccountsTests
    {
        [TestMethod]
        public void Test_CreateUserMethod()
        {
            // arrange
            UserModel userForCreateTest = new("TestUsername1", "TestPassword");
            bool resultForCreateTest;

            // act
            resultForCreateTest = AccountsModel.CreateUser(userForCreateTest);

            // assert
            Assert.IsTrue(resultForCreateTest);
        }

        [TestMethod]
        public void Test_ConfirmUserMethod()
        {
            // arrange
            UserModel userForConfirmTest = new("TestUsername2", "TestPassword");
            bool resultForConfirmTest;

            // act
            AccountsModel.CreateUser(userForConfirmTest);
            resultForConfirmTest = AccountsModel.ConfirmUser(userForConfirmTest);

            // assert
            Assert.IsTrue(resultForConfirmTest);

        }

        [TestMethod]
        public void Test_AddToUserMethod()
        {
            // arrange
            string usernameForAddTest = "TestUsername3";
            ItemModel itemForAddTest = new("Gilla", "Land", "TestCountry");
            bool resultForAddTest;

            // act
            resultForAddTest = AccountsModel.AddToUser(usernameForAddTest, itemForAddTest);

            // assert
            Assert.IsTrue(resultForAddTest);
        }

        [TestMethod]
        public void Test_SearchUserMethod()
        {
            // arrange
            UserModel userForSearchTest = new("TestUsername4", "TestPassword");
            string usernameForSearchTest = userForSearchTest.Username;
            bool resultForSearchTest;

            // act
            AccountsModel.CreateUser(userForSearchTest);
            resultForSearchTest = AccountsModel.SearchUser(usernameForSearchTest);

            // assert
            Assert.IsTrue(resultForSearchTest);
        }

        [TestMethod]
        public void Test_DisplayContentMethod()
        {
            // Arrange
            ItemModel itemForDisplayTest = new("Gilla", "TestAction", "TestOption");
            string usernameForDisplayTest = "TestUsername5";
            ContentModel contentForDisplayTest;

            // Act
            AccountsModel.AddToUser(usernameForDisplayTest, itemForDisplayTest);
            contentForDisplayTest = AccountsModel.DisplayContent(usernameForDisplayTest);

            // Assert
            Assert.IsNotNull(contentForDisplayTest);
        }
    }
}