using Linknight.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL.Test
{
    [TestClass()]
    public class utUser
    {
        [TestInitialize]
        public void TestInitialize()
        {
            UserManager.Seed();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            UserManager.DeleteAll();
        }

        [TestMethod]
        public void LoadTest()
        {
            Task.Run(async () =>
            {
                List<User> users = (List<User>)UserManager.Load();
                Assert.AreEqual(3, users.ToList().Count);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void InsertTest()
        {
            User user = new User();
            user.Username = "User4";
            user.FirstName = "Jane";
            user.LastName = "Farmer";
            user.Password = "jfarmer";
            int result = UserManager.Insert(user, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var task = UserManager.Load();
            IEnumerable<User> users = task;
            User user = users.FirstOrDefault(u => u.Username == "User1");
            user.Username = "User-99";
            var results = UserManager.Update(user, true);
            Assert.IsTrue(results.Result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Task.Run(async () =>
            {
                var task = UserManager.Load();
                IEnumerable<User> users = task;
                User user = users.FirstOrDefault(u => u.Username == "User1");
                int results = await LobbyManager.Delete(user.Id, true);
                Assert.IsTrue(results > 0);
            });
        }

        [TestMethod()]
        public void LoginTestSuccess()
        {
            Assert.IsTrue(UserManager.Login(new Models.User("User1", "jsmith")));
        }

        [TestMethod()]
        public void LoginTestBadPassword()
        {
            try
            {
                UserManager.Login(new Models.User("User1", "jsmit"));
                Assert.Fail();
            }
            catch (LoginFailureException)
            {
                // Desired result.
                Assert.IsTrue(true);
            }

            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
