using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondAdmin.Control.Domain
{
    class Occurrence
    {
        public enum occurrenceType
        {
            suggestion,
            complaint,
            other
        }

        public int occurrenceId { get; set; }
        public string occurrenceDs { get; set; }
        public occurrenceType typeOfOccurrence { get; set; }
        public int senderId { get; set; }

    }
}
