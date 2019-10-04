using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using DatabaseConnection.Repository;

namespace DatabaseConnection.BLL
{
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();

        public bool Add(string name, double price)
        {
            return _itemRepository.Add(name, price);
        }

        public bool IsNameExists(string name)
        {
            return _itemRepository.IsNameExists(name);
        }

        public DataTable ShowAll()
        {
            return _itemRepository.ShowAll();
        }

        public bool DeleteItem(int id)
        {
            return _itemRepository.DeleteItem(id);
        }

        public bool UpdateItem(int id, string name, double price)
        {
            return _itemRepository.UpdateItem(id, name, price);
        }

        public DataTable SearchItem(string name)
        {
            return _itemRepository.SearchItem(name);
        }
    }
}
