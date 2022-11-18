namespace Libarary.GUI
{
    partial class HistoryGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.borrowDGV = new System.Windows.Forms.DataGridView();
            this.returnDGV = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.from = new System.Windows.Forms.DateTimePicker();
            this.to = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBorrower = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.borrowDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(325, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Borrowed Books";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(325, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "Returned Books";
            // 
            // borrowDGV
            // 
            this.borrowDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.borrowDGV.Location = new System.Drawing.Point(12, 92);
            this.borrowDGV.Name = "borrowDGV";
            this.borrowDGV.RowHeadersWidth = 51;
            this.borrowDGV.RowTemplate.Height = 29;
            this.borrowDGV.Size = new System.Drawing.Size(822, 144);
            this.borrowDGV.TabIndex = 1;
            // 
            // returnDGV
            // 
            this.returnDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.returnDGV.Location = new System.Drawing.Point(12, 276);
            this.returnDGV.Name = "returnDGV";
            this.returnDGV.RowHeadersWidth = 51;
            this.returnDGV.RowTemplate.Height = 29;
            this.returnDGV.Size = new System.Drawing.Size(822, 162);
            this.returnDGV.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "To";
            // 
            // from
            // 
            this.from.Location = new System.Drawing.Point(61, 4);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(250, 27);
            this.from.TabIndex = 5;
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(61, 36);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(250, 27);
            this.to.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(509, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Borrower Number";
            // 
            // txtBorrower
            // 
            this.txtBorrower.Location = new System.Drawing.Point(643, 9);
            this.txtBorrower.Name = "txtBorrower";
            this.txtBorrower.Size = new System.Drawing.Size(125, 27);
            this.txtBorrower.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(643, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // HistoryGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBorrower);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.returnDGV);
            this.Controls.Add(this.borrowDGV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HistoryGUI";
            this.Text = "HistoryGUI";
            this.Load += new System.EventHandler(this.HistoryGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.borrowDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView borrowDGV;
        private DataGridView returnDGV;
        private Label label3;
        private Label label4;
        private DateTimePicker from;
        private DateTimePicker to;
        private Label label5;
        private TextBox txtBorrower;
        private Button btnSearch;
    }
}