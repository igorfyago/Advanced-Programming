using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTier.BLL;

namespace NTier.UnitTests
{
    [TestClass]
    public class SecurityLoginShould
    {
        [TestMethod]
        public void ReturnUserIdForValidUser()
        {
            int validUserId = 1;
            string validEmail = "johndoe@somewhere.com";
            string validPassword = "secret";
            var fakeRepository = new FakeUserRepository();
            fakeRepository.ValidUserId = validUserId;
            fakeRepository.ValidEmail = validEmail;
            fakeRepository.ValidPassword = validPassword;

            int result = new Security(fakeRepository).Login(validEmail, validPassword);

            Assert.AreEqual(validUserId, result);
        }
    }

    public class FakeUserRepository : IUserRepository
    {
        public int ValidUserId;
        public string ValidEmail;
        public string ValidPassword;
        public int GetByEmailPassword(string email, string password)
        {
            if (email == ValidEmail && password == ValidPassword)
            {
                return ValidUserId;
            }
            else
            {
                return 0;
            }
        }
    }
}