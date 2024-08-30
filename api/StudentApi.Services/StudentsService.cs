using StudentApi.Models.Students;
using System;
using System.Collections.Generic;

namespace StudentApi.Services
{
    public class StudentsService : IStudentsService
    {
        public List<Student> students = new List<Student>();

        public StudentsService()
        {
            students.Add(new Student
            {
                FirstName = "Marty",
                LastName = "McFly",
                Email = "back.future@test.com",
                Major = "History",
                AverageGrade = 1.3f
            });

            students.Add(new Student
            {
                FirstName = "Emmett",
                LastName = "Brown",
                Email = "dr.brown@test.com",
                Major = "Physics",
                AverageGrade = 2.1f
            });

            students.Add(new Student
            {
                FirstName = "Biff",
                LastName = "Tannen",
                Email = "biff@test.com",
                Major = "PE",
                AverageGrade = 4.3f
            });
        }

        /// <summary>
        /// Adds a new student to the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool AddStudent(Student student)
        {

            try
            {
                students.Add(student);
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception occured while adding student:", e);
                return false;
            }
        }

        /// <summary>
        /// removes a student from the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool DeleteStudent(Student student)
        {

            var foundStudent = students.Find(s => s.Email == student.Email);
            Console.Write("Deleting Student.");
            return students.Remove(foundStudent);
        }

        /// <summary>
        /// Returns all of the students currently in the system
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
