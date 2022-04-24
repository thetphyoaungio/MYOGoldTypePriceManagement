using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MYOGoldTypePriceManagement
{
    class GoldPrice
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int SellPrice { get; set; }
        public int BuyPrice { get; set; }
        public int DifferPrice { get; set; }
        public int? SellPriceColor { get; set; }
        public int? BuyPriceColor { get; set; }
        public string SellPriceFont { get; set; }
        public string BuyPriceFont { get; set; }

        private const string SelectQry = "SELECT * FROM tblPrices";
        private const string InsertQry = @"INSERT INTO tblPrices (TypeId, SellPrice, BuyPrice, DifferPrice, SellPriceColor, BuyPriceColor, SellPriceFont, BuyPriceFont) 
                                         VALUES (@TypeId, @SellPrice, @BuyPrice, @DifferPrice, @SellPriceColor, @BuyPriceColor, @SellPriceFont, @BuyPriceFont)";
        private const string UpdateQry = @"UPDATE tblPrices SET TypeId=@TypeId, SellPrice=@SellPrice, BuyPrice=@BuyPrice, DifferPrice=@DifferPrice, 
                                         SellPriceColor=@SellPriceColor, BuyPriceColor=@BuyPriceColor, SellPriceFont=@SellPriceFont, BuyPriceFont=@BuyPriceFont 
                                         WHERE Id=@Id";
        private const string DeleteQry = "DELETE FROM tblPrices WHERE Id=@Id";

        public DataTable getPrices()
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = new SqlConnection(myConn))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(SelectQry, conn))
                {
                    using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool InsertPrice(GoldPrice goldPrice)
        {
            int rows=0;

            using(SqlConnection conn = new SqlConnection(myConn))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(InsertQry, conn))
                {
                    cmd.Parameters.AddWithValue("@TypeId", goldPrice.TypeId);
                    cmd.Parameters.AddWithValue("@SellPrice", goldPrice.SellPrice);
                    cmd.Parameters.AddWithValue("@BuyPrice", goldPrice.BuyPrice);
                    cmd.Parameters.AddWithValue("@DifferPrice", goldPrice.DifferPrice);
                    cmd.Parameters.AddWithValue("@SellPriceColor", goldPrice.SellPriceColor);
                    cmd.Parameters.AddWithValue("@BuyPriceColor", goldPrice.BuyPriceColor);
                    cmd.Parameters.AddWithValue("@SellPriceFont", goldPrice.SellPriceFont);
                    cmd.Parameters.AddWithValue("@BuyPriceFont", goldPrice.BuyPriceFont);

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

        public bool UpdatePrice(GoldPrice goldPrice)
        {
            int rows=0;

            using (SqlConnection conn = new SqlConnection(myConn))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(UpdateQry, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", goldPrice.Id);
                    cmd.Parameters.AddWithValue("@TypeId", goldPrice.TypeId);
                    cmd.Parameters.AddWithValue("@SellPrice", goldPrice.SellPrice);
                    cmd.Parameters.AddWithValue("@BuyPrice", goldPrice.BuyPrice);
                    cmd.Parameters.AddWithValue("@DifferPrice", goldPrice.DifferPrice);
                    cmd.Parameters.AddWithValue("@SellPriceColor", goldPrice.SellPriceColor);
                    cmd.Parameters.AddWithValue("@BuyPriceColor", goldPrice.BuyPriceColor);
                    cmd.Parameters.AddWithValue("@SellPriceFont", goldPrice.SellPriceFont);
                    cmd.Parameters.AddWithValue("@BuyPriceFont", goldPrice.BuyPriceFont);

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

        public bool DeletePrice(GoldPrice goldPrice)
        {
            int rows=0;

            using (SqlConnection conn = new SqlConnection(myConn))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(DeleteQry, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", goldPrice.Id);

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
    }
}
