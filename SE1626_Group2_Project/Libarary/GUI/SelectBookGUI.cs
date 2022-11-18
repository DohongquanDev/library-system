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
using Microsoft.EntityFrameworkCore;

namespace Libarary.GUI
{
    public partial class SelectBookGUI : Form
    {
        public int bookNumber;
        public SelectBookGUI(int x)
        {
            bookNumber = x;
            InitializeComponent();
        }
        public Copy copy = null;
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
        private void count(string title, string author)
        {
            using (var db = new LibararyContext())
            {
                var count = db.Books.Where(x => x.Title.Contains(title) && x.Author.Contains(author)).ToList().Count();
                label3.Text = "The number of book: " + count;
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
                editcol.Name = "Select";
                editcol.HeaderText = "Select";
                editcol.Text = "Select";
                editcol.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(editcol);
            }
        }

        private void SelectBookGUI_Load(object sender, EventArgs e)
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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Select")
                {
                    int id = (int)dataGridView1.Rows[e.RowIndex].Cells["BookNumber"].Value;
                    copy = getACopyBook(id);
                    if (bookNumber == 0)
                    {
                        if (copy != null)
                        {
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("This book now doesn't have any copy available!");
                        }
                    }
                    else if (bookNumber == -1)
                    {
                        bookNumber = id;
                        this.Close();
                    }

                }
            }
        }

        private Copy getACopyBook(int bookNumber)
        {
            using (var db = new LibararyContext())
            {
                var book = db.Books.Include(x => x.Copies).Where(x => x.BookNumber == bookNumber).FirstOrDefault();
                var copy = book.Copies.Where(x => x.Type == "available").FirstOrDefault();
                return copy;
            }
        }

    }
}
