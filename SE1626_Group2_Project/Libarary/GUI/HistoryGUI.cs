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
    public partial class HistoryGUI : Form
    {
        public HistoryGUI()
        {
            InitializeComponent();
        }

        private void HistoryGUI_Load(object sender, EventArgs e)
        {
            to.MinDate = from.Value;
            renderBorrow();
            renderReturn();
        }

        private void renderBorrow()
        {
            using (var db = new LibararyContext())
            {
                borrowDGV.Columns.Clear();
                borrowDGV.AutoGenerateColumns = false;
                borrowDGV.Columns.Add("idCol", "ID");
                borrowDGV.Columns["idCol"].DataPropertyName = "Id";
                borrowDGV.Columns.Add("borrowerCol", "Borrower");
                borrowDGV.Columns["borrowerCol"].DataPropertyName = "BorrowerNumberNavigation";
                borrowDGV.Columns.Add("bookCol", "Book");
                borrowDGV.Columns["bookCol"].DataPropertyName = "CopyNumberNavigation";
                borrowDGV.Columns.Add("copyCol", "Copy Number");
                borrowDGV.Columns["copyCol"].DataPropertyName = "CopyNumber";
                borrowDGV.Columns.Add("dateCol", "Borrowed Date");
                borrowDGV.Columns["dateCol"].DataPropertyName = "BorrowedDate";
                borrowDGV.Columns.Add("dueCol", "Due Date");
                borrowDGV.Columns["dueCol"].DataPropertyName = "DueDate";
                var totalBorrow = db.CirculatedCopies.Include(x => x.CopyNumberNavigation).Include(x => x.BorrowerNumberNavigation)
                   .Where(x => x.ReturnedDate == null).ToList();
                borrowDGV.DataSource = totalBorrow;
                
            }
        }
        private void renderReturn()
        {
            using (var db = new LibararyContext())
            {
                returnDGV.Columns.Clear();
                returnDGV.AutoGenerateColumns = false;
                returnDGV.Columns.Add("idCol", "ID");
                returnDGV.Columns["idCol"].DataPropertyName = "Id";
                returnDGV.Columns.Add("borrowerCol", "Borrower");
                returnDGV.Columns["borrowerCol"].DataPropertyName = "BorrowerNumberNavigation";
                returnDGV.Columns.Add("bookCol", "Book");
                returnDGV.Columns["bookCol"].DataPropertyName = "CopyNumberNavigation";
                returnDGV.Columns.Add("copyCol", "Copy Number");
                returnDGV.Columns["copyCol"].DataPropertyName = "CopyNumber";
                returnDGV.Columns.Add("dateCol", "Borrowed Date");
                returnDGV.Columns["dateCol"].DataPropertyName = "BorrowedDate";
                returnDGV.Columns.Add("dueCol", "Due Date");
                returnDGV.Columns["dueCol"].DataPropertyName = "DueDate";
                returnDGV.Columns.Add("returnCol", "Return Date");
                returnDGV.Columns["returnCol"].DataPropertyName = "ReturnedDate";
                returnDGV.Columns.Add("fineCol", "Fine Amount");
                returnDGV.Columns["fineCol"].DataPropertyName = "FineAmount";
                var totalBorrow = db.CirculatedCopies.Include(x => x.CopyNumberNavigation).Include(x => x.BorrowerNumberNavigation)
                   .Where(x => x.ReturnedDate != null).ToList();
                   returnDGV.DataSource = totalBorrow;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = from.Value;
            DateTime dateTo = to.Value;
            int borrowerId = 0;
            try
            {
                if (txtBorrower.Text.Equals(""))
                {
                    using (var db = new LibararyContext())
                    {
                        var totalBorrow = db.CirculatedCopies.Include(x => x.CopyNumberNavigation).Include(x => x.BorrowerNumberNavigation)
                            .Where(x => x.BorrowedDate >= dateFrom
                            && x.BorrowedDate <= dateTo
                            && x.ReturnedDate == null).ToList();
                        borrowDGV.DataSource = totalBorrow;
                        var totalReturn = db.CirculatedCopies.Include(x => x.CopyNumberNavigation).Include(x => x.BorrowerNumberNavigation)
                            .Where(x => x.BorrowedDate >= dateFrom
                            && x.BorrowedDate <= dateTo
                            && x.ReturnedDate != null).ToList();
                        returnDGV.DataSource = totalReturn;
                    }
                }
                else
                {
                    borrowerId = int.Parse(txtBorrower.Text);
                    using (var db = new LibararyContext())
                    {
                        var totalBorrow = db.CirculatedCopies.Include(x => x.CopyNumberNavigation).Include(x => x.BorrowerNumberNavigation)
                            .Where(x => x.BorrowerNumber == borrowerId
                            && x.BorrowedDate >= dateFrom
                            && x.BorrowedDate <= dateTo
                            && x.ReturnedDate == null).ToList();
                        borrowDGV.DataSource = totalBorrow;
                        var totalReturn = db.CirculatedCopies.Include(x => x.CopyNumberNavigation).Include(x => x.BorrowerNumberNavigation)
                            .Where(x => x.BorrowerNumber == borrowerId
                            && x.BorrowedDate >= dateFrom
                            && x.BorrowedDate <= dateTo
                            && x.ReturnedDate != null).ToList();
                        returnDGV.DataSource = totalReturn;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please enter valid number!");
            }
        }
    }
}
