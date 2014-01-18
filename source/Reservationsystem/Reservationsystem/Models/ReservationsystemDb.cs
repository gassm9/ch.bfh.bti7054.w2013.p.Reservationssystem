using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Reservationsystem.Models
{
    public class ReservationsystemDb : DbContext
    {
        public ReservationsystemDb() : base("name=DefaultConnection")
        {

        }

        public DbSet<TemplateModel> Templates { get; set; }
        public System.Data.Entity.DbSet<Reservationsystem.Models.InputTypeModel> InputTypeModels { get; set; }

        public System.Data.Entity.DbSet<Reservationsystem.Models.ReservationModel> ReservationModels { get; set; }

        public System.Data.Entity.DbSet<Reservationsystem.Models.BlockModel> BlockModels { get; set; }

        public System.Data.Entity.DbSet<Reservationsystem.Models.KeyModel> KeyModels { get; set; }

        public System.Data.Entity.DbSet<Reservationsystem.Models.ValueModel> ValueModels { get; set; }

        public System.Data.Entity.DbSet<Reservationsystem.Models.StatusModel> StatusModels { get; set; }

    }
}