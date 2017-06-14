namespace BioscoopB3Web.Domain.Concrete
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BioscoopB3Web.Domain.Entities;
    using BioscoopB3Web.Domain.Concrete;

    public class BioscoopModel : DbContext
    {
        // Your context has been configured to use a 'BioscoopModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BioscoopB3Web.Concrete.BioscoopModel' database on your LocalDb instance. 
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
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<HallMovie> HallMovies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<HallLayout> HallLayouts { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}