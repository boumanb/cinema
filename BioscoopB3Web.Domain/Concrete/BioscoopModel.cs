namespace ClassLibrary1.Concrete
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Entities;

    public class BioscoopModel : DbContext
    {
        // Your context has been configured to use a 'BioscoopModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ClassLibrary1.Concrete.BioscoopModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BioscoopModel' 
        // connection string in the application configuration file.
        public BioscoopModel()
            : base("name=BioscoopModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<HallMovie> HallMovies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}