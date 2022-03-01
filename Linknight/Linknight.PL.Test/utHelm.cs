using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Linq;

namespace Linknight.PL.Test
{
    public class utHelm
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
            Assert.AreEqual(4, dc.tblHelms.Count());
        }

        [Test]
        public void InsertTest()
        {

            tblHelm newrow = new tblHelm();
            newrow.Id = -99;
            newrow.HelmType = "Helm5";

            dc.tblHelms.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblHelm existingrow = dc.tblHelms.FirstOrDefault(c => c.HelmType == "Helm1.jpg");

            if (existingrow != null)
            {
                existingrow.HelmType = "Helm";
                dc.SaveChanges();
            }

            tblHelm row = dc.tblHelms.FirstOrDefault(c => c.HelmType == "Helm");

            Assert.AreEqual(existingrow.HelmType, row.HelmType);
        }

        [Test]
        public void DeleteTest()
        {

            InsertTest();

            tblHelm row = dc.tblHelms.FirstOrDefault(c => c.HelmType == "Helm5");

            if (row != null)
            {
                dc.tblHelms.Remove(row);
                dc.SaveChanges();
            }

            tblHelm deletedrow = dc.tblHelms.FirstOrDefault(c => c.HelmType == "Helm5");

            Assert.IsNull(deletedrow);
        }
    }
}
