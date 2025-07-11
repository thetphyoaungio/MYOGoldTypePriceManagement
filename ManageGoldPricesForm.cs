﻿using System;
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

        int _index0 = -1;
        int _index1 = -1;
        int _index2 = -1;

        float sellPrice1FontSize;
        float sellPrice2FontSize;
        float sellPrice3FontSize;
        float buyPrice1FontSize;
        float buyPrice2FontSize;
        float buyPrice3FontSize;


        public ManageGoldPricesForm()
        {
            InitializeComponent();
        }

        private void ManageGoldPricesForm_Load(object sender, EventArgs e)
        {
            //get & set gold types
            initGoldTypes();

            dgvGoldPrices.DataSource = goldPrice.getPrices();

            btnGoldPricesUpdate.Enabled = false;
            btnGoldPricesDelete.Enabled = false;
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

            if(_index0 == 0 && _index1==1 && _index2 == 2)
            {
                btnDifferPriceOK_Click(sender, e);
            }

        }

        private void btnDifferPriceOK_Click(object sender, EventArgs e)
        {
            if (_index0 == -1 && _index1 == -1 && _index2 == -1)
            {
                if(tbxGTSellPrice1.Text == string.Empty)
                {
                    MessageBox.Show("Please Input Sell Prices!");
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
                }
            }
            else
            {
                int _differPrice = 0;
                int.TryParse(tbxDifferPrice.Text, out _differPrice);

                if (tbxGTSellPrice1.Text != string.Empty)
                {
                    // set model data
                    goldPrice1.SellPrice = int.Parse(tbxGTSellPrice1.Text);

                    goldPrice1.DifferPrice = _differPrice;
                    goldPrice1.BuyPrice = hundredRounding(goldPrice1.SellPrice - _differPrice);
                    tbxGTBuyPrice1.Text = goldPrice1.BuyPrice.ToString();
                }
                if (tbxGTSellPrice2.Text != string.Empty)
                {
                    // set model data
                    goldPrice2.SellPrice = int.Parse(tbxGTSellPrice2.Text);

                    goldPrice2.DifferPrice = _differPrice;
                    goldPrice2.BuyPrice = hundredRounding(goldPrice2.SellPrice - _differPrice);
                    tbxGTBuyPrice2.Text = goldPrice2.BuyPrice.ToString();
                }
                if (tbxGTSellPrice3.Text != string.Empty)
                {
                    // set model data
                    goldPrice3.SellPrice = int.Parse(tbxGTSellPrice3.Text);

                    goldPrice3.DifferPrice = _differPrice;
                    goldPrice3.BuyPrice = hundredRounding(goldPrice3.SellPrice - _differPrice);
                    tbxGTBuyPrice3.Text = goldPrice3.BuyPrice.ToString();
                }
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
                        MessageBox.Show("Added Successfully!");
                        goldPrice1 = null;
                        goldPrice2 = null;
                        goldPrice3 = null;
                    }
                    else
                    {
                        MessageBox.Show("Sorry, please try again...");
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
            var success = false;
            var success1 = false;
            var success2 = false;

            if (_index0 == 0 && _index1!=1 && _index2!= 2) 
            {
                // set Model data
                goldPrice1.SellPrice = int.Parse(tbxGTSellPrice1.Text);
                goldPrice1.BuyPrice = int.Parse(tbxGTBuyPrice1.Text);
                goldPrice1.DifferPrice = int.Parse(tbxDifferPrice.Text);
                goldPrice1.SellPriceColor = tbxGTSellPrice1.ForeColor.ToArgb();
                goldPrice1.BuyPriceColor = tbxGTBuyPrice1.ForeColor.ToArgb();
                goldPrice1.SellPriceFont = cvt.ConvertToString(new Font(tbxGTSellPrice1.Font.FontFamily,sellPrice1FontSize, tbxGTSellPrice1.Font.Style));
                goldPrice1.BuyPriceFont = cvt.ConvertToString(new Font(tbxGTBuyPrice1.Font.FontFamily, buyPrice1FontSize, tbxGTBuyPrice1.Font.Style));

                success = goldPrice.UpdatePrice(goldPrice1);
                if (success)
                {
                    dgvGoldPrices.DataSource = goldPrice.getPrices();
                    ClearControls();
                    MessageBox.Show("Update Successfully!");
                    success = false;
                    _index0 = -1;
                }
                else
                {
                    MessageBox.Show("Sorry, please try again...");
                }
            }
            else if (_index1 == 1 && _index0 != 0 && _index2 != 2)
            {
                goldPrice2.SellPrice = int.Parse(tbxGTSellPrice2.Text);
                goldPrice2.BuyPrice = int.Parse(tbxGTBuyPrice2.Text);
                goldPrice2.DifferPrice = int.Parse(tbxDifferPrice.Text);
                goldPrice2.SellPriceColor = tbxGTSellPrice2.ForeColor.ToArgb();
                goldPrice2.BuyPriceColor = tbxGTBuyPrice2.ForeColor.ToArgb();

                
                goldPrice2.SellPriceFont = cvt.ConvertToString(new Font(tbxGTSellPrice2.Font.FontFamily, sellPrice2FontSize, tbxGTSellPrice2.Font.Style));
                
                goldPrice2.BuyPriceFont = cvt.ConvertToString(new Font(tbxGTBuyPrice2.Font.FontFamily, buyPrice2FontSize, tbxGTBuyPrice2.Font.Style));

                success = goldPrice.UpdatePrice(goldPrice2);
                if (success)
                {
                    dgvGoldPrices.DataSource = goldPrice.getPrices();
                    ClearControls();
                    MessageBox.Show("Update Successfully!");
                    success = false;
                    _index1 = -1;
                }
                else
                {
                    MessageBox.Show("Sorry, please try again...");
                }
            }
            else if (_index2 == 2 && _index1 != 1 && _index0 != 0)
            {
                goldPrice3.SellPrice = int.Parse(tbxGTSellPrice3.Text);
                goldPrice3.BuyPrice = int.Parse(tbxGTBuyPrice3.Text);
                goldPrice3.DifferPrice = int.Parse(tbxDifferPrice.Text);
                goldPrice3.SellPriceColor = tbxGTSellPrice3.ForeColor.ToArgb();
                goldPrice3.BuyPriceColor = tbxGTBuyPrice3.ForeColor.ToArgb();

                
                goldPrice3.SellPriceFont = cvt.ConvertToString(new Font(tbxGTSellPrice3.Font.FontFamily, sellPrice3FontSize, tbxGTSellPrice3.Font.Style));
                
                goldPrice3.BuyPriceFont = cvt.ConvertToString(new Font(tbxGTBuyPrice3.Font.FontFamily, buyPrice3FontSize, tbxGTBuyPrice3.Font.Style));

                success = goldPrice.UpdatePrice(goldPrice3);

                if (success)
                {
                    dgvGoldPrices.DataSource = goldPrice.getPrices();
                    ClearControls();
                    MessageBox.Show("Update Successfully!");
                    success = false;
                    _index2 = -1;
                }
                else
                {
                    MessageBox.Show("Sorry, please try again...");
                }
            }
            else if (_index0==0 && _index1==1 && _index2==2)
            {
                // set Model data
                goldPrice1.SellPrice = int.Parse(tbxGTSellPrice1.Text);
                goldPrice1.BuyPrice = int.Parse(tbxGTBuyPrice1.Text);
                goldPrice1.DifferPrice = int.Parse(tbxDifferPrice.Text);
                goldPrice1.SellPriceColor = tbxGTSellPrice1.ForeColor.ToArgb();
                goldPrice1.BuyPriceColor = tbxGTBuyPrice1.ForeColor.ToArgb();
                goldPrice1.SellPriceFont = cvt.ConvertToString(new Font(tbxGTSellPrice1.Font.FontFamily, sellPrice1FontSize, tbxGTSellPrice1.Font.Style));
                goldPrice1.BuyPriceFont = cvt.ConvertToString(new Font(tbxGTBuyPrice1.Font.FontFamily, buyPrice1FontSize, tbxGTBuyPrice1.Font.Style));

                success = goldPrice.UpdatePrice(goldPrice1);

                if (success)
                {
                    dgvGoldPrices.DataSource = goldPrice.getPrices();
                    success = false;

                    goldPrice2.SellPrice = int.Parse(tbxGTSellPrice2.Text);
                    goldPrice2.BuyPrice = int.Parse(tbxGTBuyPrice2.Text);
                    goldPrice2.DifferPrice = int.Parse(tbxDifferPrice.Text);
                    goldPrice2.SellPriceColor = tbxGTSellPrice2.ForeColor.ToArgb();
                    goldPrice2.BuyPriceColor = tbxGTBuyPrice2.ForeColor.ToArgb();


                    goldPrice2.SellPriceFont = cvt.ConvertToString(new Font(tbxGTSellPrice2.Font.FontFamily, sellPrice2FontSize, tbxGTSellPrice2.Font.Style));

                    goldPrice2.BuyPriceFont = cvt.ConvertToString(new Font(tbxGTBuyPrice2.Font.FontFamily, buyPrice2FontSize, tbxGTBuyPrice2.Font.Style));

                    success1 = goldPrice.UpdatePrice(goldPrice2);

                    if (success1)
                    {
                        dgvGoldPrices.DataSource = goldPrice.getPrices();
                        success1 = false;

                        goldPrice3.SellPrice = int.Parse(tbxGTSellPrice3.Text);
                        goldPrice3.BuyPrice = int.Parse(tbxGTBuyPrice3.Text);
                        goldPrice3.DifferPrice = int.Parse(tbxDifferPrice.Text);
                        goldPrice3.SellPriceColor = tbxGTSellPrice3.ForeColor.ToArgb();
                        goldPrice3.BuyPriceColor = tbxGTBuyPrice3.ForeColor.ToArgb();


                        goldPrice3.SellPriceFont = cvt.ConvertToString(new Font(tbxGTSellPrice3.Font.FontFamily, sellPrice3FontSize, tbxGTSellPrice3.Font.Style));

                        goldPrice3.BuyPriceFont = cvt.ConvertToString(new Font(tbxGTBuyPrice3.Font.FontFamily, buyPrice3FontSize, tbxGTBuyPrice3.Font.Style));

                        success2 = goldPrice.UpdatePrice(goldPrice3);

                        if (success2)
                        {
                            dgvGoldPrices.DataSource = goldPrice.getPrices();
                            success2 = false;
                            _index0 = -1;
                            _index1 = -1;
                            _index2 = -1;

                            ClearControls();
                            MessageBox.Show("Update Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Sorry, please try again...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, please try again...");
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, please try again...");
                }
            }
        }

        private void btnGoldPricesDelete_Click(object sender, EventArgs e)
        {
            var success = false;

            if (_index0 == 0)
            {
                success = goldPrice.DeletePrice(goldPrice1);
                dgvGoldPrices.DataSource = goldPrice.getPrices();
                _index0 = -1;
            }
            if (_index1 == 1)
            {
                success = goldPrice.DeletePrice(goldPrice2);
                dgvGoldPrices.DataSource = goldPrice.getPrices();
                _index1 = -1;
            }
            if (_index2 == 2)
            {
                success = goldPrice.DeletePrice(goldPrice3);
                dgvGoldPrices.DataSource = goldPrice.getPrices();
                _index2 = -1;
            }

            if (success)
            {
                ClearControls();
                MessageBox.Show("Deleted Successfully!");
            }
            else
            {
                MessageBox.Show("Sorry, please try again...");
            }
        }

        private void dgvGoldPrices_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.RowIndex)
            {
                case 0:
                    {
                        _index0 = 0;
                        break;
                    }
                case 1:
                    {
                        _index1 = 1;
                        break;
                    }
                case 2:
                    {
                        _index2 = 2;
                        break;
                    }
            }

            if (_index0 == 0 && _index1 == 1 && _index2 == 2)
            {
                btnSellPrice1InputOK.Enabled = true;
            }
            else
            {
                btnSellPrice1InputOK.Enabled = false;
            }

            btnGoldPricesOK.Enabled = false;
            btnGoldPricesUpdate.Enabled = true;
            btnGoldPricesDelete.Enabled = true;

            var cvt = new FontConverter();

            // set UI controls data
            tbxDifferPrice.Text = dgvGoldPrices.Rows[0].Cells[4].Value.ToString();

            if (_index0 == 0)
            {
                tbxGTSellPrice1.Tag = dgvGoldPrices.Rows[0].Cells[1].Value.ToString();

                tbxGTSellPrice1.Text = dgvGoldPrices.Rows[0].Cells[2].Value.ToString();

                tbxGTSellPrice1.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[0].Cells[5].Value);
                tbxGTSellPrice1.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[0].Cells[7].Value.ToString()) as Font;

                sellPrice1FontSize = tbxGTSellPrice1.Font.Size;
                tbxGTSellPrice1.Font = new Font(tbxGTSellPrice1.Font.FontFamily, 20, tbxGTSellPrice1.Font.Style);

                tbxGTBuyPrice1.Text = dgvGoldPrices.Rows[0].Cells[3].Value.ToString();

                tbxGTBuyPrice1.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[0].Cells[6].Value);
                tbxGTBuyPrice1.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[0].Cells[8].Value.ToString()) as Font;

                buyPrice1FontSize = tbxGTBuyPrice1.Font.Size;
                tbxGTBuyPrice1.Font = new Font(tbxGTBuyPrice1.Font.FontFamily, 20, tbxGTBuyPrice1.Font.Style);

                goldPrice1.Id = (int)dgvGoldPrices.Rows[0].Cells[0].Value;
                goldPrice1.TypeId = (int)dgvGoldPrices.Rows[0].Cells[1].Value;
            }

            if (_index1 == 1)
            {
                tbxGTSellPrice2.Tag = dgvGoldPrices.Rows[1].Cells[1].Value.ToString();

                tbxGTSellPrice2.Text = dgvGoldPrices.Rows[1].Cells[2].Value.ToString();

                tbxGTSellPrice2.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[1].Cells[5].Value);
                tbxGTSellPrice2.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[1].Cells[7].Value.ToString()) as Font;

                sellPrice2FontSize = tbxGTSellPrice2.Font.Size;
                tbxGTSellPrice2.Font = new Font(tbxGTSellPrice2.Font.FontFamily, 20, tbxGTSellPrice2.Font.Style);

                tbxGTBuyPrice2.Text = dgvGoldPrices.Rows[1].Cells[3].Value.ToString();

                tbxGTBuyPrice2.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[1].Cells[6].Value);
                tbxGTBuyPrice2.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[1].Cells[8].Value.ToString()) as Font;

                buyPrice2FontSize = tbxGTBuyPrice2.Font.Size;
                tbxGTBuyPrice2.Font = new Font(tbxGTBuyPrice2.Font.FontFamily, 20, tbxGTBuyPrice2.Font.Style);

                goldPrice2.Id = (int)dgvGoldPrices.Rows[1].Cells[0].Value;
                goldPrice2.TypeId = (int)dgvGoldPrices.Rows[1].Cells[1].Value;
            }
            if (_index2 == 2)
            {
                tbxGTSellPrice3.Tag = dgvGoldPrices.Rows[2].Cells[1].Value?.ToString();

                tbxGTSellPrice3.Text = dgvGoldPrices.Rows[2].Cells[2].Value?.ToString();

                tbxGTSellPrice3.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[2].Cells[5].Value);
                tbxGTSellPrice3.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[2].Cells[7].Value?.ToString()) as Font;

                sellPrice3FontSize = tbxGTSellPrice3.Font.Size;
                tbxGTSellPrice3.Font = new Font(tbxGTSellPrice3.Font.FontFamily, 20, tbxGTSellPrice3.Font.Style);

                tbxGTBuyPrice3.Text = dgvGoldPrices.Rows[2].Cells[3].Value?.ToString();

                tbxGTBuyPrice3.ForeColor = Color.FromArgb((int)dgvGoldPrices.Rows[2].Cells[6].Value);
                tbxGTBuyPrice3.Font = cvt.ConvertFromString(dgvGoldPrices.Rows[2].Cells[8].Value?.ToString()) as Font;

                buyPrice3FontSize = tbxGTBuyPrice3.Font.Size;
                tbxGTBuyPrice3.Font = new Font(tbxGTBuyPrice3.Font.FontFamily, 20, tbxGTBuyPrice3.Font.Style);

                goldPrice3.Id = (int)dgvGoldPrices.Rows[2].Cells[0].Value;
                goldPrice3.TypeId = (int)dgvGoldPrices.Rows[2].Cells[1].Value;
            }
        }
        //*

        private int hundredRounding(decimal price)
        {
            int result = 0;

            string mainPriceStr = price.ToString();// "62450" "62650"
            string hundredValStr = mainPriceStr.Substring((mainPriceStr.Length - 3), 3);// "450" "650"

            int hundredValStrInt = 0;
            int.TryParse(hundredValStr, out hundredValStrInt);// 450 650

            if (hundredValStrInt >= 500)
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

            return mainPriceInt.ToString();// "63000"
        }
        private void btnGoldPricesExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearControls()
        {
            tbxGTSellPrice1.Text = "";
            tbxGTSellPrice1.Tag = null;

            tbxGTSellPrice2.Text = "";
            tbxGTSellPrice2.Tag = null;

            tbxGTSellPrice3.Text = "";
            tbxGTSellPrice3.Tag = null;

            tbxDifferPrice.Text = "";
            tbxGTBuyPrice1.Text = "";
            tbxGTBuyPrice2.Text = "";
            tbxGTBuyPrice3.Text = "";

            dgvGoldPrices.DataSource = goldPrice.getPrices();
            
            _index0 = -1;
            _index1 = -1;
            _index2 = -1;
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
                MessageBox.Show("Please Input Sell Price!");
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
                    sellPrice1FontSize = tbxGTSellPrice1.Font.Size;
                }
            }
        }

        private void btnSellPriceFont2_Click(object sender, EventArgs e)
        {
            if (tbxGTSellPrice2.Text == string.Empty)
            {
                MessageBox.Show("Please Input Sell Price!");
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
                    sellPrice2FontSize = tbxGTSellPrice2.Font.Size;
                }
            }
        }

        private void btnSellPriceFont3_Click(object sender, EventArgs e)
        {
            if (tbxGTSellPrice3.Text == string.Empty)
            {
                MessageBox.Show("Please Input Sell Price!");
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
                    sellPrice3FontSize = tbxGTSellPrice3.Font.Size;
                }
            }
        }

        private void btnSellPriceColor1_Click(object sender, EventArgs e)
        {
            if (tbxGTSellPrice1.Text == string.Empty)
            {
                MessageBox.Show("Please Input Sell Price!");
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
                MessageBox.Show("Please Input Sell Price!");
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
                MessageBox.Show("Please Input Sell Price!");
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
                MessageBox.Show("Please Input Buy Price!");
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
                    buyPrice1FontSize = tbxGTBuyPrice1.Font.Size;
                }
            }
        }

        private void btnBuyPriceFont2_Click(object sender, EventArgs e)
        {
            if (tbxGTBuyPrice2.Text == string.Empty)
            {
                MessageBox.Show("Please Input Buy Price!");
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
                    buyPrice2FontSize = tbxGTBuyPrice2.Font.Size;
                }
            }
        }

        private void btnBuyPriceFont3_Click(object sender, EventArgs e)
        {
            if (tbxGTBuyPrice3.Text == string.Empty)
            {
                MessageBox.Show("Please Input Buy Price!");
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
                    buyPrice3FontSize = tbxGTBuyPrice3.Font.Size;
                }
            }
        }

        private void btnBuyPriceColor1_Click(object sender, EventArgs e)
        {
            if (tbxGTBuyPrice1.Text == string.Empty)
            {
                MessageBox.Show("Please Input Buy Price!");
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
                MessageBox.Show("Please Input Buy Price!");
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
                MessageBox.Show("Please Input Buy Price!");
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
