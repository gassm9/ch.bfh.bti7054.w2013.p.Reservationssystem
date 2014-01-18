using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservationsystem.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public virtual TemplateModel Template { get; set; }
        public virtual StatusModel Status { get; set; }
        public virtual ICollection<ValueModel> Values { get; set; }
    }
}