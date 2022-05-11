using Linknight.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL.Test
{
    [TestClass]
    public class utLobby
    {
        [TestMethod]
        public void LoadTest()
        {
            Task.Run(async () =>
            {
                List<Lobby> lobbys = await LobbyManager.Load();
                Assert.AreEqual(2, lobbys.ToList().Count);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void InsertTest()
        {
            Task.Run(async () =>
            {
                Lobby lobby = new Lobby();


                int results = await LobbyManager.Insert(new Lobby { LobbyKey = "Test" }, true);
                Assert.IsTrue(results > 0);

            });

        }

        [TestMethod]
        public void UpdateTest()
        {

            var task = LobbyManager.Load();
            IEnumerable<Lobby> lobbys = task.Result;
            Lobby lobby = lobbys.FirstOrDefault(c => c.LobbyKey == "Test");
            lobby.LobbyKey = "Tested";
            var results = LobbyManager.Update(lobby, true);
            Assert.IsTrue(results.Result > 0);

        }

        [TestMethod]
        public void DeleteTest()
        {
            Task.Run(async () =>
            {
                var task = LobbyManager.Load();
                IEnumerable<Lobby> lobbys = task.Result;
                Lobby lobby = lobbys.FirstOrDefault(c => c.LobbyKey == "1234");
                int results = await LobbyManager.Delete(lobby.Id, true);
                Assert.IsTrue(results > 0);

            });
        }
    }
}
