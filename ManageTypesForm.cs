using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYOGoldTypePriceManagement
{
    public partial class manageGoldTypesForm : Form
    {
        GoldType goldType = new GoldType();

        public manageGoldTypesForm()
        {
            InitializeComponent();
            dgvGoldTypes.DataSource = goldType.GetTypes();
        }

        private void btnGoldTypeInputOK_Click(object sender, EventArgs e)
        {
            var isValid = false;

            goldType.Name = txtBxGoldTypeInput.Text;

            if(goldType.Color == null || goldType.Font == null)
            {
                isValid = false;
                MessageBox.Show("Font နဲ့ Color ရွေးချယ်သတ်မှတ်ပေးပါ!");
            }
            else
            {
                isValid = true;
            }

            if (isValid)
            {
                var success = goldType.InsertType(goldType);

                //refresh data-grid-view
                dgvGoldTypes.DataSource = goldType.GetTypes();

                if (success)
                {
                    ClearControls();
                    MessageBox.Show("အသစ်ထည့်သွင်းခြင်း အောင်မြင်ပါသည်!");
                }
                else
                {
                    MessageBox.Show("အသစ်ထည့်သွင်းခြင်း လုပ်ဆောင်မှု မအောင်မြင်ပါ။ ထပ်မံ ပြုလုပ်ပါ...");
                }
            }
        }

        private void btnGoldTypeInputUpdate_Click(object sender, EventArgs e)
        {
            var isValid = false;

            goldType.Name = txtBxGoldTypeInput.Text;

            if (goldType.Color == null || goldType.Font == null)
            {
                isValid = false;
                MessageBox.Show("Font နဲ့ Color ရွေးချယ်သတ်မှတ်ပေးပါ!");
            }
            else
            {
                isValid = true;
            }

            if (isValid)
            {
                var success = goldType.UpdateType(goldType);

                //refresh data-grid-view
                dgvGoldTypes.DataSource = goldType.GetTypes();

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
        }

        private void btnGoldTypeInputDelete_Click(object sender, EventArgs e)
        {
            var success = goldType.DeleteType(goldType);

            dgvGoldTypes.DataSource = goldType.GetTypes();

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

        private void btnGoldTypeFontEdit_Click(object sender, EventArgs e)
        {
            if (txtBxGoldTypeInput.Text == string.Empty)
            {
                MessageBox.Show("ရွှေအမျိုးအစားအမည် ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = fontDialog1.ShowDialog(this);

                if (R == DialogResult.OK)
                {
                    /*
                     var cvt = new FontConverter();
                     string s = cvt.ConvertToString(this.Font);
                     Font f = cvt.ConvertFromString(s) as Font;
                     */
                    txtBxGoldTypeInput.Font = fontDialog1.Font;

                    var cvt = new FontConverter();
                    string fs = cvt.ConvertToString(fontDialog1.Font);

                    goldType.Font = fs;
                }
            }
        }

        private void btnGoldTypeColorEdit_Click(object sender, EventArgs e)
        {
            if (txtBxGoldTypeInput.Text == string.Empty)
            {
                MessageBox.Show("ရွှေအမျိုးအစားအမည် ထည့်သွင်းပေးပါ!");
            }
            else
            {
                DialogResult R = colorDialog1.ShowDialog();

                if (R == DialogResult.OK)
                {
                    //this.BackColor= colorDialog1.Color;
                    txtBxGoldTypeInput.ForeColor = colorDialog1.Color;

                    goldType.Color = colorDialog1.Color.ToArgb();
                }
            }
        }

        private void ClearControls()
        {
            txtBxGoldTypeInput.Text = "";
        }

        private void dgvGoldTypes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            var cvt = new FontConverter();

            goldType.Id = (int)dgvGoldTypes.Rows[index].Cells[0].Value;
            txtBxGoldTypeInput.Text = dgvGoldTypes.Rows[index].Cells[1].Value.ToString();
            txtBxGoldTypeInput.ForeColor = Color.FromArgb((int)dgvGoldTypes.Rows[index].Cells[2].Value);
            txtBxGoldTypeInput.Font = cvt.ConvertFromString(dgvGoldTypes.Rows[index].Cells[3].Value.ToString()) as Font ;

            goldType.Color = (int)dgvGoldTypes.Rows[index].Cells[2].Value;
            goldType.Font = dgvGoldTypes.Rows[index].Cells[3].Value.ToString();
        }

        private void btnGoldTypeInputClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnGoldTypeInputExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
