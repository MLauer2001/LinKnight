using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Linq;

namespace Linknight.PL.Test
{
    public class utLobby
    {
        protected LinknightEntities dc;
        protected IDbContextTransaction transaction;

        [SetUp]
        public void Setup()
        {
            dc = new LinknightEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            transaction.Rollback();
            transaction = null;
        }

        [Test]
        public void LoadTest()
        {
            Assert.AreEqual(2, dc.tblLobbies.Count());
        }

        [Test]
        public void InsertTest()
        {

            tblLobby newrow = new tblLobby();
            newrow.Id = Guid.NewGuid();
            newrow.LobbyKey = "Tester";

            dc.tblLobbies.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblLobby existingrow = dc.tblLobbies.FirstOrDefault(c => c.LobbyKey == "Test");

            if (existingrow != null)
            {
                existingrow.LobbyKey = "Tested";
                dc.SaveChanges();
            }

            tblLobby row = dc.tblLobbies.FirstOrDefault(c => c.LobbyKey == "Tested");

            Assert.AreEqual(existingrow.LobbyKey, row.LobbyKey);
        }

        [Test]
        public void DeleteTest()
        {

            InsertTest();

            tblLobby row = dc.tblLobbies.FirstOrDefault(c => c.LobbyKey == "Tester");

            if (row != null)
            {
                dc.tblLobbies.Remove(row);
                dc.SaveChanges();
            }

            tblLobby deletedrow = dc.tblLobbies.FirstOrDefault(c => c.LobbyKey == "Tester");

            Assert.IsNull(deletedrow);
        }
    }
}
