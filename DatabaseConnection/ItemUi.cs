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
    public partial class ItemUi : Form
    {
        ItemManager _ItemManager = new ItemManager();
        public ItemUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (_ItemManager.IsNameExists(nameTextBox.Text))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists!!!");
                return;
            }
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not Be Empty!!!");
                return;
            }

            bool isExecute = _ItemManager.Add(nameTextBox.Text,Convert.ToDouble(priceTextBox.Text));
            if (isExecute)
            {
                MessageBox.Show("Saved!!");
            }
            else
            {
                MessageBox.Show("Not Saved!!");
            }
            DataTable showData = _ItemManager.ShowAll();
            showDataGridView.DataSource = showData;
        }


        private void showButton_Click(object sender, EventArgs e)
        {
            DataTable showData = _ItemManager.ShowAll();
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
            bool DeleteDone = _ItemManager.DeleteItem(Convert.ToInt32(idTextBox.Text));
            if (DeleteDone)
            {
                MessageBox.Show("Item Deleted!!!!");
            }
            else
            {
                MessageBox.Show("Item Not Deleted!!!!");
            }
            DataTable showData = _ItemManager.ShowAll();
            showDataGridView.DataSource = showData;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("id can not be empty");
                return;
            }

            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Cannot be empty");
            }

            if(_ItemManager.UpdateItem(Convert.ToInt32(idTextBox.Text), nameTextBox.Text, Convert.ToDouble(priceTextBox.Text)))
            {
                MessageBox.Show("Item Updated");
            }
            else
            {
                MessageBox.Show("Item Not Updated");
            }
            DataTable showData = _ItemManager.ShowAll();
            showDataGridView.DataSource = showData;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataTable showData = _ItemManager.SearchItem(nameTextBox.Text);

            if (showData.Rows.Count > 0)
            {
                showDataGridView.DataSource = showData;
            }
            else
            {
                MessageBox.Show("No Data Matched!!!");
            }
        }

    }
}
