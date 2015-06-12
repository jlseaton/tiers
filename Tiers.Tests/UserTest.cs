using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tiers.Core;
using Tiers.Data;
using Tiers.Domain;
using Tiers.Service;

namespace Tiers.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void GetAllUsers()
        {
            try
            {
                // Uses the service to get a list of all users
                IUserService service = new UserService();
                var users = service.GetAll();
                Assert.IsNotNull(users);
                Assert.IsTrue(users.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetAllUsersByMockRepository()
        {
            try
            {
                // Uses the service to get a list of all users using an injected user/repository
                // This user/repository could come from another database source, or csv, xml, etc
                IUserService service = new UserService(new User(new UserRepository()));
                var users = service.GetAll();
                Assert.IsNotNull(users);
                Assert.IsTrue(users.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetCurrentUserByMockRepository()
        {
            try
            {
                // Bypass the service layer and use the domain layer with an injected user/repository
                // Uses the domain service UserSession instead of the User domain entity
                var session = new Tiers.Domain.Services.UserSession(new User(new UserRepository()));
                var user = session.GetCurrentUser();
                Assert.IsNotNull(user);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
