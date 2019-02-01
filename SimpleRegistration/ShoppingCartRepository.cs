using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRegistration
{
    public class ShoppingCartRepository : Repository<ShoppingCart>
    {
        private static ShoppingCartRepository _instance;
        public static ShoppingCartRepository GetInstance()
        {
            if (_instance == null) _instance = new ShoppingCartRepository();
            return _instance;
        }

        private ShoppingCartRepository()
        {
        }

        internal ShoppingCart GetNew(int studentId)
        {
            ShoppingCart newCart = new ShoppingCart(_nextId++, studentId);
            Add(newCart);
            return newCart;
        }
    }
}
