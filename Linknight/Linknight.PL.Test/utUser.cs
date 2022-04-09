using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.PL.Test
{
    [TestClass]
    public class utUser
    {
        protected LinknightEntities dc;
        protected IDbContextTransaction transaction;

        [TestInitialize]
        public void TestInitialize()
        {
            dc = new LinknightEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc.Dispose();
        }

        [TestMethod]
        public void LoadTest()
        {
            int expected = 0;
            int actual = 0;

            using (LinknightEntities dc = new LinknightEntities())
            {
                actual = dc.tblUsers.Count();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblUser newrow = new tblUser();

            newrow.Id = Guid.NewGuid();
            newrow.Username = "User4";
            newrow.FirstName = "Jane";
            newrow.LastName = "Farmer";
            newrow.Password = "jfarmer";

            dc.tblUsers.Add(newrow);

            int rowsaffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsaffected);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();

            tblUser existingUserRow = (from dt in dc.tblUsers
                                       where dt.Username == "User4"
                                       select dt).FirstOrDefault();

            if (existingUserRow != null)
            {
                existingUserRow.FirstName = "Jannet";
                dc.SaveChanges();
            }

            tblUser updatedUserRow = (from dt in dc.tblUsers
                                      where dt.Username == "User4"
                                      select dt).FirstOrDefault();

            Assert.AreEqual(existingUserRow.FirstName, updatedUserRow.FirstName);

        }

        [TestMethod]
        public void DeleteTest()
        {
            tblUser existingUserRow = (from dt in dc.tblUsers
                                       where dt.Username == "User1"
                                       select dt).FirstOrDefault();

            if (existingUserRow != null)
            {
                dc.tblUsers.Remove(existingUserRow);
                int actual = dc.SaveChanges();
                Assert.AreNotEqual(0, actual);
            }

        }
    }
}
