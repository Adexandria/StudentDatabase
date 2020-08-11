using StudentDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDatabase.Services
{
   public interface IData
    { 
        public IEnumerable<Student> GetStudents { get; }
        
        public Task<Student> GetStudentsById(Guid Id);
        public IEnumerable<Student> GetStudentsByName(string name);
        public IEnumerable<Student> GetStudentsByGender(string name);
        public IEnumerable<Student> GetStudentsByState(string name);
        public IEnumerable<Student>GetStudentsByClass(string classes);
        public Task<Student> Add(Student student);
        public Task<int> Save();
        public void UpDate(Student student);
        public Task<int> Delete(Guid id);
       

    }
}
