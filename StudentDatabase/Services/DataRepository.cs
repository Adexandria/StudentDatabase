using Microsoft.EntityFrameworkCore;
using StudentDatabase.DbContexts;
using StudentDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDatabase.Services
{
    public class DataRepository : IData
    {
        private readonly StudentsDb db;
        public DataRepository(StudentsDb db)
        {
            this.db = db;
        }
        public IEnumerable<Student> GetStudents
        {
            get
            {
                return db.Students.OrderBy(r => r.Id);
            }
        }

        public async Task<Student> Add(Student student)
        {
            if(student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            student.Id = Guid.NewGuid();
           await db.AddAsync(student);
            return student;
        }

        public async Task<int> Delete(Guid id)
        {
            var query = await GetStudentsById(id);
            if(query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            db.Students.Remove(query);
            return await db.SaveChangesAsync();
        }

       

        public IEnumerable<Student> GetStudentsByClass(string classes)
            
        {
            if (classes == null)
            {
                throw new ArgumentNullException(nameof(classes));
            }
            return db.Students.Where(r => classes.Contains(r.Classes.ToString())).AsNoTracking().OrderBy(r => r.Id).ToList();
        }

        public IEnumerable<Student> GetStudentsByGender(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            return db.Students.Where(r => name.Contains(r.Gender.ToString())).AsNoTracking().OrderBy(r => r.Id).ToList();
        }

        public async Task<Student> GetStudentsById(Guid Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            return  await db.Students.Where(r => r.Id == Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public IEnumerable<Student> GetStudentById(IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }
            return db.Students.Where(r => ids.Contains(r.Id)).AsNoTracking().OrderBy(r => r.Id).ToList();
        }

        public IEnumerable<Student> GetStudentsByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            return db.Students.Where(r => r.FirstName == name||r.MiddleName== name||r.LastName==name).AsNoTracking().OrderBy(r => r.Id);
        }

        public IEnumerable<Student> GetStudentsByState(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            return db.Students.Where(r => name.Contains(r.State.ToString())).AsNoTracking().OrderBy(r => r.Id).ToList();
        }

        public  async Task<int> Save()
        {
            return await db.SaveChangesAsync();
        }

        public Student Update(Student student)
        {
            var updatedEntity = db.Students.Attach(student);
            updatedEntity.State = EntityState.Modified;
            return student;

        }
    }
}
