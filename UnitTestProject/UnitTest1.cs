using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleRegistration;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetShoppingCart()
        {
            ShoppingCart cart = Services.GetActiveShoppingCart(1);
            Assert.IsNotNull(cart);
        }

        [TestMethod]
        public void GetAllCourses()
        {
            var courses = Services.GetAvailableCourses();
            Assert.IsTrue(courses.Any());
        }

        [TestMethod]
        public void AddToCart()
        {
            Course course = Services.GetAvailableCourses().First();
            ShoppingCart cart = Services.GetActiveShoppingCart(1);
            Assert.IsFalse(cart.Courses.Contains(course));
            Services.AddCourse(cart.Id, course.Id);
            Assert.IsTrue(cart.Courses.Contains(course));
        }

        [TestMethod]
        public void RemoveFromCart()
        {
            Services.AddCourse(1, 1);
            Services.GetActiveShoppingCart(1);
           // Assert.IsTrue(cart.Courses.Contains(course));
        }


    }
}
