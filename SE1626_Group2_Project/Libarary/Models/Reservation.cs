using System;
using System.Collections.Generic;

namespace Libarary.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int? BorrowerNumber { get; set; }
        public int? BookNumber { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }

        public virtual Book? BookNumberNavigation { get; set; }
        public virtual Borrower? BorrowerNumberNavigation { get; set; }
    }
}
