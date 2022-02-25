using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Linq;

namespace Linknight.PL.Test
{
    public class utAdmin
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
            Assert.AreEqual(4, dc.tblAdmins.Count());
        }

        [Test]
        public void InsertTest()
        {

            tblAdmin newrow = new tblAdmin();
            newrow.Id = Guid.NewGuid();
            newrow.FirstName = "Joe";
            newrow.LastName = "Wetzel";
            newrow.UserName = "JWetz";
            newrow.Password = "wetzelj";

            dc.tblAdmins.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblAdmin existingrow = dc.tblAdmins.FirstOrDefault(c => c.FirstName == "Matthew");

            if (existingrow != null)
            {
                existingrow.FirstName = "Matt";
                dc.SaveChanges();
            }

            tblAdmin row = dc.tblAdmins.FirstOrDefault(c => c.FirstName == "Matt");

            Assert.AreEqual(existingrow.FirstName, row.FirstName);
        }

        [Test]
        public void DeleteTest()
        {

            InsertTest();

            tblAdmin row = dc.tblAdmins.FirstOrDefault(c => c.FirstName == "Zach");

            if (row != null)
            {
                dc.tblAdmins.Remove(row);
                dc.SaveChanges();
            }

            tblAdmin deletedrow = dc.tblAdmins.FirstOrDefault(c => c.FirstName == "Zach");

            Assert.IsNull(deletedrow);
        }
    }
}
