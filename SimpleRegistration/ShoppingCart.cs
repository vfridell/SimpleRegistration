using System.Collections.Generic;

namespace SimpleRegistration
{
    public class ShoppingCart : Entity
    {
        public ShoppingCart(int id, int studentId)
        {
            Id = id;
            Courses = new List<Course>();
            _studentId = studentId;
        }
        private int _studentId;

        public Student Student => StudentRepository.GetInstance().Get(_studentId);
        public List<Course> Courses { get; internal set; }
    }
}