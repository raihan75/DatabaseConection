using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Repository
{
    public class OrderRepository
    {
        public bool Add(string cname, string iname, int quantity, double totalPrice)
        {
            bool isAdded = false;
            try
            {
                //connection
                string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(conn);

                //command
                string insert = @"INSERT INTO Orders (CustomerName, ItemName, Quantity, TotalPrice) VALUES ('" + cname + "','" + iname + "', " + quantity + "," + totalPrice + ")";
                SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);

                //open
                sqlConnection.Open();

                //execution
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    isAdded = true;
                }

                //close
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return isAdded;
        }

        public DataTable ShowAll()
        {
            //connection
            string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);

            //command
            string show = @"SELECT * FROM Orders";
            SqlCommand sqlCommand = new SqlCommand(show, sqlConnection);

            //open
            sqlConnection.Open();

            //execution
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return dataTable;
            }
            else
            {
                //showDataGridView.DataSource = null;
                //MessageBox.Show("No Data Found");
            }

            //close
            sqlConnection.Close();
            return dataTable;
        }

        public bool DeleteOrder(int id)
        {
            bool isDeleted = false;
            try
            {
                //connection
                string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(conn);

                //command
                string deleted = @"DELETE FROM Orders WHERE id = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(deleted, sqlConnection);

                //open
                sqlConnection.Open();

                //execution
                int delete = sqlCommand.ExecuteNonQuery();
                if (delete > 0)
                {
                    isDeleted = true;
                }

                //close
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return isDeleted;
        }

        public bool UpdateOrder(int id, string cname, string iname, int quantity, double totalPrice)
        {
            try
            {
                //connection
                string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(conn);

                //command
                string update = @"UPDATE Orders SET CustomerName = '" + cname + "', ItemName = '" + iname + "', Quantity = " + quantity + ", TotalPrice= " + totalPrice + " WHERE Id = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(update, sqlConnection);

                //open
                sqlConnection.Open();

                //execution
                int updated = sqlCommand.ExecuteNonQuery();
                if (updated > 0)
                {
                    return true;
                }


                //close
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return false;
        }

        public DataTable SearchCustomer(string cname)
        {
            //connection
            string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);

            //command
            string search = @"SELECT * FROM Orders WHERE CustomerName = '" + cname + "'";
            SqlCommand sqlCommand = new SqlCommand(search, sqlConnection);

            //open
            sqlConnection.Open();

            //execution
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return dataTable;
            }
            else
            {
                //MessageBox.Show("No Data Matched!!!");
            }

            //close
            sqlConnection.Close();
            return dataTable;
        }
    }
}
