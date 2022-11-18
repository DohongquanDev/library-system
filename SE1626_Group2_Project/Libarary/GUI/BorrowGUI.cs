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
    public partial class BorrowGUI : Form
    {
        private Borrower borrower = null;
        private Copy copy = null;
        public BorrowGUI()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
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

        private void btnRef_Click(object sender, EventArgs e)
        {
            this.borrower = null;
            renderBorrower();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            SelectBookGUI sb = new SelectBookGUI(0);
            sb.ShowDialog();
            if (sb.copy != null)
            {
                using (var db = new LibararyContext())
                {
                    Book b = db.Books.Where(x => x.BookNumber == sb.copy.BookNumber).FirstOrDefault();
                    tbBookBorrow.Text = b.Title;
                }
                copy = sb.copy;
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (borrower == null || copy == null)
            {
                MessageBox.Show("Please make sure you have selected Borrwer and Book!");
                return;
            }
            using (var db = new LibararyContext())
            {
                int count = db.CirculatedCopies.Where(x => x.ReturnedDate == null && x.BorrowerNumber == borrower.BorrowerNumber).ToList().Count();
                if (count > 4)
                {
                    MessageBox.Show("This Borrower has borrowed more than 5 books!");
                    return;
                }
            }
            CirculatedCopy circulatedCopy = new CirculatedCopy();
            circulatedCopy.BorrowedDate = dateTimePicker1.Value;
            circulatedCopy.DueDate = dateTimePicker1.Value.AddDays(14);
            circulatedCopy.BorrowerNumber = borrower.BorrowerNumber;
            circulatedCopy.CopyNumber = copy.CopyNumber;

            copy.Type = "unavailable";
            using (var db = new LibararyContext())
            {
                db.Update(copy);
                db.Add(circulatedCopy);
                db.SaveChanges();
                copy = null;
                tbBookBorrow.Text = "";
                MessageBox.Show("Borrow Successfully!");
            }
        }
    }
}
