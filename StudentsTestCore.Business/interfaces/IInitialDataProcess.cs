using StudentsTestCore.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsTestCore.Business.interfaces
{
    public interface IInitialDataProcess
    {
        Task<List<StudentResponse>> GetAllStudents();
        Task<StudentResponse> GetStudentById(long id);
        Task<int> CreateStudent(StudentRequest student);
        Task<StudentResponse> UpdateStudent(long id, StudentRequest student);
        Task<StudentResponse> DeleteStudent(long id);
    }
}