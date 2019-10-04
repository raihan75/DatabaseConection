using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using DatabaseConnection.Repository;

namespace DatabaseConnection.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(string name, string contact, string address)
        {
            return _customerRepository.Add(name, contact, address);
        }

        public bool IsNameExists(string name)
        {
            return _customerRepository.IsNameExists(name);
        }

        public DataTable ShowAll()
        {
            return _customerRepository.ShowAll();
        }

        public bool DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

        public bool UpdateCustomer(int id, string name, string contact, string address)
        {
            return _customerRepository.UpdateCustomer(id, name, contact, address);
        }

        public DataTable SearchCustomer(string name)
        {
            return _customerRepository.SearchCustomer(name);
        }
    }
}
