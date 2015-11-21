using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;
using System.IO;
using System.Threading;

namespace Tests
{
    [TestClass]
    public class CrackShould
    {
        [TestMethod]
        public void SetupLogDirectory()
        {
            var path = @"d:\";
            var filename = "data.log";
            Crack.WriteMode = WriteModeEnum.File;
            Crack.SetLogLocation(path);

            Assert.IsTrue(File.Exists(Path.Combine(path, filename)));
        }

        [TestMethod]
        public void WriteToFile()
        {
            var path = @"d:\";
            var filename = "data.log";
            Crack.WriteMode = WriteModeEnum.File;
            Crack.SetLogLocation(path);
            var toCheck = new FileInfo(Path.Combine(path, filename));

            Assert.IsTrue(toCheck.Length == 0);
            
            Crack.Start();
            Thread.Sleep(100);
            Crack.Stop();
            toCheck.Refresh();
            Assert.IsTrue(toCheck.Length > 0);
        }

        //[TestMethod]
        //public void WriteToWindowsEventLog()
        //{

        //}

        //[TestMethod]
        //public void WriteToInternalMemory()
        //{

        //}
    }
}
