using Microsoft.EntityFrameworkCore;
using StudentsTestCore.Business.interfaces;
using StudentsTestCore.Entities.context;
using StudentsTestCore.Entities.DTOs;
using StudentsTestCore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsTestCore.Business
{
    public class InitialDataProcess : IInitialDataProcess
    {
        private readonly StudentDbContext studentDbContext;

        public InitialDataProcess(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        public async Task<List<StudentResponse>> GetAllStudents()
        {
            var students = await studentDbContext.Students.ToListAsync();
            var resultStudents = new List<StudentResponse>();
            foreach (var student in students)
            {
                resultStudents.Add(new StudentResponse
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    UserName = student.Username,
                    Age = student.Age,
                    Career = student.Career
                });
            }
            return resultStudents;
        }

        public async Task<StudentResponse> GetStudentById(long id)
        {
            var student = await studentDbContext.Students.FindAsync(id);

            var resultStudent = new StudentResponse();
            resultStudent.Id = student.Id;
            resultStudent.FirstName = student.FirstName;
            resultStudent.LastName = student.LastName;
            resultStudent.UserName = student.Username;
            resultStudent.Age = student.Age;
            resultStudent.Career = student.Career;
            return resultStudent;
        }

        public async Task<int> CreateStudent(StudentRequest student)
        {
            Student studentToAdd = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Username = student.UserName,
                Age = student.Age,
                Career = student.Career
            };
            await studentDbContext.Students.AddAsync(studentToAdd);

            return await studentDbContext.SaveChangesAsync();
        }

        public async Task<StudentResponse> UpdateStudent(long id, StudentRequest student)
        {
            var studentInBd = await studentDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);

            if(studentInBd != null){
                studentInBd.FirstName = student.FirstName;
                studentInBd.LastName = student.LastName;
                studentInBd.Username = student.UserName;
                studentInBd.Age = student.Age;
                studentInBd.Career = student.Career;
                await studentDbContext.SaveChangesAsync();

                var result = new StudentResponse
                {
                    Id = id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    UserName = student.UserName,
                    Age = student.Age,
                    Career = student.Career
                };
                return result;
            }
            else
            {
                throw new Exception("No data equals.");
            }
        }

        public async Task<StudentResponse> DeleteStudent(long id)
        {
            var studentInBd = await studentDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (studentInBd != null)
            {
                studentDbContext.Remove(studentInBd);
                await studentDbContext.SaveChangesAsync();

                var result = new StudentResponse
                {
                    Id = id,
                    FirstName = studentInBd.FirstName,
                    LastName = studentInBd.LastName,
                    UserName = studentInBd.Username,
                    Age = studentInBd.Age,
                    Career = studentInBd.Career
                };
                return result;
            }
            else
            {
                throw new Exception("No data equals.");
            }
        }
    }
}