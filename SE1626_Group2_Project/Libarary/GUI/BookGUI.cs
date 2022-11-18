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
    public partial class BookGUI : Form
    {
        public BookGUI()
        {
            InitializeComponent();
        }

        private void BookGUI_Load(object sender, EventArgs e)
        {
            using (var db = new LibararyContext())
            {
                var authors = db.Books.Select(x => x.Author).Distinct().ToList();
                //add option 'all' to combobox
                authors.Insert(0, "All");
                comboBox1.DataSource = authors;
            }
            renderDGV();
        }
        private void count(string title, string author)
        {
            using (var db = new LibararyContext())
            {
                var count = db.Books.Where(x => x.Title.Contains(title) && x.Author.Contains(author)).ToList().Count();
                label3.Text = "The number of book: " + count;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (var db = new LibararyContext())
            {
                var title = tbTitle.Text;
                var author = comboBox1.SelectedValue.ToString().Equals("All") ? "" : comboBox1.SelectedValue.ToString();
                var books = db.Books.Where(x => x.Title.Contains(title) && x.Author.Contains(author)).ToList();
                dataGridView1.DataSource = books;
                count(title, author);
            }
        }
        private void renderDGV()
        {
            using (var db = new LibararyContext())
            {
                dataGridView1.Columns.Clear();
                var books = db.Books.ToList();
                dataGridView1.DataSource = books;
                count("", "");
                dataGridView1.Columns["Copies"].Visible = false;
                dataGridView1.Columns["Reservations"].Visible = false;
                DataGridViewButtonColumn editcol = new DataGridViewButtonColumn();
                editcol.Name = "Edit";
                editcol.HeaderText = "Edit";
                editcol.Text = "Edit";
                editcol.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(editcol);
            }

        }
        private void reload(object sender, EventArgs e)
        {
            using (var db = new LibararyContext())
            {
                var authors = db.Books.Select(x => x.Author).Distinct().ToList();
                //add option 'all' to combobox
                authors.Insert(0, "All");
                comboBox1.DataSource = authors;
            }
            renderDGV();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    var id = dataGridView1.Rows[e.RowIndex].Cells["BookNumber"].Value;
                    using (var db = new LibararyContext())
                    {
                        var book = db.Books.Find(id);
                        BookEditGUI be = new BookEditGUI(book);
                        be.update += reload;
                        be.ShowDialog();
                    }
                    renderDGV();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            BookAddGUI ba = new BookAddGUI();
            ba.add += reload;
            ba.ShowDialog();
        }
    }
}