namespace FerryBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Passenger")]
    public partial class Passenger
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public bool IsLocal { get; set; }

        public int TravelingEntity { get; set; }

        public virtual TravelingEntity TravelingEntity1 { get; set; }
    }
}
