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
    public partial class BookEditGUI : Form
    {
        private Book book; 
        public event EventHandler update;
        public BookEditGUI(Book book)
        {
            InitializeComponent();
            this.book = book;
        }

        private void BookEditGUI_Load(object sender, EventArgs e)
        {
            textBox1.Text = book.BookNumber.ToString();
            textBox3.Text = book.Title;
            textBox2.Text = book.Author;
            textBox4.Text = book.Publisher;
            renderDGV();
        }
        private void renderDGV()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("bookCol", "Book");
            dataGridView1.Columns["bookCol"].DataPropertyName = "BookNumberNavigation";
            dataGridView1.Columns.Add("copyCol", "Copy Number");
            dataGridView1.Columns["copyCol"].DataPropertyName = "CopyNumber";
            dataGridView1.Columns.Add("seqCol", "Sequence Number");
            dataGridView1.Columns["seqCol"].DataPropertyName = "SequenceNumber";
            dataGridView1.Columns.Add("typeCol", "Type");
            dataGridView1.Columns["typeCol"].DataPropertyName = "Type";
            dataGridView1.Columns.Add("priceCol", "Price");
            dataGridView1.Columns["priceCol"].DataPropertyName = "Price";
            DataGridViewButtonColumn editcol = new DataGridViewButtonColumn();
            editcol.Name = "Edit";
            editcol.HeaderText = "Edit";
            editcol.Text = "Edit";
            editcol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editcol);
            using (var db = new LibararyContext())
            {
                List<Copy> listCop = db.Copies.Include(x => x.BookNumberNavigation).Where(x => x.BookNumber == this.book.BookNumber).ToList();
                dataGridView1.DataSource = listCop;
                lbCount.Text = "The number of copy: " + listCop.Count.ToString();
            }
        }
        private void reload(object sender, EventArgs e)
        {
            renderDGV();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            book.Title = textBox3.Text;
            book.Author = textBox2.Text;
            book.Publisher = textBox4.Text;
            using (var db = new LibararyContext())
            {
                db.Books.Update(book);
                db.SaveChanges();
                update.Invoke(sender, e);
                renderDGV();
                MessageBox.Show("Uppdate Successfully!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CopyAddGUI ca = new CopyAddGUI(book,null);
            ca.add += reload;
            ca.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    var id = dataGridView1.Rows[e.RowIndex].Cells["copyCol"].Value;
                    var bookId = int.Parse(textBox1.Text);
                    using (var db = new LibararyContext())
                    {
                        var copy = db.Copies.Find(id);
                        var book = db.Books.Find(bookId);
                        CopyAddGUI be = new CopyAddGUI(book,copy);
                        be.add += reload;
                        be.ShowDialog();
                    }
                }
            }
        }
    }
}
