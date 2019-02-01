using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRegistration
{
    public class Course : Entity
    {
        internal Course(int id, string name)
        {
            Id = id;
            Name = name;
            EnrolledStudents = new List<Student>();
        }
        public string Name { get; private set; }
        public List<Student> EnrolledStudents { get; private set; }
    }
}
