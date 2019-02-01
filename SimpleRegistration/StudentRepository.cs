using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRegistration
{
    public class StudentRepository : Repository<Student>
    {
        private static StudentRepository _instance;
        public static StudentRepository GetInstance()
        {
            if (_instance == null) _instance = new StudentRepository();
            return _instance;
        }

        private StudentRepository()
        {
            var student = new Student(_nextId++);
            Add(new Student(_nextId++));
        }

        internal List<Student> GetAll() => _entities.Values.ToList();
    }
}
