namespace FerryBackEndTests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public double Price { get; set; }

        public int Reservation { get; set; }

        public int Route { get; set; }

        public int Departure { get; set; }

        public int TravelingEntity { get; set; }

        public virtual Departure Departure1 { get; set; }

        public virtual Reservation Reservation1 { get; set; }

        public virtual Route Route1 { get; set; }

        public virtual TravelingEntity TravelingEntity1 { get; set; }
    }
}
