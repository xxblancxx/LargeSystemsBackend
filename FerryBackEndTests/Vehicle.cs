namespace FerryBackEndTests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public bool IsLargeVehicle { get; set; }

        public int ContainingEntity { get; set; }

        public virtual TravelingEntity TravelingEntity { get; set; }
    }
}
