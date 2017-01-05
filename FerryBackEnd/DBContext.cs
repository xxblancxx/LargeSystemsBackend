namespace FerryBackEnd
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Departure> Departures { get; set; }
        public virtual DbSet<Ferry> Ferries { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TravelingEntity> TravelingEntities { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departure>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Departure1)
                .HasForeignKey(e => e.Departure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ferry>()
                .HasMany(e => e.Departures)
                .WithRequired(e => e.Ferry1)
                .HasForeignKey(e => e.Ferry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Reservation1)
                .HasForeignKey(e => e.Reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Route1)
                .HasForeignKey(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TravelingEntity>()
                .HasMany(e => e.Passengers)
                .WithRequired(e => e.TravelingEntity1)
                .HasForeignKey(e => e.TravelingEntity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TravelingEntity>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.TravelingEntity1)
                .HasForeignKey(e => e.TravelingEntity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TravelingEntity>()
                .HasMany(e => e.Vehicles)
                .WithRequired(e => e.TravelingEntity)
                .HasForeignKey(e => e.ContainingEntity)
                .WillCascadeOnDelete(false);
        }
    }
}
