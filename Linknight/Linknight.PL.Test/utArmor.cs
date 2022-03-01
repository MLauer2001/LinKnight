using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Linq;

namespace Linknight.PL.Test
{
    public class utArmor
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
            Assert.AreEqual(4, dc.tblArmors.Count());
        }

        [Test]
        public void InsertTest()
        {

            tblArmor newrow = new tblArmor();
            newrow.Id = -99;
            newrow.ArmorType = "Armor5";

            dc.tblArmors.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblArmor existingrow = dc.tblArmors.FirstOrDefault(c => c.ArmorType == "Armor1.jpg");

            if (existingrow != null)
            {
                existingrow.ArmorType = "Armor";
                dc.SaveChanges();
            }

            tblArmor row = dc.tblArmors.FirstOrDefault(c => c.ArmorType == "Armor");

            Assert.AreEqual(existingrow.ArmorType, row.ArmorType);
        }

        [Test]
        public void DeleteTest()
        {

            InsertTest();

            tblArmor row = dc.tblArmors.FirstOrDefault(c => c.ArmorType == "Armor5");

            if (row != null)
            {
                dc.tblArmors.Remove(row);
                dc.SaveChanges();
            }

            tblArmor deletedrow = dc.tblArmors.FirstOrDefault(c => c.ArmorType == "Armor5");

            Assert.IsNull(deletedrow);
        }
    }
}
