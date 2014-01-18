using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservationsystem.Models
{
    public class TemplateModel
    {
        public int Id { get; set; }
        public string NameD { get; set; }
        public string NameF { get; set; }
        public string NameI { get; set; }
        public string NameE { get; set; }
        public int? StartSatusId { get; set; }
        public int? ConfirmedStatusId { get; set; }
        public int? ApprovedSatusId { get; set; }
        public int? DeniedStatusId { get; set; }
        public int? ElaboratedStatusId { get; set; }
        public virtual ICollection<BlockModel> Blocks { get; set; }
        public virtual ICollection<ReservationModel> Reservations { get; set; }
         
    }
}