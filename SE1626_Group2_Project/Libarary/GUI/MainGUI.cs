using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libarary.GUI
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //logout
            this.Hide();
            var login = new LoginGUI();
            login.ShowDialog();
            this.Close();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookGUI book = new BookGUI();
            book.TopLevel = false;
            book.FormBorderStyle = FormBorderStyle.None;
            book.Show();
            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(book);
        }

        private void borrowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowerGUI borrower = new BorrowerGUI();
            borrower.TopLevel = false;
            borrower.FormBorderStyle = FormBorderStyle.None;
            borrower.Show();
            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(borrower);
        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowGUI borrow = new BorrowGUI();
            borrow.TopLevel = false;
            borrow.FormBorderStyle = FormBorderStyle.None;
            borrow.Show();
            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(borrow);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnGUI returnGUI = new ReturnGUI();
            returnGUI.TopLevel = false;
            returnGUI.FormBorderStyle = FormBorderStyle.None;
            returnGUI.Show();
            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(returnGUI);
        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReservationGUI reservationGUI = new ReservationGUI();
            reservationGUI.TopLevel = false;
            reservationGUI.FormBorderStyle = FormBorderStyle.None;
            reservationGUI.Show();
            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(reservationGUI);
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryGUI historyGUI = new HistoryGUI();
            historyGUI.TopLevel = false;
            historyGUI.FormBorderStyle = FormBorderStyle.None;
            historyGUI.Show();
            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(historyGUI);
        }
    }
}
