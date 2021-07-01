using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MimeTypeMap.List.Test
{
    [TestClass]
    public class MimeTypeMapTest
    {
        [TestMethod]
        public void GetSingleExtensionTest()
        {
            var result1 = MimeTypeMap.GetExtension("application/zip").ToList();
            CollectionAssert.AreEqual(result1, new List<string>() { ".zip" });

            var result2 = MimeTypeMap.GetExtension("application/x-zip-compressed").ToList();
            CollectionAssert.AreEqual(result2, new List<string>() { ".zip" });
        }

        [TestMethod]
        public void GetMultiExtensionTest01()
        {
            var result = MimeTypeMap.GetExtension("audio/wav").ToList();
            CollectionAssert.AreEqual(result, new List<string>() { ".wav", ".wave" });
        }

        [TestMethod]
        public void GetMultiExtensionTest02()
        {
            var result = MimeTypeMap.GetExtension("application/vnd.ms-excel").ToList();
            CollectionAssert.AreEqual(result, new List<string>() { ".slk", ".xla", ".xlc", ".xld", ".xlk", ".xll", ".xlm", ".xls", ".xlt", ".xlw" });
        }

        [TestMethod]
        public void GetExtensionContainTest()
        {
            var result = MimeTypeMap.GetExtension("audio/wav").ToList();
            Assert.AreEqual(true, result.Contains(".wav"));
        }

        [TestMethod]
        public void GetSingleMimeTest()
        {
            var result = MimeTypeMap.GetMimeType("txt").ToList(); ;
            CollectionAssert.AreEqual(result, new List<string>() { "text/plain" });
        }

        [TestMethod]
        public void GetMultiMimeTest()
        {
            var result = MimeTypeMap.GetMimeType("zip").ToList(); ;
            CollectionAssert.AreEqual(result, new List<string>() { "application/zip", "application/octet-stream", "application/x-zip-compressed" });
        }
    }
}
