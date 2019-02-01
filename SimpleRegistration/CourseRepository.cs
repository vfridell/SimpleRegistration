using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRegistration
{
    public class CourseRepository : Repository<Course>
    {
        private static CourseRepository _instance;
        public static CourseRepository GetInstance()
        {
            if (_instance == null) _instance = new CourseRepository();
            return _instance;
        }

        private CourseRepository()
        {
            Add(new Course(_nextId++, "MAT101"));
            Add(new Course(_nextId++, "ENG101"));
            Add(new Course(_nextId++, "MAT201"));
            Add(new Course(_nextId++, "MAT301"));
            Add(new Course(_nextId++, "PHI101"));
            Add(new Course(_nextId++, "PHI102"));
        }

        public List<Course> GetAll() => _entities.Values.ToList();
    }
}
