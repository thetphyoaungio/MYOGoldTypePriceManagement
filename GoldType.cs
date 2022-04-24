using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace MYOGoldTypePriceManagement
{
    class GoldType
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Color { get; set; }
        public string Font { get; set; }

        private const string SelectQry = "SELECT * FROM tblTypes";
        private const string InsertQry = @"INSERT INTO tblTypes (Name, Color, Font) VALUES (@Name, @Color, @Font)";
        private const string UpdateQry = @"UPDATE tblTypes SET Name=@Name, Color=@Color, Font=@Font WHERE Id=@Id";
        private const string DeleteQry = "DELETE FROM tblTypes WHERE Id=@Id";

        public DataTable GetTypes()
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = new SqlConnection(myConn))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(SelectQry, conn))
                {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool InsertType(GoldType goldType)
        {
            int rows=0;

            using(SqlConnection conn = new SqlConnection(myConn))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(InsertQry, conn))
                {
                    cmd.Parameters.AddWithValue("@Name",goldType.Name);
                    cmd.Parameters.AddWithValue("@Color", goldType.Color);
                    cmd.Parameters.AddWithValue("@Font", goldType.Font);

                    try
                    {
                        rows = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return (rows > 0);
        }

        public bool UpdateType(GoldType goldType)
        {
            int rows=0;

            using(SqlConnection conn = new SqlConnection(myConn))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(UpdateQry, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", goldType.Id);
                    cmd.Parameters.AddWithValue("@Name", goldType.Name);
                    cmd.Parameters.AddWithValue("@Color", goldType.Color);
                    cmd.Parameters.AddWithValue("@Font", goldType.Font);

                    try
                    {
                        rows = cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
            return (rows > 0);
        }

        public bool DeleteType(GoldType goldType)
        {
            int rows=0;

            using(SqlConnection conn = new SqlConnection(myConn))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(DeleteQry, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", goldType.Id);

                    try
                    {
                        rows = cmd.ExecuteNonQuery();
                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    
                }
            }
            return (rows > 0);
        }
    }
}
