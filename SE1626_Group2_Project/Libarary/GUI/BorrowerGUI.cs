using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libarary.Models;

namespace Libarary.GUI
{
    public partial class BorrowerGUI : Form
    {
        public BorrowerGUI()
        {
            InitializeComponent();
        }

        private void renderDGV()
        {
            using (var db = new LibararyContext())
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Add("idCol", "Borrower Number");
                dataGridView1.Columns["idCol"].DataPropertyName = "BorrowerNumber";
                dataGridView1.Columns.Add("NameCol", "Name");
                dataGridView1.Columns["NameCol"].DataPropertyName = "Name";
                dataGridView1.Columns.Add("sexCol", "Sex");
                dataGridView1.Columns["sexCol"].DataPropertyName = "sexStr";
                dataGridView1.Columns.Add("AddressCol", "Address");
                dataGridView1.Columns["AddressCol"].DataPropertyName = "Address";
                dataGridView1.Columns.Add("TelephoneCol", "Telephone");
                dataGridView1.Columns["TelephoneCol"].DataPropertyName = "Telephone";
                dataGridView1.Columns.Add("EmailCol", "Email");
                dataGridView1.Columns["EmailCol"].DataPropertyName = "Email";
                DataGridViewButtonColumn editcol = new DataGridViewButtonColumn();
                editcol.Name = "Edit";
                editcol.HeaderText = "Edit";
                editcol.Text = "Edit";
                editcol.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(editcol);

                dataGridView1.DataSource = db.Borrowers.ToList();

            }
            count("");
        }

        private void count(string name)
        {
            using (var db = new LibararyContext())
            {

                lbCount.Text = "The number of borrower: " + db.Borrowers.Where(x => x.Name.Contains(name)).ToList().Count();
            }
        }

        private void BorrowerGUI_Load(object sender, EventArgs e)
        {
            renderDGV();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (var db = new LibararyContext())
            {
                dataGridView1.DataSource = db.Borrowers.Where(x => x.Name.Contains(tbName.Text)).ToList();
            }
            count(tbName.Text);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            BorrowerAddGUI ba = new BorrowerAddGUI(null);
            ba.add += reload;
            ba.ShowDialog();
        }

        private void reload(object? sender, EventArgs e)
        {
            renderDGV();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    var id = dataGridView1.Rows[e.RowIndex].Cells["idCol"].Value;
                    using (var db = new LibararyContext())
                    {
                        var borrower = db.Borrowers.Find(id);
                        BorrowerAddGUI be = new BorrowerAddGUI(borrower);
                        be.add += reload;
                        be.ShowDialog();
                    }
                }
            }
        }
    }
}
