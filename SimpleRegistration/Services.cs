using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRegistration
{
    public static class Services
    {
        public static ShoppingCart GetActiveShoppingCart(int studentId)
        {
            Student student = StudentRepository.GetInstance().Get(studentId);
            if(student.ActiveShoppingCart == null)
            {
                student.ActiveShoppingCart = ShoppingCartRepository.GetInstance().GetNew(studentId);
            }
            return student.ActiveShoppingCart;
        }

        public static void AddCourse(int cartId, int courseId)
        {
            Course course = CourseRepository.GetInstance().Get(courseId);
            ShoppingCart cart = ShoppingCartRepository.GetInstance().Get(cartId);
            if (cart.Courses.Contains(course)) throw new Exception($"Course {courseId} is a duplicate in cart {cartId}");
            cart.Courses.Add(course);
        }

        public static void RemoveCourse(int cartId, int courseId)
        {
            Course course = CourseRepository.GetInstance().Get(courseId);
            ShoppingCart cart = ShoppingCartRepository.GetInstance().Get(cartId);
            if (!cart.Courses.Contains(course)) throw new Exception($"Course {courseId} can't be removed from cart {cartId}");
            cart.Courses.Remove(course);
        }

        public static List<ShoppingCart> GetOldCarts(int studentId)
        {
            Student student = StudentRepository.GetInstance().Get(studentId);
            return student.OldCarts;
        }

        public static List<Course> GetAvailableCourses()
        {
            return CourseRepository.GetInstance().GetAll();
        }

        public static List<Student> GetAllStudents()
        {
            return StudentRepository.GetInstance().GetAll();
        }

        public static RegistrationResult Register(int cartId)
        {
            RegistrationResult result = new RegistrationResult();
            ShoppingCart cart = ShoppingCartRepository.GetInstance().Get(cartId);
            Student student = cart.Student;
            foreach(Course course in cart.Courses)
            {
                if (course.EnrolledStudents.Contains(student))
                {
                    result.Success = false;
                    result.Errors.Add($"Student {cart.Student.Id} already enrolled in course {course.Name}");
                }
            }

            if (result.Success)
            {
                foreach (Course course in cart.Courses)
                {
                    course.EnrolledStudents.Add(cart.Student);
                }
            }
            return result;
        }


    }
}
