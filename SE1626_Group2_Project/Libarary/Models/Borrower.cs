using System;
using System.Collections.Generic;

namespace Libarary.Models
{
    public partial class Borrower
    {
        public Borrower()
        {
            CirculatedCopies = new HashSet<CirculatedCopy>();
            Reservations = new HashSet<Reservation>();
        }

        public int BorrowerNumber { get; set; }
        public string? Name { get; set; }
        public bool? Sex { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<CirculatedCopy> CirculatedCopies { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
