using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libarary.Models
{
    public partial class Book
    {
        public override string? ToString()
        {
            return Title;
        }
    }
    public partial class Copy
    {
        public override string? ToString()
        {
            using (var db = new LibararyContext())
            {
                var book = db.Books.Where(x => x.BookNumber == BookNumber).FirstOrDefault();
                return book?.Title;
            }
        }
    }

    public partial class Borrower
    {
        public string sexStr
        {
            get
            {
                return this.Sex == true ? "Male" : "Female";
            }
        }
        public override string? ToString()
        {
            return this.Name;
        }
    }

}
