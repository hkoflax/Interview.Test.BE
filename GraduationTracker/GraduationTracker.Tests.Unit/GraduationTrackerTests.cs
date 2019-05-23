using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        GraduationTracker tracker = new GraduationTracker();

        //Moved test data to repository to avoid repitition in other Test methods
        readonly Diploma diploma = Repository.GetDiplomaTestData();
        readonly Student[] students = Repository.GetAllStudentTestData();

        [TestMethod]
        //Test to check if the test data contains any graduate student;
        public void TestHasgraduate()
        {
            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            Assert.IsTrue(graduated.Any(x => x.Item1 == true));
        }

        [TestMethod]
        //Test to check if the test data contains any student that has all 4 credits;
        public void TestHasCredits()
        {
            var credits = new List<Tuple<bool, Student>>();

            foreach (var student in students)
            {
                credits.Add(tracker.HasCredit(diploma, student));
            }

            Assert.IsTrue(credits.Any(x => x.Item1 == true));
        }

        [TestMethod]
        //Test to check if the test data contains any student that is not graduate;
        public void TestHasNograduate()
        {
            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            Assert.IsTrue(graduated.Any(x => x.Item1 == false));
        }

        [TestMethod]
        //Test to check if the test data contains any student that has no credit or all 4;
        public void TestHasNoCredits()
        {
            var credits = new List<Tuple<bool, Student>>();

            foreach (var student in students)
            {
                credits.Add(tracker.HasCredit(diploma, student));
            }

            Assert.IsTrue(credits.Any(x => x.Item1 == false));
        }
    }
}
