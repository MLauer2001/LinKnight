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
    public class utHelm
    {
        [TestMethod]
        public void LoadTest()
        {
            Task.Run(async () =>
            {
                List<Helm> helms = (List<Helm>)await HelmManager.Load();
                Assert.AreEqual(4, helms.ToList().Count);
            }).GetAwaiter().GetResult();
        }
    }
}