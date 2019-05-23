using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        //get student that is in the data test
        public void GetExistingStudent()
        {
            var aStudent=Repository.GetStudent(1);
            Assert.AreEqual(1, aStudent.Id);
        }

        [TestMethod]
        //get student that is not in the data test
        public void GetNoExistingStudent()
        {
            var aStudent = Repository.GetStudent(5);
            Assert.AreEqual(null, aStudent);
        }

        [TestMethod]
        //get Diploma that is in the data test
        public void GetExistingDiploma()
        {
            var aDiploma = Repository.GetDiploma(1);
            Assert.AreEqual(1, aDiploma.Id);
        }

        [TestMethod]
        //get diploma that is not in the data test
        public void GetNoExistingDiploma()
        {
            var aDiploma = Repository.GetDiploma(2);
            Assert.AreEqual(null, aDiploma);
        }

        [TestMethod]
        //get requirement that is in the data test
        public void GetExistingRequirement()
        {
            var aRequirement = Repository.GetRequirement(103);
            Assert.AreEqual(103, aRequirement.Id);
        }

        [TestMethod]
        //get requirement that is not in the data test
        public void GetNoExistingRequirement()
        {
            var aRequirement = Repository.GetRequirement(2);
            Assert.AreEqual(null, aRequirement);
        }
    }
}
