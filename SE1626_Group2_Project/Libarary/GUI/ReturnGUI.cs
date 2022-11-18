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
    public partial class ReturnGUI : Form
    {
        private Borrower borrower = null;
        public ReturnGUI()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int borrowNum;
            try
            {
                borrowNum = int.Parse(tbBorrowNum.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid Borrower Number!");
                return;
            }
            using (var db = new LibararyContext())
            {
                borrower = db.Borrowers.Where(x => x.BorrowerNumber == borrowNum).FirstOrDefault();
                if (borrower == null)
                {
                    MessageBox.Show("Can't Find this Borrower!");
                }
            }
            renderBorrower();
            renderDGV();
        }

        private void renderBorrower()
        {
            if (borrower == null)
            {
                tbName.Text = "";
                tbAddress.Text = "";
                tbEmail.Text = "";
                tbTel.Text = "";
                tbSex.Text = "";
            }
            else
            {
                tbName.Text = borrower.Name;
                tbAddress.Text = borrower.Address;
                tbEmail.Text = borrower.Email;
                tbTel.Text = borrower.Telephone;
                tbSex.Text = borrower.Sex == true ? "Male" : "Female";
            }
        }

        private void renderDGV()
        {
            if (borrower == null)
            {
                dataGridView1.Columns.Clear();
                return;
            }
            using (var db = new LibararyContext())
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("idCol", "ID");
                dataGridView1.Columns["idCol"].DataPropertyName = "Id";
                dataGridView1.Columns.Add("bookCol", "Book");
                dataGridView1.Columns["bookCol"].DataPropertyName = "CopyNumberNavigation";
                dataGridView1.Columns.Add("copyCol", "Copy Number");
                dataGridView1.Columns["copyCol"].DataPropertyName = "CopyNumber";
                dataGridView1.Columns.Add("dateCol", "Borrowed Date");
                dataGridView1.Columns["dateCol"].DataPropertyName = "BorrowedDate";
                dataGridView1.Columns.Add("dueCol", "Due Date");
                dataGridView1.Columns["dueCol"].DataPropertyName = "DueDate";
                DataGridViewButtonColumn returnCol = new DataGridViewButtonColumn();
                returnCol.Name = "Return";
                returnCol.HeaderText = "Return";
                returnCol.Text = "Return";
                returnCol.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(returnCol);
                var totalBorrow = db.CirculatedCopies.Include(x => x.CopyNumberNavigation)
                    .Where(x => x.BorrowerNumber == borrower.BorrowerNumber && x.ReturnedDate == null).ToList();
                dataGridView1.DataSource = totalBorrow;

            }
        }

        private int fineAmount(DateTime brDate, DateTime dueDate, DateTime returnDate)
        {
            int fine = 0;
            if (returnDate > dueDate)
            {
                fine = (returnDate - dueDate).Days;
            }
            return fine;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                using (var db = new LibararyContext())
                {
                    var circulate = db.CirculatedCopies.Where(x => x.Id == id).FirstOrDefault();
                    circulate.ReturnedDate = DateTime.Now;
                    circulate.FineAmount = fineAmount(circulate.BorrowedDate.Value, circulate.DueDate.Value, circulate.ReturnedDate.Value);
                    if (db.SaveChanges() > 0)
                    {
                        //change status of copy
                        var copy = db.Copies.Where(x => x.CopyNumber == circulate.CopyNumber).FirstOrDefault();
                        copy.Type = "available";
                        if (db.SaveChanges() > 0)
                        {
                            MessageBox.Show($"Return Success!\nFine Amount: {circulate.FineAmount}");
                            int bookNumber = (int)copy.BookNumber;
                            var reservation = db.Reservations.Where(x => x.BookNumber == bookNumber && x.Status == true).FirstOrDefault();
                            if(reservation != null)
                            {
                                reservation.Status = false;
                                //create a circulated copy
                                CirculatedCopy newCirculate = new CirculatedCopy();
                                newCirculate.BorrowerNumber = reservation.BorrowerNumber;
                                newCirculate.CopyNumber = copy.CopyNumber;
                                newCirculate.BorrowedDate = DateTime.Now;
                                newCirculate.DueDate = DateTime.Now.AddDays(14);
                                db.CirculatedCopies.Add(newCirculate);
                                if (db.SaveChanges() > 0)
                                {
                                    MessageBox.Show("The book was borrowed by another person with reservation!");
                                }
                            }
                        }
                    }
                }
                renderDGV();
            }
        }
    }
}
