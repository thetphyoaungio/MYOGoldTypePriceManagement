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
                MessageBox.Show("Please define Font and Color!");
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
                    MessageBox.Show("Added Successfully!");
                }
                else
                {
                    MessageBox.Show("Sorry, please try again...");
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
                MessageBox.Show("Please define Font and Color!");
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
                    MessageBox.Show("Updated Successfully!");
                }
                else
                {
                    MessageBox.Show("Sorry, please try again...");
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
                MessageBox.Show("Deleted Successfully!");
            }
            else
            {
                MessageBox.Show("Sorry, please try again...");
            }
        }

        private void btnGoldTypeFontEdit_Click(object sender, EventArgs e)
        {
            if (txtBxGoldTypeInput.Text == string.Empty)
            {
                MessageBox.Show("Please input Gold Type Name!");
            }
            else
            {
                DialogResult R = fontDialog1.ShowDialog(this);

                if (R == DialogResult.OK)
                {
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
                MessageBox.Show("Please input Gold Type Name!");
            }
            else
            {
                DialogResult R = colorDialog1.ShowDialog();

                if (R == DialogResult.OK)
                {
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

            btnGoldTypeInputOK.Enabled = false;
            btnGoldTypeInputUpdate.Enabled = true;
            btnGoldTypeInputDelete.Enabled = true;

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

        private void manageGoldTypesForm_Load(object sender, EventArgs e)
        {
            btnGoldTypeInputUpdate.Enabled = false;
            btnGoldTypeInputDelete.Enabled = false;
        }
    }
}
