using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondAdmin.Control.Domain
{
    class Facilitie
    {
        //Pensar em ter um cooldown, para poder reservar de novo
        public int facilitieId { get; set; }
        public string facilitieName { get; set; }
        public string facilitieDs { get; set; }
        public string reservationAlert { get; set; }
        public List<DateTime> reservedPeriod { get; set; } //a ideia seria para poder trazer uma lista de datas e horas que já estão reservadas
        public int maxReservationTime { get; set; } //temos que ver um nome melhor para essa, bem como o tipo, que deveria ser um de hora.
        public int minReservationTime { get; set; } //Não sei se seria um valor padrão. mesmo tipo do de cima.
    }
}
