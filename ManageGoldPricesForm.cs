using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace MYOGoldTypePriceManagement
{
    public partial class ManageGoldPricesForm : Form
    {
        GoldType goldType = new GoldType();

        GoldPrice goldPrice = new GoldPrice();
        GoldPrice goldPrice1 = new GoldPrice();
        GoldPrice goldPrice2 = new GoldPrice();
        GoldPrice goldPrice3 = new GoldPrice();

        int _index;

        public ManageGoldPricesForm()
        {
            InitializeComponent();
        }

        private void ManageGoldPricesForm_Load(object sender, EventArgs e)
        {
            //get & set gold types
            initGoldTypes();

            dgvGoldPrices.DataSource = goldPrice.getPrices();
        }

        private void btnSellPrice1InputOK_Click(object sender, EventArgs e)
        {
            // calculate formulas for other two prices
            //1. get sellprice1
            decimal sellPrice1;
            decimal.TryParse(tbxGTSellPrice1.Text,out sellPrice1);

            // then auto generate for other two
            decimal temp2 = Math.Round((128m / 136m) * sellPrice1, MidpointRounding.AwayFromZero);
            decimal temp3 = Math.Round((128m / 140m) * sellPrice1, MidpointRounding.AwayFromZero);

            int price2 = hundredRounding(temp2);
            int price3 = hundredRounding(temp3);

            tbxGTSellPrice2.Text = price2.ToString();
            tbxGTSellPrice3.Text = price3.ToString();

            // set model data
            goldPrice1.SellPrice = (int)sellPrice1;
            goldPrice1.TypeId = (int)lblGoldType1.Tag;

            goldPrice2.SellPrice = (int)price2;
            goldPrice2.TypeId = (int)lblGoldType2.Tag;

            goldPrice3.SellPrice = (int)price3;
            goldPrice3.TypeId = (int)lblGoldType3.Tag;

        }

        private void initGoldTypes()
        {
            DataTable dt = new DataTable();
            dt = goldType.GetTypes();
            var goldTypesArry = new GoldType[3];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var gt = new GoldType();

                gt.Id = (int)dt.Rows[i]["Id"];
                gt.Name = dt.Rows[i]["Name"].ToString();

                goldTypesArry[i] = gt;
            }

            lblGoldType1.Tag = goldTypesArry[0].Id;
            lblGoldType1.Text = goldTypesArry[0].Name;
            lblGoldType2.Tag = goldTypesArry[1].Id;
            lblGoldType2.Text = goldTypesArry[1].Name;
            lblGoldType3.Tag = goldTypesArry[2].Id;
            lblGoldType3.Text = goldTypesArry[2].Name;
        }

        private int hundredRounding(decimal price)
        {
            int result = 0;

            string mainPriceStr = price.ToString();// "62450" "62650"
            string hundredValStr = mainPriceStr.Substring((mainPriceStr.Length - 3), 3);// "450" "650"

            int hundredValStrInt = 0;
            int.TryParse(hundredValStr, out hundredValStrInt);// 450 650

            if(hundredValStrInt >= 500)
            {
                mainPriceStr = calcuHundredValue(mainPriceStr, hundredValStrInt, true);

                int.TryParse(mainPriceStr, out result);// 63000
            }
            else
            {
                mainPriceStr = calcuHundredValue(mainPriceStr, hundredValStrInt, false);

                int.TryParse(mainPriceStr, out result);// 62000
            }

            return result;
        }

        private string calcuHundredValue(string mainPrice, int hundredValStrInt, bool isGreater = true)
        {
            int mainPriceInt = 0;
            int thousandValInt = 0;
            string thousandValStr = mainPrice.Substring((mainPrice.Length - 4), 4);// "2650"
            int.TryParse(thousandValStr, out thousandValInt);// 2650

            thousandValInt -= hundredValStrInt;// 2000

            int.TryParse(mainPrice, out mainPriceInt);
            mainPriceInt -= hundredValStrInt;

            if (isGreater)
            {
                mainPriceInt -= thousandValInt;

                thousandValInt += 1000;// 3000 //189'0000' (9000 + 1000) = 10000

                mainPriceInt += thousandValInt;
            }

            return mainPriceInt.ToString();//mainPrice.Replace(thousandValStr, thousandValInt.ToString());// "63000"
        }

        private void btnDifferPriceOK_Click(object sender, EventArgs e)
        {
            if(tbxGTSellPrice1.Text == string.Empty)
            {
                MessageBox.Show("ရောင်းဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                int _differPrice = 0;
                int.TryParse(tbxDifferPrice.Text, out _differPrice);

                // set model data
                goldPrice1.DifferPrice = _differPrice;
                goldPrice2.DifferPrice = _differPrice;
                goldPrice3.DifferPrice = _differPrice;

                goldPrice1.BuyPrice = hundredRounding(goldPrice1.SellPrice - _differPrice);
                goldPrice2.BuyPrice = hundredRounding(goldPrice2.SellPrice - _differPrice);
                goldPrice3.BuyPrice = hundredRounding(goldPrice3.SellPrice - _differPrice);

                tbxGTBuyPrice1.Text = goldPrice1.BuyPrice.ToString();
                tbxGTBuyPrice2.Text = goldPrice2.BuyPrice.ToString();
                tbxGTBuyPrice3.Text = goldPrice3.BuyPrice.ToString();

                tbxGTSellPrice2.ReadOnly = true;
                tbxGTSellPrice3.ReadOnly = true;

                tbxGTBuyPrice1.ReadOnly = true;
                tbxGTBuyPrice2.ReadOnly = true;
                tbxGTBuyPrice3.ReadOnly = true;
            }
        }

        //*
        private void btnGoldPricesOK_Click(object sender, EventArgs e)
        {
            if(goldPrice1.SellPriceColor!=null && goldPrice1.BuyPriceColor != null && goldPrice1.SellPriceFont != null && goldPrice1.BuyPriceFont != null
                && goldPrice2.SellPriceColor != null && goldPrice2.BuyPriceColor != null && goldPrice2.SellPriceFont != null && goldPrice2.BuyPriceFont != null
                && goldPrice3.SellPriceColor != null && goldPrice3.BuyPriceColor != null && goldPrice3.SellPriceFont != null && goldPrice3.BuyPriceFont != null)
            {
                try
                {
                    var success1 = goldPrice.InsertPrice(goldPrice1);
                    var success2 = goldPrice.InsertPrice(goldPrice2);
                    var success3 = goldPrice.InsertPrice(goldPrice3);

                    if (success1 && success2 && success3)
                    {
                        //refresh data-grid-view
                        dgvGoldPrices.DataSource = goldPrice.getPrices();

                        ClearControls();
                        MessageBox.Show("အသစ်ထည့်သွင်းခြင်း အောင်မြင်ပါသည်!");
                    }
                    else
                    {
                        MessageBox.Show("အသစ်ထည့်သွင်းခြင်း လုပ်ဆောင်မှု မအောင်မြင်ပါ။ ထပ်မံ ပြုလုပ်ပါ...");
                    }
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please define Font and Color for all Prices!");
            }
        }

        private void btnGoldPricesUpdate_Click(object sender, EventArgs e)
        {
            var cvt = new FontConverter();
            var success=false;

            if (_index == 0) 
            {
                // set Model data
                goldPrice1.SellPrice = int.Parse(tbxGTSellPrice1.Text);
                goldPrice1.BuyPrice = int.Parse(tbxGTBuyPrice1.Text);
                goldPrice1.DifferPrice = int.Parse(tbxDifferPrice.Text);
                goldPrice1.SellPriceColor = tbxGTSellPrice1.ForeColor.ToArgb();
                goldPrice1.BuyPriceColor = tbxGTBuyPrice1.ForeColor.ToArgb();
                goldPrice1.SellPriceFont = cvt.ConvertToString(tbxGTSellPrice1.Font);
                goldPrice1.BuyPriceFont = cvt.ConvertToString(tbxGTBuyPrice1.Font);

                success = goldPrice.UpdatePrice(goldPrice1);
            }
            else if (_index == 1)
            {
                goldPrice2.SellPrice = int.Parse(tbxGTSellPrice2.Text);
                goldPrice2.BuyPrice = int.Parse(tbxGTBuyPrice2.Text);
                goldPrice2.DifferPrice = int.Parse(tbxDifferPrice.Text);
                goldPrice2.SellPriceColor = tbxGTSellPrice2.ForeColor.ToArgb();
                goldPrice2.BuyPriceColor = tbxGTBuyPrice2.ForeColor.ToArgb();
                goldPrice2.SellPriceFont = cvt.ConvertToString(tbxGTSellPrice2.Font);
                goldPrice2.BuyPriceFont = cvt.ConvertToString(tbxGTBuyPrice2.Font);

                success = goldPrice.UpdatePrice(goldPrice2);
            }
            else if (_index == 2)
            {
                goldPrice3.SellPrice = int.Parse(tbxGTSellPrice3.Text);
                goldPrice3.BuyPrice = int.Parse(tbxGTBuyPrice3.Text);
                goldPrice3.DifferPrice = int.Parse(tbxDifferPrice.Text);
                goldPrice3.SellPriceColor = tbxGTSellPrice3.ForeColor.ToArgb();
                goldPrice3.BuyPriceColor = tbxGTBuyPrice3.ForeColor.ToArgb();
                goldPrice3.SellPriceFont = cvt.ConvertToString(tbxGTSellPrice3.Font);
                goldPrice3.BuyPriceFont = cvt.ConvertToString(tbxGTBuyPrice3.Font);

                success = goldPrice.UpdatePrice(goldPrice3);
            }
            
            //refresh data-grid-view
            dgvGoldPrices.DataSource = goldPrice.getPrices();

            if (success)
            {
                ClearControls();
                MessageBox.Show("Update ပြုလုပ်ခြင်း အောင်မြင်ပါသည်!");
            }
            else
            {
                MessageBox.Show("Update ပြုလုပ်ခြင်း လုပ်ဆောင်မှု မအောင်မြင်ပါ။ ထပ်မံ ပြုလုပ်ပါ...");
            }
        }

        private void btnGoldPricesDelete_Click(object sender, EventArgs e)
        {
            var success = false;

            if (_index == 0)
            {
                success = goldPrice.DeletePrice(goldPrice1);
            }
            else if (_index == 0)
            {
                success = goldPrice.DeletePrice(goldPrice2);
            }
            else if (_index == 0)
            {
                success = goldPrice.DeletePrice(goldPrice3);
            }
            
            dgvGoldPrices.DataSource = goldPrice.getPrices();

            if (success)
            {
                ClearControls();
                MessageBox.Show("ပယ်ဖျက်ခြင်း အောင်မြင်ပါသည်!");
            }
            else
            {
                MessageBox.Show("ပယ်ဖျက်ခြင်း လုပ်ဆောင်မှု မအောင်မြင်ပါ။ ထပ်မံ ပြုလုပ်ပါ...");
            }
        }

        private void dgvGoldPrices_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _index = e.RowIndex;

            var cvt = new FontConverter();

            // set UI controls data
            tbxDifferPrice.Text = dgvGoldPrices.Rows[0].Cells[4].Value.ToString();

            if (_index == 0)
            {
                tbxGTSellPrice1.Tag = dgvGoldPrices.Rows[0].Cells[1].Value.ToString();

                tbxGTSellPrice1.Text = dgvGoldPrices.Rows[0].Cells[2].Value.ToString();

                tbxGTSellPrice1.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[0].Cells[5].Value);
                tbxGTSellPrice1.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[0].Cells[7].Value.ToString()) as Font;

                tbxGTBuyPrice1.Text = dgvGoldPrices.Rows[0].Cells[3].Value.ToString();

                tbxGTBuyPrice1.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[0].Cells[6].Value);
                tbxGTBuyPrice1.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[0].Cells[8].Value.ToString()) as Font;

                goldPrice1.Id = (int)dgvGoldPrices.Rows[0].Cells[0].Value;
                goldPrice1.TypeId = (int)dgvGoldPrices.Rows[0].Cells[1].Value;
            }

            else if (_index == 1)
            {
                tbxGTSellPrice2.Tag = dgvGoldPrices.Rows[1].Cells[1].Value.ToString();

                tbxGTSellPrice2.Text = dgvGoldPrices.Rows[1].Cells[2].Value.ToString();

                tbxGTSellPrice2.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[1].Cells[5].Value);
                tbxGTSellPrice2.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[1].Cells[7].Value.ToString()) as Font;

                tbxGTBuyPrice2.Text = dgvGoldPrices.Rows[1].Cells[3].Value.ToString();

                tbxGTBuyPrice2.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[1].Cells[6].Value);
                tbxGTBuyPrice2.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[1].Cells[8].Value.ToString()) as Font;

                goldPrice2.Id = (int)dgvGoldPrices.Rows[1].Cells[0].Value;
                goldPrice2.TypeId = (int)dgvGoldPrices.Rows[1].Cells[1].Value;
            }
            else if (_index == 2)
            {
                tbxGTSellPrice3.Tag = dgvGoldPrices.Rows[2].Cells[1].Value?.ToString();

                tbxGTSellPrice3.Text = dgvGoldPrices.Rows[2].Cells[2].Value?.ToString();

                tbxGTSellPrice3.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[2].Cells[5].Value);
                tbxGTSellPrice3.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[2].Cells[7].Value?.ToString()) as Font;

                tbxGTBuyPrice3.Text = dgvGoldPrices.Rows[2].Cells[3].Value?.ToString();

                tbxGTBuyPrice3.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[2].Cells[6].Value);
                tbxGTBuyPrice3.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[2].Cells[8].Value?.ToString()) as Font;

                goldPrice3.Id = (int)dgvGoldPrices.Rows[2].Cells[0].Value;
                goldPrice3.TypeId = (int)dgvGoldPrices.Rows[2].Cells[1].Value;
            }
        }
        //*

        private void btnGoldPricesExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearControls()
        {
            tbxGTSellPrice1.Text = "";
            tbxGTSellPrice2.Text = "";
            tbxGTSellPrice3.Text = "";
            tbxDifferPrice.Text = "";
            tbxGTBuyPrice1.Text = "";
            tbxGTBuyPrice2.Text = "";
            tbxGTBuyPrice3.Text = "";
        }

        private void btnGoldPricesClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        // define Font and Color
        private void btnSellPriceFont1_Click(object sender, EventArgs e)
        {
            if (tbxGTSellPrice1.Text == string.Empty)
            {
                MessageBox.Show("ရောင်းဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = fontDialog1.ShowDialog(this);

                if (R == DialogResult.OK)
                {
                    tbxGTSellPrice1.Font = fontDialog1.Font;

                    var cvt = new FontConverter();
                    string fs = cvt.ConvertToString(fontDialog1.Font);

                    // set model data
                    goldPrice1.SellPriceFont = fs;
                }
            }
        }

        private void btnSellPriceFont2_Click(object sender, EventArgs e)
        {
            if (tbxGTSellPrice2.Text == string.Empty)
            {
                MessageBox.Show("ရောင်းဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = fontDialog1.ShowDialog(this);

                if (R == DialogResult.OK)
                {
                    tbxGTSellPrice2.Font = fontDialog1.Font;

                    var cvt = new FontConverter();
                    string fs = cvt.ConvertToString(fontDialog1.Font);

                    // set model data
                    goldPrice2.SellPriceFont = fs;
                }
            }
        }

        private void btnSellPriceFont3_Click(object sender, EventArgs e)
        {
            if (tbxGTSellPrice3.Text == string.Empty)
            {
                MessageBox.Show("ရောင်းဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = fontDialog1.ShowDialog(this);

                if (R == DialogResult.OK)
                {
                    tbxGTSellPrice3.Font = fontDialog1.Font;

                    var cvt = new FontConverter();
                    string fs = cvt.ConvertToString(fontDialog1.Font);

                    // set model data
                    goldPrice3.SellPriceFont = fs;
                }
            }
        }

        private void btnSellPriceColor1_Click(object sender, EventArgs e)
        {
            if (tbxGTSellPrice1.Text == string.Empty)
            {
                MessageBox.Show("ရောင်းဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = colorDialog1.ShowDialog();

                if (R == DialogResult.OK)
                {
                    tbxGTSellPrice1.ForeColor = colorDialog1.Color;

                    // set model data
                    goldPrice1.SellPriceColor = colorDialog1.Color.ToArgb();
                }
            }
        }

        private void btnSellPriceColor2_Click(object sender, EventArgs e)
        {
            if (tbxGTSellPrice2.Text == string.Empty)
            {
                MessageBox.Show("ရောင်းဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = colorDialog1.ShowDialog();

                if (R == DialogResult.OK)
                {
                    tbxGTSellPrice2.ForeColor = colorDialog1.Color;

                    // set model data
                    goldPrice2.SellPriceColor = colorDialog1.Color.ToArgb();
                }
            }
        }

        private void btnSellPriceColor3_Click(object sender, EventArgs e)
        {
            if (tbxGTSellPrice3.Text == string.Empty)
            {
                MessageBox.Show("ရောင်းဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = colorDialog1.ShowDialog();

                if (R == DialogResult.OK)
                {
                    tbxGTSellPrice3.ForeColor = colorDialog1.Color;

                    // set model data
                    goldPrice3.SellPriceColor = colorDialog1.Color.ToArgb();
                }
            }
        }

        private void btnBuyPriceFont1_Click(object sender, EventArgs e)
        {
            if (tbxGTBuyPrice1.Text == string.Empty)
            {
                MessageBox.Show("ဝယ်ဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = fontDialog1.ShowDialog(this);

                if (R == DialogResult.OK)
                {
                    tbxGTBuyPrice1.Font = fontDialog1.Font;

                    var cvt = new FontConverter();
                    string fs = cvt.ConvertToString(fontDialog1.Font);

                    // set model data
                    goldPrice1.BuyPriceFont = fs;
                }
            }
        }

        private void btnBuyPriceFont2_Click(object sender, EventArgs e)
        {
            if (tbxGTBuyPrice2.Text == string.Empty)
            {
                MessageBox.Show("ဝယ်ဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = fontDialog1.ShowDialog(this);

                if (R == DialogResult.OK)
                {
                    tbxGTBuyPrice2.Font = fontDialog1.Font;

                    var cvt = new FontConverter();
                    string fs = cvt.ConvertToString(fontDialog1.Font);

                    // set model data
                    goldPrice2.BuyPriceFont = fs;
                }
            }
        }

        private void btnBuyPriceFont3_Click(object sender, EventArgs e)
        {
            if (tbxGTBuyPrice3.Text == string.Empty)
            {
                MessageBox.Show("ဝယ်ဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = fontDialog1.ShowDialog(this);

                if (R == DialogResult.OK)
                {
                    tbxGTBuyPrice3.Font = fontDialog1.Font;

                    var cvt = new FontConverter();
                    string fs = cvt.ConvertToString(fontDialog1.Font);

                    // set model data
                    goldPrice3.BuyPriceFont = fs;
                }
            }
        }

        private void btnBuyPriceColor1_Click(object sender, EventArgs e)
        {
            if (tbxGTBuyPrice1.Text == string.Empty)
            {
                MessageBox.Show("ဝယ်ဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = colorDialog1.ShowDialog();

                if (R == DialogResult.OK)
                {
                    tbxGTBuyPrice1.ForeColor = colorDialog1.Color;

                    // set model data
                    goldPrice1.BuyPriceColor = colorDialog1.Color.ToArgb();
                }
            }
        }

        private void btnBuyPriceColor2_Click(object sender, EventArgs e)
        {
            if (tbxGTBuyPrice2.Text == string.Empty)
            {
                MessageBox.Show("ဝယ်ဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = colorDialog1.ShowDialog();

                if (R == DialogResult.OK)
                {
                    tbxGTBuyPrice2.ForeColor = colorDialog1.Color;

                    // set model data
                    goldPrice2.BuyPriceColor = colorDialog1.Color.ToArgb();
                }
            }
        }

        private void btnBuyPriceColor3_Click(object sender, EventArgs e)
        {
            if (tbxGTBuyPrice3.Text == string.Empty)
            {
                MessageBox.Show("ဝယ်ဈေး ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = colorDialog1.ShowDialog();

                if (R == DialogResult.OK)
                {
                    tbxGTBuyPrice3.ForeColor = colorDialog1.Color;

                    // set model data
                    goldPrice3.BuyPriceColor = colorDialog1.Color.ToArgb();
                }
            }
        }
    }
}
