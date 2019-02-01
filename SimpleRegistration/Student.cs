using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRegistration
{
    public class Student : Entity
    {
        public Student(int id)
        {
            Id = id;
            OldCarts = new List<ShoppingCart>();
        }

        public ShoppingCart ActiveShoppingCart { get; internal set; }
        public List<ShoppingCart> OldCarts { get; internal set; }
    }
}
