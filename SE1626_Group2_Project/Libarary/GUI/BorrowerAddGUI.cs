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
    public partial class BorrowerAddGUI : Form
    {
        public event EventHandler add;
        public Borrower borrower { get; set; }
        public BorrowerAddGUI(Borrower b)
        {
            InitializeComponent();
            this.borrower = b;
        }

        private void BorrowerAddGUI_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            if(borrower != null)
            {
                fillBorrower();
            }
        }
        private void fillBorrower()
        {
            tbAddress.Text = borrower.Address;
            if (borrower.Sex == true)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
            tbName.Text=  borrower.Name;
            tbTel.Text = borrower.Telephone;
           tbEmail.Text  = borrower.Email;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!checkInput()) return;
            if (this.borrower == null)
            {
                AddNew(sender, e);
            }else
            {
                Update(sender, e);
            }

        }
        private bool checkInput()
        {
            if (tbAddress.Text == "" || tbEmail.Text == "" ||
                tbName.Text == "" || tbTel.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return false;
            }
            try
            {
                int.Parse(tbTel.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Telephone must be number!");
                return false;
            }
            return true;
        }

        private void AddNew(object sender, EventArgs e)
        {
            Borrower bor = new Borrower();
            bor.Address = tbAddress.Text;
            bor.Sex = comboBox1.Text == "Male" ? true : false;
            bor.Name = tbName.Text;
            bor.Telephone = tbTel.Text;
            bor.Email = tbEmail.Text;
            using (var db = new LibararyContext())
            {
                db.Borrowers.Add(bor);
                db.SaveChanges();
                add.Invoke(sender, e);
                MessageBox.Show("Added Successfully!");
            }
        }
        private void Update(object sender, EventArgs e)
        {
            borrower.Address = tbAddress.Text;
            borrower.Sex = comboBox1.Text == "Male" ? true : false;
            borrower.Name = tbName.Text;
            borrower.Telephone = tbTel.Text;
            borrower.Email = tbEmail.Text;
            using (var db = new LibararyContext())
            {
                db.Borrowers.Update(borrower);
                db.SaveChanges();
                add.Invoke(sender, e);
                MessageBox.Show("Updated Successfully!");
            }
        }
    }
}
