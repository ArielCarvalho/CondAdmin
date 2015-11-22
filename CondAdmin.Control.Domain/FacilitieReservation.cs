using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondAdmin.Control.Domain
{
    class FacilitieReservation
    {
        public Facilitie reservedFacilitie { get; set; }
        public DateTime reservationDateTime { get; set; }
        public int timePeriod { get; set; }
        public string reservationComment { get; set; }

    }
}
