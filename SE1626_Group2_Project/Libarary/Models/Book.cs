using System;
using System.Collections.Generic;

namespace Libarary.Models
{
    public partial class Book
    {
        public Book()
        {
            Copies = new HashSet<Copy>();
            Reservations = new HashSet<Reservation>();
        }

        public int BookNumber { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }

        public virtual ICollection<Copy> Copies { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
