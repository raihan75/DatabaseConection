using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using DatabaseConnection.Repository;

namespace DatabaseConnection.BLL
{
    class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        public bool Add(string cname, string iname, int quantity, double totalPrice)
        {
            return _orderRepository.Add(cname, iname, quantity, totalPrice);
        }

        public DataTable ShowAll()
        {
            return _orderRepository.ShowAll();
        }

        public bool DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }

        public bool UpdateOrder(int id, string cname, string iname, int quantity, double totalPrice)
        {
            return _orderRepository.UpdateOrder(id, cname, iname, quantity, totalPrice);
        }

        public DataTable SearchCustomer(string cname)
        {
            return _orderRepository.SearchCustomer(cname);
        }
    }
}
