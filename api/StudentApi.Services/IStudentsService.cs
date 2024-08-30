using StudentApi.Models.Students;
using System.Collections.Generic;

namespace StudentApi.Services
{
    public interface IStudentsService
    {
        List<Student> GetAllStudents();

        bool AddStudent(Student student);

        // ToDo: Deleting by an ID might be better. What if one student has all the same attributes?
        // Alternatively, we add an ID field to the student.
        bool DeleteStudent(Student student);
    }
}
