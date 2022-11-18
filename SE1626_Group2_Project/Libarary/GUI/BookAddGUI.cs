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
    public partial class BookAddGUI : Form
    {
        public event EventHandler add;
        public BookAddGUI()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!checkInput()) return;
            Book newBook = new Book();
            newBook.Title = tbTitle.Text;
            newBook.Author = tbAuthor.Text;
            newBook.Publisher = tbPub.Text;
            using (var db = new LibararyContext())
            {
                db.Add(newBook);
                db.SaveChanges();
            }
            using (var db = new LibararyContext())
            {
                //find last book
                Book b = db.Books.OrderByDescending(x => x.BookNumber).FirstOrDefault();
                int quantity = int.Parse(tbQuan.Text);
                List<Copy> listCopy = new List<Copy>();
                Random rnd = new Random();
                for (int i =0; i < quantity; i++)
                {
                    Copy c = new Copy();
                    c.BookNumber = b.BookNumber;
                    c.SequenceNumber = rnd.Next(100000000, 1000000000);
                    c.Price = int.Parse(tbPrice.Text);
                    c.Type = "available";
                    listCopy.Add(c);
                }
                db.AddRange(listCopy);
                db.SaveChanges();
            }
            add.Invoke(sender, e);
            MessageBox.Show("Added Successfully!");
        }
        private bool checkInput()
        {
            if (tbTitle.Text == "" || tbAuthor.Text == "" ||
                tbPub.Text == "" || tbQuan.Text == "" || tbPrice.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return false;
            }
            try
            {
                int.Parse(tbQuan.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Quantity must be number!");
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
    }
}
