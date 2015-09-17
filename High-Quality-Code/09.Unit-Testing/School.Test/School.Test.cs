using System;
using StudentSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace School2.Test
{
    [TestClass]
    public class TestSchool
    {
        static Course course;
        static School PMG; 
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            course = new Course("Computer science", new List<Student>() { new Student("Selio Kodo", 89213) });

                PMG = new School("PMG", new List<Course>() 
                {new Course("Computer Science", new List<Student>()
                {new Student("Selim Kerkar", 81207),
                new Student("Momchil Yordanov",81175),
                new Student("Feridore Dore",81654)}),
                new Course("Software engeneering",new List<Student>()
                {new Student("Gadimo Beichev",81176),
                new Student("Vektor Vrabchev",86234),
                new Student("Matias Kurior",81112)})});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_TestIncorrectStudentID()
        {
            Student newStudent = new Student("Kolio", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_TestIncorrectName()
        {
            Student newStudent=new Student(String.Empty,81175);
        }

        [TestMethod]
        public void Student_ConstructorCorrectTest()
        {
            Student student = new Student("Momchil Yordanov", 81175);

            Assert.AreEqual("Momchil Yordanov", student.Name);
            Assert.AreEqual(81175, student.StudentID);
        }

        [TestMethod]
        public void Course_ConstructorTest()
        {
            Assert.AreEqual("Computer science", course.Name);
            Assert.IsTrue(course.StudentClass is List<Student>);
        }

        [TestMethod]
        public void Course_TestAddStudent()
        {
            Student student = new Student("Selim Kerkar", 81914);
            course.AddStudent(student);
        
            Assert.IsTrue(course.StudentClass.Contains(student));
        }

        [TestMethod]
        public void Course_TestReomveStudentWorkCorrectly()
        {
            Student student = new Student("Selio Kodo", 89213);
            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.IsTrue(!course.StudentClass.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_TestRemoveElementsThatNotConatin()
        {
            course.RemoveStudent(new Student("Bai spiro", 12331));
        }

        [TestMethod]
        public void School_TestConstructor()
        {
            Assert.AreEqual("PMG", PMG.Name);
            Assert.IsTrue(PMG.CourseList is List<Course>);
        }
    }
}
