using System;
using System.Collections.Generic;

namespace Libarary.Models
{
    public partial class CirculatedCopy
    {
        public int Id { get; set; }
        public int? CopyNumber { get; set; }
        public int? BorrowerNumber { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int? FineAmount { get; set; }

        public virtual Borrower? BorrowerNumberNavigation { get; set; }
        public virtual Copy? CopyNumberNavigation { get; set; }
    }
}
