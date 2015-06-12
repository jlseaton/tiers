using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tiers.Core;
using Tiers.Service;
using Tiers.WebApi;
using Tiers.WebApi.Controllers;

namespace Tiers.WebApi.Tests
{
    [TestClass]
    public class UsersControllerTest
    {
        [TestMethod]
        public void GetAllViaWebApi()
        {
            try
            {
                UserWebApiClient client = new UserWebApiClient();
                var users = client.Get();
                Assert.IsTrue(!String.IsNullOrEmpty(users));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Get()
        {
            // Arrange
            UsersController controller = new UsersController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            UsersController controller = new UsersController();

            // Act
            var result = controller.Get(2);

            // Assert
            Assert.AreEqual(result.Name, "User2");
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            UsersController controller = new UsersController();

            // Act
            HttpResponseMessage result = controller.Post(new UserDTO() 
            { 
                Name = "NewUser", 
                Data = 6.0 
            });

            // Assert
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            UsersController controller = new UsersController();

            // Act
            var updated = controller.Put(5, "UpdatedName");

            // Assert
            Assert.AreEqual(updated.ID, 5);
            Assert.AreEqual(updated.Name, "UpdatedName");
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            UsersController controller = new UsersController();

            // Act
            var removed = controller.Delete(5);

            // Assert
            Assert.IsTrue(removed > 0);
        }
    }
}
