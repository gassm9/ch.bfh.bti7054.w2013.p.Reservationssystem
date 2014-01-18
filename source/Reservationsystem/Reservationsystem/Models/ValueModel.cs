using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reservationsystem.Models
{
    public class ValueModel
    {
        public int Id { get; set; }
        public string Data { get; set; }

        public virtual ReservationModel Reservation { get; set; }
        public virtual KeyModel Key { get; set; }
    }
}
