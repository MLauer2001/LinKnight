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

        [TestMethod()]
        public void InsertTest()
        {

        }
    }
}
