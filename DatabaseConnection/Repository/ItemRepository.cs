using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Repository
{
    public class ItemRepository
    {
        public bool Add(string name, double price)
        {
            bool isAdded = false;
            try
            {
                //connection
                string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(conn);

                //command
                string insert = @"INSERT INTO Items (Name, Price) VALUES ('" + name + "'," + price + ")";
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

        public bool IsNameExists(string name)
        {
            bool exists = false;

            try
            {
                //connection
                string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(conn);

                //command
                string search = @"SELECT * FROM Items WHERE Name = '" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(search, sqlConnection);

                //open
                sqlConnection.Open();

                //execution
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }

                //close
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }

            return exists;
        }

        public DataTable ShowAll()
        {
            //connection
            string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);

            //command
            string show = @"SELECT * FROM Items";
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
                //MessageBox.Show("No Data Found");
            }


            //close
            sqlConnection.Close();
            return dataTable;
        }

        public bool DeleteItem(int id)
        {
            bool isDeleted = false;
            try
            {
                //connection
                string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(conn);

                //command
                string show = @"DELETE FROM Items WHERE id = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(show, sqlConnection);

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

        public bool UpdateItem(int id, string name, double price)
        {
            try
            {
                //connection
                string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(conn);

                //command
                string update = @"UPDATE Items SET Name = '" + name + "', Price = " + price + " WHERE Id = " + id + "";
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

        public DataTable SearchItem(string name)
        {
            //connection
            string conn = @"Server=DESKTOP-QMNU0HM\RAIHANPLAYGROUND; DataBase=CoffeeShop; integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);

            //command
            string search = @"SELECT * FROM Items WHERE Name = '" + name + "'";
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
