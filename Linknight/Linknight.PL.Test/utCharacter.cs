using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;
using System.Linq;

namespace Linknight.PL.Test
{
    public class utCharacter
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
            Assert.AreEqual(4, dc.tblCharacters.Count());
        }

        [Test]
        public void InsertTest()
        {

            tblCharacter newrow = new tblCharacter();
            newrow.Id = -99;
            newrow.HelmId = dc.tblHelms.FirstOrDefault().Id;
            newrow.ArmorId = dc.tblArmors.FirstOrDefault().Id;
            newrow.Color = "Brown";

            dc.tblCharacters.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblCharacter existingrow = dc.tblCharacters.FirstOrDefault(c => c.Color == "Blue");

            if (existingrow != null)
            {
                existingrow.Color = "Brown";
                dc.SaveChanges();
            }

            tblCharacter row = dc.tblCharacters.FirstOrDefault(c => c.Color == "Brown");

            Assert.AreEqual(existingrow.Color, row.Color);
        }

        [Test]
        public void DeleteTest()
        {

            InsertTest();

            tblCharacter row = dc.tblCharacters.FirstOrDefault(c => c.Color == "Brown");

            if (row != null)
            {
                dc.tblCharacters.Remove(row);
                dc.SaveChanges();
            }

            tblCharacter deletedrow = dc.tblCharacters.FirstOrDefault(c => c.Color == "Brown");

            Assert.IsNull(deletedrow);
        }
    }
}
