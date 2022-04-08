using Linknight.BL;
using Linknight.BL.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL.Test
{
    [TestClass]
    public class utProfile
    {
        [TestMethod]
        public void LoadTest()
        {
            Task.Run(async () =>
            {
                List<Profile> profiles = (List<Profile>)await ProfileManager.Load();
                Assert.IsTrue(profiles.ToList().Count > 0);
            }).GetAwaiter().GetResult();
        }
        [TestMethod]
        public void InsertTest()
        {
            Task.Run(async () =>
            {
                Profile profile = new Profile();


                int results = ProfileManager.Insert(new Profile { Name = "Test" }, true);
                Assert.IsTrue(results > 0);

            });

        }
        [TestMethod]
        public void UpdateTest()
        {

            var task = ProfileManager.Load();
            IEnumerable<Profile> profiles = task.Result;
            task.Wait();
            Profile profile = profiles.FirstOrDefault(c => c.Name == "Testing");
            profile.Name = "Updated test";
            var results = ProfileManager.Update(profile, true);
            Assert.IsTrue(results.Result > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            Task.Run(async () =>
            {
                var task = await ProfileManager.Load();
                IEnumerable<Profile> profiles = task;
                Profile profile = profiles.FirstOrDefault(c => c.Name == "Testing");
                int results = await ProfileManager.Delete(profile.Id, true);
                Assert.IsTrue(results > 0);

            });
        }
    }
}
