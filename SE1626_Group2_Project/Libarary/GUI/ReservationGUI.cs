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
    public partial class ReservationGUI : Form
    {
        public ReservationGUI()
        {
            InitializeComponent();
        }

        private void format()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("reserId", "Reservation ID");
            dataGridView1.Columns.Add("borrowerId", "Borrower ID");
            dataGridView1.Columns.Add("borrowerName", "Borrower Name");
            dataGridView1.Columns.Add("bookId", "Book ID");
            dataGridView1.Columns.Add("bookName", "Book Name");
            dataGridView1.Columns.Add("date", "Date");
            dataGridView1.Columns.Add("status", "Status");

            dataGridView1.Columns["reserId"].DataPropertyName = "ID";
            dataGridView1.Columns["borrowerId"].DataPropertyName = "borrowerNumber";
            dataGridView1.Columns["borrowerName"].DataPropertyName = "name";
            dataGridView1.Columns["bookId"].DataPropertyName = "bookNumber";
            dataGridView1.Columns["bookName"].DataPropertyName = "title";
            dataGridView1.Columns["date"].DataPropertyName = "date";
            dataGridView1.Columns["status"].DataPropertyName = "status";

            dataGridView1.Columns["borrowerId"].Visible = false;
            dataGridView1.Columns["bookId"].Visible = false;

        }

        private void loadDgv()
        {
            using (var db = new LibararyContext())
            {
                var reser = from r in db.Reservations
                            join b in db.Books on r.BookNumber equals b.BookNumber
                            join br in db.Borrowers on r.BorrowerNumber equals br.BorrowerNumber
                            select new
                            {
                                ID = r.Id,
                                borrowerNumber = br.BorrowerNumber,
                                name = br.Name,
                                bookNumber = b.BookNumber,
                                title = b.Title,
                                date = r.Date,
                                status = r.Status
                            };
                dataGridView1.DataSource = reser.ToList();
            }
        }

        private void ReservationGUI_Load(object sender, EventArgs e)
        {
            format();
            loadDgv();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                int borrowerNum = int.Parse(txtBorrowerId.Text);
                using (var db = new LibararyContext())
                {
                    var dup = db.Reservations.Where(x => x.BorrowerNumber == borrowerNum && x.Status == true).FirstOrDefault();
                    if (dup != null)
                    {
                        panel1.Visible = false;
                        MessageBox.Show("This borrower has already reserved a book!");
                        var reser = from r in db.Reservations
                                    join b in db.Books on r.BookNumber equals b.BookNumber
                                    join br in db.Borrowers on r.BorrowerNumber equals br.BorrowerNumber
                                    where (r.BorrowerNumber == borrowerNum)
                                    select new
                                    {
                                        ID = r.Id,
                                        borrowerNumber = br.BorrowerNumber,
                                        name = br.Name,
                                        bookNumber = b.BookNumber,
                                        title = b.Title,
                                        date = r.Date,
                                        status = r.Status
                                    };
                        dataGridView1.DataSource = reser.ToList();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Available!");
                        panel1.Visible = true;
                        loadDgv();
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid Borrower Number!");
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    var rs = MessageBox.Show("Do you want to delete?",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        using (var db = new LibararyContext())
                        {
                            //delete reservation
                            int id = (int)dataGridView1.Rows[e.RowIndex].Cells["reserId"].Value;
                            var reservation = db.Reservations.Find(id);
                            db.Reservations.Remove(reservation);
                            if (db.SaveChanges() > 0)
                            {
                                MessageBox.Show("Delete succesfully!");
                            }
                        }
                    }
                }
            }
            loadDgv();
        }

        private void txtBook_Click(object sender, EventArgs e)
        {
            SelectBookGUI sb = new SelectBookGUI(-1);
            sb.ShowDialog();
            if (sb.copy == null)
            {
                using (var db = new LibararyContext())
                {
                    Book b = db.Books.Where(x => x.BookNumber == sb.bookNumber).FirstOrDefault();
                    if (b != null)
                    {
                        txtBook.Text = b.Title;
                        txtBookId.Text = b.BookNumber.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("The book is available! Reject the reservation!");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //create a reservation
            try
            {
                int borrowerNum = int.Parse(txtBorrowerId.Text);
                int bookNum = int.Parse(txtBookId.Text);
                using (var db = new LibararyContext())
                {
                    Reservation r = new Reservation();
                    r.BorrowerNumber = borrowerNum;
                    r.BookNumber = bookNum;
                    r.Date = DateTime.Now;
                    r.Status = true;
                    db.Reservations.Add(r);
                    if (db.SaveChanges() > 0)
                    {
                        MessageBox.Show("Reservation created!");
                        loadDgv();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please fill all valid data!!!");
                return;
            }
        }
    }
}
