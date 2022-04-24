namespace MYOGoldTypePriceManagement
{
    partial class manageGoldTypesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblGoldTypeInput = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.dgvGoldTypes = new System.Windows.Forms.DataGridView();
            this.txtBxGoldTypeInput = new System.Windows.Forms.TextBox();
            this.btnGoldTypeInputOK = new System.Windows.Forms.Button();
            this.btnGoldTypeFontEdit = new System.Windows.Forms.Button();
            this.btnGoldTypeColorEdit = new System.Windows.Forms.Button();
            this.btnGoldTypeInputUpdate = new System.Windows.Forms.Button();
            this.btnGoldTypeInputDelete = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGoldTypeInputExit = new System.Windows.Forms.Button();
            this.btnGoldTypeInputClear = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoldTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGoldTypeInput
            // 
            this.lblGoldTypeInput.AutoSize = true;
            this.lblGoldTypeInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGoldTypeInput.Font = new System.Drawing.Font("Pyidaungsu", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoldTypeInput.Location = new System.Drawing.Point(20, 19);
            this.lblGoldTypeInput.Name = "lblGoldTypeInput";
            this.lblGoldTypeInput.Size = new System.Drawing.Size(252, 48);
            this.lblGoldTypeInput.TabIndex = 0;
            this.lblGoldTypeInput.Text = "ရွှေအမျိုးအစားအမည်";
            // 
            // dgvGoldTypes
            // 
            this.dgvGoldTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGoldTypes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoldTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGoldTypes.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGoldTypes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGoldTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoldTypes.Location = new System.Drawing.Point(921, 2);
            this.dgvGoldTypes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvGoldTypes.Name = "dgvGoldTypes";
            this.dgvGoldTypes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoldTypes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGoldTypes.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGoldTypes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGoldTypes.RowTemplate.Height = 24;
            this.dgvGoldTypes.Size = new System.Drawing.Size(587, 721);
            this.dgvGoldTypes.TabIndex = 2;
            this.dgvGoldTypes.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGoldTypes_RowHeaderMouseClick);
            // 
            // txtBxGoldTypeInput
            // 
            this.txtBxGoldTypeInput.AllowDrop = true;
            this.txtBxGoldTypeInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxGoldTypeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxGoldTypeInput.Location = new System.Drawing.Point(0, 0);
            this.txtBxGoldTypeInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBxGoldTypeInput.Multiline = true;
            this.txtBxGoldTypeInput.Name = "txtBxGoldTypeInput";
            this.txtBxGoldTypeInput.Size = new System.Drawing.Size(883, 351);
            this.txtBxGoldTypeInput.TabIndex = 3;
            // 
            // btnGoldTypeInputOK
            // 
            this.btnGoldTypeInputOK.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGoldTypeInputOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoldTypeInputOK.ForeColor = System.Drawing.Color.White;
            this.btnGoldTypeInputOK.Location = new System.Drawing.Point(20, 21);
            this.btnGoldTypeInputOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoldTypeInputOK.Name = "btnGoldTypeInputOK";
            this.btnGoldTypeInputOK.Size = new System.Drawing.Size(96, 57);
            this.btnGoldTypeInputOK.TabIndex = 4;
            this.btnGoldTypeInputOK.Text = "Add";
            this.btnGoldTypeInputOK.UseVisualStyleBackColor = false;
            this.btnGoldTypeInputOK.Click += new System.EventHandler(this.btnGoldTypeInputOK_Click);
            // 
            // btnGoldTypeFontEdit
            // 
            this.btnGoldTypeFontEdit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGoldTypeFontEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoldTypeFontEdit.ForeColor = System.Drawing.Color.White;
            this.btnGoldTypeFontEdit.Location = new System.Drawing.Point(677, 20);
            this.btnGoldTypeFontEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoldTypeFontEdit.Name = "btnGoldTypeFontEdit";
            this.btnGoldTypeFontEdit.Size = new System.Drawing.Size(112, 57);
            this.btnGoldTypeFontEdit.TabIndex = 5;
            this.btnGoldTypeFontEdit.Text = "Font";
            this.btnGoldTypeFontEdit.UseVisualStyleBackColor = false;
            this.btnGoldTypeFontEdit.Click += new System.EventHandler(this.btnGoldTypeFontEdit_Click);
            // 
            // btnGoldTypeColorEdit
            // 
            this.btnGoldTypeColorEdit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGoldTypeColorEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoldTypeColorEdit.ForeColor = System.Drawing.Color.White;
            this.btnGoldTypeColorEdit.Location = new System.Drawing.Point(796, 21);
            this.btnGoldTypeColorEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoldTypeColorEdit.Name = "btnGoldTypeColorEdit";
            this.btnGoldTypeColorEdit.Size = new System.Drawing.Size(112, 57);
            this.btnGoldTypeColorEdit.TabIndex = 6;
            this.btnGoldTypeColorEdit.Text = "Color";
            this.btnGoldTypeColorEdit.UseVisualStyleBackColor = false;
            this.btnGoldTypeColorEdit.Click += new System.EventHandler(this.btnGoldTypeColorEdit_Click);
            // 
            // btnGoldTypeInputUpdate
            // 
            this.btnGoldTypeInputUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGoldTypeInputUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoldTypeInputUpdate.ForeColor = System.Drawing.Color.White;
            this.btnGoldTypeInputUpdate.Location = new System.Drawing.Point(123, 21);
            this.btnGoldTypeInputUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoldTypeInputUpdate.Name = "btnGoldTypeInputUpdate";
            this.btnGoldTypeInputUpdate.Size = new System.Drawing.Size(141, 57);
            this.btnGoldTypeInputUpdate.TabIndex = 7;
            this.btnGoldTypeInputUpdate.Text = "Update";
            this.btnGoldTypeInputUpdate.UseVisualStyleBackColor = false;
            this.btnGoldTypeInputUpdate.Click += new System.EventHandler(this.btnGoldTypeInputUpdate_Click);
            // 
            // btnGoldTypeInputDelete
            // 
            this.btnGoldTypeInputDelete.BackColor = System.Drawing.Color.OrangeRed;
            this.btnGoldTypeInputDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoldTypeInputDelete.ForeColor = System.Drawing.Color.White;
            this.btnGoldTypeInputDelete.Location = new System.Drawing.Point(269, 21);
            this.btnGoldTypeInputDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoldTypeInputDelete.Name = "btnGoldTypeInputDelete";
            this.btnGoldTypeInputDelete.Size = new System.Drawing.Size(141, 57);
            this.btnGoldTypeInputDelete.TabIndex = 8;
            this.btnGoldTypeInputDelete.Text = "Delete";
            this.btnGoldTypeInputDelete.UseVisualStyleBackColor = false;
            this.btnGoldTypeInputDelete.Click += new System.EventHandler(this.btnGoldTypeInputDelete_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(32, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtBxGoldTypeInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(883, 721);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGoldTypeFontEdit);
            this.groupBox1.Controls.Add(this.btnGoldTypeInputExit);
            this.groupBox1.Controls.Add(this.btnGoldTypeInputUpdate);
            this.groupBox1.Controls.Add(this.btnGoldTypeInputClear);
            this.groupBox1.Controls.Add(this.btnGoldTypeInputDelete);
            this.groupBox1.Controls.Add(this.btnGoldTypeInputOK);
            this.groupBox1.Controls.Add(this.btnGoldTypeColorEdit);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(931, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // btnGoldTypeInputExit
            // 
            this.btnGoldTypeInputExit.BackColor = System.Drawing.Color.Crimson;
            this.btnGoldTypeInputExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoldTypeInputExit.ForeColor = System.Drawing.Color.White;
            this.btnGoldTypeInputExit.Location = new System.Drawing.Point(513, 21);
            this.btnGoldTypeInputExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoldTypeInputExit.Name = "btnGoldTypeInputExit";
            this.btnGoldTypeInputExit.Size = new System.Drawing.Size(89, 57);
            this.btnGoldTypeInputExit.TabIndex = 10;
            this.btnGoldTypeInputExit.Text = "Exit";
            this.btnGoldTypeInputExit.UseVisualStyleBackColor = false;
            this.btnGoldTypeInputExit.Click += new System.EventHandler(this.btnGoldTypeInputExit_Click);
            // 
            // btnGoldTypeInputClear
            // 
            this.btnGoldTypeInputClear.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnGoldTypeInputClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoldTypeInputClear.Location = new System.Drawing.Point(419, 21);
            this.btnGoldTypeInputClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGoldTypeInputClear.Name = "btnGoldTypeInputClear";
            this.btnGoldTypeInputClear.Size = new System.Drawing.Size(89, 57);
            this.btnGoldTypeInputClear.TabIndex = 9;
            this.btnGoldTypeInputClear.Text = "Clear";
            this.btnGoldTypeInputClear.UseVisualStyleBackColor = false;
            this.btnGoldTypeInputClear.Click += new System.EventHandler(this.btnGoldTypeInputClear_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblGoldTypeInput);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(1540, 796);
            this.splitContainer2.SplitterDistance = 67;
            this.splitContainer2.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvGoldTypes, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(29, 0, 29, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 725F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1540, 725);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // manageGoldTypesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 796);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "manageGoldTypesForm";
            this.Text = "Manage Gold Types";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoldTypes)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGoldTypeInput;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.DataGridView dgvGoldTypes;
        private System.Windows.Forms.TextBox txtBxGoldTypeInput;
        private System.Windows.Forms.Button btnGoldTypeInputOK;
        private System.Windows.Forms.Button btnGoldTypeFontEdit;
        private System.Windows.Forms.Button btnGoldTypeColorEdit;
        private System.Windows.Forms.Button btnGoldTypeInputUpdate;
        private System.Windows.Forms.Button btnGoldTypeInputDelete;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnGoldTypeInputExit;
        private System.Windows.Forms.Button btnGoldTypeInputClear;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}