namespace FerryBackEndTests
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestDBContext : DbContext
    {
        public TestDBContext()
            : base("name=TestDBContext")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Departure> Departure { get; set; }
        public virtual DbSet<Ferry> Ferry { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TravelingEntity> TravelingEntity { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Reservation)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departure>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Departure1)
                .HasForeignKey(e => e.Departure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ferry>()
                .HasMany(e => e.Departure)
                .WithRequired(e => e.Ferry1)
                .HasForeignKey(e => e.Ferry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Reservation1)
                .HasForeignKey(e => e.Reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Route1)
                .HasForeignKey(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TravelingEntity>()
                .HasMany(e => e.Passenger)
                .WithRequired(e => e.TravelingEntity1)
                .HasForeignKey(e => e.TravelingEntity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TravelingEntity>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.TravelingEntity1)
                .HasForeignKey(e => e.TravelingEntity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TravelingEntity>()
                .HasMany(e => e.Vehicle)
                .WithRequired(e => e.TravelingEntity)
                .HasForeignKey(e => e.ContainingEntity)
                .WillCascadeOnDelete(false);
        }
    }
}
