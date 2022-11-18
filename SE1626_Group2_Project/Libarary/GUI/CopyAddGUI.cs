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

    public partial class CopyAddGUI : Form
    {
        public event EventHandler add;
        private Book book;
        private Copy copy;
        public CopyAddGUI(Book book, Copy copy)
        {
            InitializeComponent();
            this.book = book;
            this.copy = copy;
        }

        private void CopyAddGUI_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            tbBook.Text = book.Title;
            if (copy != null)
            {
                comboBox1.SelectedIndex = comboBox1.FindStringExact(copy.Type);
                tbPrice.Text = copy.Price.ToString();
                tbSeq.Text = copy.SequenceNumber.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!checkInput()) return;
            if (copy != null)
            {
                Update(sender, e);
            }
            else
            {
                AddNew(sender, e);
            }

        }
        private bool checkInput()
        {
            if (tbSeq.Text == "" || tbPrice.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return false;
            }
            try
            {
                int.Parse(tbSeq.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Sequence Number must be number!");
                return false;
            }
            try
            {
                int.Parse(tbPrice.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Price must be number!");
                return false;
            }
            return true;
        }

        private void AddNew(object sender, EventArgs e)
        {
            Copy c = new Copy();
            c.BookNumber = book.BookNumber;
            c.SequenceNumber = int.Parse(tbSeq.Text);
            c.Price = int.Parse(tbPrice.Text);
            c.Type = comboBox1.Text;
            using (var db = new LibararyContext())
            {
                db.Add(c);
                db.SaveChanges();
                add.Invoke(sender, e);
                MessageBox.Show("Added Successfully!");
            }
        }
        private void Update(object sender, EventArgs e)
        {
            copy.BookNumber = book.BookNumber;
            copy.SequenceNumber = int.Parse(tbSeq.Text);
            copy.Price = int.Parse(tbPrice.Text);
            copy.Type = comboBox1.Text;
            using (var db = new LibararyContext())
            {
                db.Update(copy);
                db.SaveChanges();
                add.Invoke(sender, e);
                MessageBox.Show("Updated Successfully!");
            }
        }
    }
}
