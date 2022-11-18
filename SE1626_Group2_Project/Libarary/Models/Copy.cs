using System;
using System.Collections.Generic;

namespace Libarary.Models
{
    public partial class Copy
    {
        public Copy()
        {
            CirculatedCopies = new HashSet<CirculatedCopy>();
        }

        public int CopyNumber { get; set; }
        public int? BookNumber { get; set; }
        public int? SequenceNumber { get; set; }
        public string? Type { get; set; }
        public int? Price { get; set; }

        public virtual Book? BookNumberNavigation { get; set; }
        public virtual ICollection<CirculatedCopy> CirculatedCopies { get; set; }
    }
}
