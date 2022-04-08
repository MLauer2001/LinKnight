using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Linq;

namespace Linknight.PL.Test
{
    public class utProfile
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
            Assert.IsTrue(dc.tblProfiles.Count() > 0);
        }

        [Test]
        public void InsertTest()
        {

            tblProfile newrow = new tblProfile();
            newrow.Id = Guid.NewGuid();
            newrow.LobbyId = dc.tblLobbies.FirstOrDefault().Id;
            newrow.ColorId = dc.tblColors.FirstOrDefault().Id;
            newrow.ArmorId = dc.tblArmors.FirstOrDefault().Id;
            newrow.HelmId = dc.tblHelms.FirstOrDefault().Id;
            newrow.Name = "Name";

            dc.tblProfiles.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblProfile existingrow = dc.tblProfiles.FirstOrDefault(c => c.Name == "Testing");

            if (existingrow != null)
            {
                existingrow.Name = "Matt";
                dc.SaveChanges();
            }

            tblProfile row = dc.tblProfiles.FirstOrDefault(c => c.Name == "Matt");

            Assert.AreEqual(existingrow.Name, row.Name);
        }

        [Test]
        public void DeleteTest()
        {

            InsertTest();

            tblProfile row = dc.tblProfiles.FirstOrDefault(c => c.Name == "Testing");

            if (row != null)
            {
                dc.tblProfiles.Remove(row);
                dc.SaveChanges();
            }

            tblProfile deletedrow = dc.tblProfiles.FirstOrDefault(c => c.Name == "Testing");

            Assert.IsNull(deletedrow);
        }
    }
}
