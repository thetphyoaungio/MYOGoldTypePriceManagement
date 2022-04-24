using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MYOGoldTypePriceManagement
{
    class DBAndTblsInitializer
    {
        private static string dbConn = "Data Source=.\\SQLEXPRESS;Initial Catalog = master; Integrated Security = True";
        private static string tablesConn = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbMYOGoldShop;Integrated Security=True";

        private const string CreateDBSql = "CREATE DATABASE dbMYOGoldShop";
        private const string CreateTypesTableSql = @"CREATE TABLE tblTypes(
                                                    Id int IDENTITY(1,1) PRIMARY KEY, 
                                                    Name nvarchar(100) NOT NULL, 
                                                    Color int NULL,
                                                    Font varchar(100) NULL
                                                )";
        private const string CreatePricesTableSql = @"CREATE TABLE tblPrices(
                                                    Id int IDENTITY(1,1) PRIMARY KEY, 
                                                    TypeId int NOT NULL,
                                                    SellPrice int NOT NULL, 
                                                    BuyPrice int NOT NULL,
                                                    DifferPrice int NOT NULL,
                                                    SellPriceColor int NULL,
                                                    BuyPriceColor int NULL,
                                                    SellPriceFont varchar(100) NULL,  
                                                    BuyPriceFont varchar(100) NULL 
                                                    FOREIGN KEY (typeId) REFERENCES tblTypes(id)
                                                )";

        public void CreateDB()
        {
            // Create a connection  
            SqlConnection conn = new SqlConnection(dbConn);

            // Open the connection  
            if (conn.State != ConnectionState.Open)
                conn.Open();

            SqlCommand cmd = new SqlCommand(CreateDBSql, conn);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "MYO Gold Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MYO Gold Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void CreateTables()
        {
            // Create a connection  
            SqlConnection conn = new SqlConnection(tablesConn);

            // Open the connection  
            if (conn.State != ConnectionState.Open)
                conn.Open();

            SqlCommand cmd1 = new SqlCommand(CreateTypesTableSql, conn);
            SqlCommand cmd2 = new SqlCommand(CreatePricesTableSql, conn);

            try
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.Message.ToString());
                Application.Exit();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool CheckDatabaseExists(string databaseName)
        {
            string sqlCheckDBQuery;
            bool result = false;

            try
            {
                SqlConnection tmpConn = new SqlConnection(dbConn);

                sqlCheckDBQuery = string.Format(@"SELECT database_id FROM sys.databases WHERE Name 
                = '{0}'", databaseName);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCheckDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        tmpConn.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool DropDBIfExist(string dbName)
        {
            bool result = false;

            try
            {
                SqlConnection tmpConn = new SqlConnection(dbConn);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand("DROP DATABASE IF EXISTS "+ dbName, tmpConn))
                    {
                        tmpConn.Open();

                        sqlCmd.ExecuteScalar();
                        result = true;

                        tmpConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
    }
}
