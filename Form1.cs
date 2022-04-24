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

namespace MYOGoldTypePriceManagement
{
    public partial class myoHomeForm : Form
    {
        DBAndTblsInitializer dbAndTblsInitializer = new DBAndTblsInitializer();

        private static manageGoldTypesForm _goldTypesForm = null;
        private static ManageGoldPricesForm _goldPricesForm = null;

        GoldType goldType = new GoldType();
        GoldPrice goldPrice = new GoldPrice();

        public myoHomeForm()
        {
            InitializeComponent();

            if (!dbAndTblsInitializer.CheckDatabaseExists("dbMYOGoldShop"))
            {
                dbAndTblsInitializer.CreateDB();
                dbAndTblsInitializer.CreateTables();
            }
        }

        private void myoHomeForm_Load(object sender, EventArgs e)
        {
            //init gold types and prices
            initGoldTypes();
            initGoldPrices();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setGoldTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_goldTypesForm == null)
            {
                _goldTypesForm = new manageGoldTypesForm();
                _goldTypesForm.FormClosed += instanceHasBeenClosed;
                _goldTypesForm.Show();
            }
            _goldTypesForm.BringToFront();
        }

        private void instanceHasBeenClosed(object sender, FormClosedEventArgs e)
        {
            _goldTypesForm = null;
        }

        private void addGoldPricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_goldPricesForm == null)
            {
                _goldPricesForm = new ManageGoldPricesForm();
                _goldPricesForm.FormClosed += instanceGPricesHasBeenClosed;
                _goldPricesForm.Show();
            }
            _goldPricesForm.BringToFront();
        }

        private void instanceGPricesHasBeenClosed(object sender, FormClosedEventArgs e)
        {
            _goldPricesForm = null;
        }

        // init gold types and prices
        private void initGoldTypes()
        {
            DataTable dt = new DataTable();

            dt = goldType.GetTypes();

            List<GoldType> list = new List<GoldType>();

            var cvt = new FontConverter();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var gt = new GoldType();
                
                gt.Id = (int)dt.Rows[i]["Id"];
                gt.Name = dt.Rows[i]["Name"].ToString();
                gt.Color = (int)dt.Rows[i]["Color"];
                gt.Font = (string)dt.Rows[i]["Font"];

                list.Add(gt);
            }

            if(list.Count > 3)
            {
                MessageBox.Show("There are more than 3(three) Gold Types. Please delete unnecessary Gold Types!");

                lblGoldType1.Visible = false;
                lblGoldType2.Visible = false;
                lblGoldType3.Visible = false;
            }
            else if(list.Count <= 3)
            {
                if(list.Count < 3)
                {
                    addGoldPricesToolStripMenuItem.Visible = false;
                }
                else
                {
                    if (list[0] == null && list[1] == null && list[2] == null)
                    {
                        addGoldPricesToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        setGoldTypesToolStripMenuItem.Text = "Edit Gold Types";
                    }

                    if (list[0] != null)
                    {
                        lblGoldType1.Text = list[0].Name;
                        lblGoldType1.ForeColor = Color.FromArgb((int)list[0].Color);
                        lblGoldType1.Font = cvt.ConvertFromString(list[0].Font) as Font;
                    }
                    else
                    {
                        lblGoldType1.Visible = false;
                    }

                    if (list[1] != null)
                    {
                        lblGoldType2.Text = list[1].Name;
                        lblGoldType2.ForeColor = Color.FromArgb((int)list[1].Color);
                        lblGoldType2.Font = cvt.ConvertFromString(list[1].Font) as Font;
                    }
                    else
                    {
                        lblGoldType2.Visible = false;
                    }

                    if (list[2] != null)
                    {
                        lblGoldType3.Text = list[2].Name;
                        lblGoldType3.ForeColor = Color.FromArgb((int)list[2].Color);
                        lblGoldType3.Font = cvt.ConvertFromString(list[2].Font) as Font;
                    }
                    else
                    {
                        lblGoldType3.Visible = false;
                    }
                }
            }
        }

        private void initGoldPrices()
        {
            DataTable dt = new DataTable();

            dt = goldPrice.getPrices();

            List<GoldPrice> list = new List<GoldPrice>();

            var cvt = new FontConverter();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var gp = new GoldPrice();

                gp.Id = (int)dt.Rows[i]["Id"];
                gp.TypeId = (int)dt.Rows[i]["TypeId"];
                gp.SellPrice = (int)dt.Rows[i]["SellPrice"];
                gp.BuyPrice = (int)dt.Rows[i]["BuyPrice"];
                gp.DifferPrice = (int)dt.Rows[i]["DifferPrice"];
                gp.SellPriceColor = (int)dt.Rows[i]["SellPriceColor"];
                gp.BuyPriceColor = (int)dt.Rows[i]["BuyPriceColor"];
                gp.SellPriceFont = (string)dt.Rows[i]["SellPriceFont"];
                gp.BuyPriceFont = (string)dt.Rows[i]["BuyPriceFont"];

                //list[i] = gp;
                list.Add(gp);
            }

            if(list.Count > 3)
            {
                MessageBox.Show("There are more than 3(three) Prices. Please delete unnecessary Prices!");

                lblGoldPriceSell1.Visible = false;
                lblGoldPriceBuy1.Visible = false;

                lblGoldPriceSell2.Visible = false;
                lblGoldPriceBuy2.Visible = false;

                lblGoldPriceSell3.Visible = false;
                lblGoldPriceBuy3.Visible = false;
            }
            else if(list.Count <= 3)
            {
                if(list.Count < 3)
                {
                    lblGoldPriceSell1.Visible = false;
                    lblGoldPriceBuy1.Visible = false;

                    lblGoldPriceSell2.Visible = false;
                    lblGoldPriceBuy2.Visible = false;

                    lblGoldPriceSell3.Visible = false;
                    lblGoldPriceBuy3.Visible = false;
                }
                else
                {
                    if (list[0] != null && list[1] != null && list[2] != null)
                    {
                        addGoldPricesToolStripMenuItem.Text = "Edit Gold Prices";
                    }

                    if (list[0] != null)
                    {
                        lblGoldPriceSell1.Text = list[0].SellPrice.ToString("N0");
                        lblGoldPriceSell1.ForeColor = Color.FromArgb((int)list[0].SellPriceColor);
                        lblGoldPriceSell1.Font = cvt.ConvertFromString(list[0].SellPriceFont) as Font;
                        lblGoldPriceBuy1.Text = list[0].BuyPrice.ToString("N0");
                        lblGoldPriceBuy1.ForeColor = Color.FromArgb((int)list[0].BuyPriceColor);
                        lblGoldPriceBuy1.Font = cvt.ConvertFromString(list[0].BuyPriceFont) as Font;
                    }
                    else
                    {
                        lblGoldPriceSell1.Visible = false;
                        lblGoldPriceBuy1.Visible = false;
                    }

                    if (list[1] != null)
                    {
                        lblGoldPriceSell2.Text = list[1].SellPrice.ToString("N0");
                        lblGoldPriceSell2.ForeColor = Color.FromArgb((int)list[1].SellPriceColor);
                        lblGoldPriceSell2.Font = cvt.ConvertFromString(list[1].SellPriceFont) as Font;
                        lblGoldPriceBuy2.Text = list[1].BuyPrice.ToString("N0");
                        lblGoldPriceBuy2.ForeColor = Color.FromArgb((int)list[1].BuyPriceColor);
                        lblGoldPriceBuy2.Font = cvt.ConvertFromString(list[1].BuyPriceFont) as Font;
                    }
                    else
                    {
                        lblGoldPriceSell2.Visible = false;
                        lblGoldPriceBuy2.Visible = false;
                    }

                    if (list[2] != null)
                    {
                        lblGoldPriceSell3.Text = list[2].SellPrice.ToString("N0");
                        lblGoldPriceSell3.ForeColor = Color.FromArgb((int)list[2].SellPriceColor);
                        lblGoldPriceSell3.Font = cvt.ConvertFromString(list[2].SellPriceFont) as Font;
                        lblGoldPriceBuy3.Text = list[2].BuyPrice.ToString("N0");
                        lblGoldPriceBuy3.ForeColor = Color.FromArgb((int)list[2].BuyPriceColor);
                        lblGoldPriceBuy3.Font = cvt.ConvertFromString(list[2].BuyPriceFont) as Font;
                    }
                    else
                    {
                        lblGoldPriceSell3.Visible = false;
                        lblGoldPriceBuy3.Visible = false;
                    }
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            myoHomeForm_Load(null, null);
        }
    }
}
