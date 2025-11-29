using System.Collections.Generic;
using LAB_7.Models;

namespace LAB_7.Services
{
    public interface IStudentRepository
    {
        IList<Student> LoadStudents();
        void SaveStudents(IList<Student> students);
    }
}
