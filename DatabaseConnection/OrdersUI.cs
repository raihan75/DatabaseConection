using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DatabaseConnection.BLL;

namespace DatabaseConnection
{
    public partial class OrdersUI : Form
    {
        OrderManager _orderManager = new OrderManager();
        public OrdersUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            bool isExecute =  _orderManager.Add(customerNameTextBox.Text, itemNameTextBox.Text, Convert.ToInt32(quantityTextBox.Text),Convert.ToDouble(totalPriceTextBox.Text));
            if (isExecute)
            {
                MessageBox.Show("Saved!!");
            }
            else
            {
                MessageBox.Show("Not Saved!!");
            }
            DataTable showData = _orderManager.ShowAll();
            showDataGridView.DataSource = showData;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            DataTable showData = _orderManager.ShowAll();
            if (showData.Rows.Count > 1)
            {
                showDataGridView.DataSource = showData;
            }
            else
            {
                MessageBox.Show("No Data Found!!!!");
            }
        }

        

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("id can not be empty");
                return;
            }
            bool DeleteDone = _orderManager.DeleteOrder(Convert.ToInt32(idTextBox.Text));
            if (DeleteDone)
            {
                MessageBox.Show("Order Deleted!!!!");
            }
            else
            {
                MessageBox.Show("Order Not Deleted!!!!");
            }
            DataTable showData = _orderManager.ShowAll();
            showDataGridView.DataSource = showData;
        }

       

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("id can not be empty");
                return;
            }

            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("Customer Name Cannot be empty");
                return;
            }

            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("Item Name Cannot be empty");
                return;
            }

            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity Cannot be empty");
                return;
            }

            if (String.IsNullOrEmpty(totalPriceTextBox.Text))
            {
                MessageBox.Show("Total Price Cannot be empty");
                return;
            }

            if (_orderManager.UpdateOrder(Convert.ToInt32(idTextBox.Text), customerNameTextBox.Text, itemNameTextBox.Text, Convert.ToInt32(quantityTextBox.Text), Convert.ToDouble(totalPriceTextBox.Text)))
            {
                MessageBox.Show("Order Updated");
            }
            else
            {
                MessageBox.Show("Order Not Updated");
            }
            DataTable showData = _orderManager.ShowAll();
            showDataGridView.DataSource = showData;
        }

        

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataTable showData = _orderManager.SearchCustomer(customerNameTextBox.Text);
            if (showData.Rows.Count > 1)
            {
                showDataGridView.DataSource = showData;
            }
            else
            {
                MessageBox.Show("No Data Found!!!!");
            }
        }

        
    }
}
