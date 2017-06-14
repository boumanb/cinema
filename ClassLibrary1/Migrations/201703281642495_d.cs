namespace BioscoopB3Web.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        WantsNewsletter = c.Boolean(nullable: false),
                        LastName = c.String(),
                        Password = c.String(),
                        AccountType = c.String(nullable: false),
                        Gender = c.String(),
                        Street = c.String(),
                        StreetNumber = c.Int(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.HallLayouts",
                c => new
                    {
                        HallLayoutID = c.Int(nullable: false, identity: true),
                        Rows = c.Int(nullable: false),
                        SeatsPerRow = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HallLayoutID);
            
            CreateTable(
                "dbo.HallMovies",
                c => new
                    {
                        HallMovieID = c.Int(nullable: false, identity: true),
                        MovieID = c.Int(nullable: false),
                        HallID = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        DateTimeEnd = c.DateTime(nullable: false),
                        LadiesNight = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HallMovieID)
                .ForeignKey("dbo.Halls", t => t.HallID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID)
                .Index(t => t.HallID);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        HallID = c.Int(nullable: false, identity: true),
                        Capacity = c.Int(nullable: false),
                        HallLayoutID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HallID)
                .ForeignKey("dbo.HallLayouts", t => t.HallLayoutID, cascadeDelete: true)
                .Index(t => t.HallLayoutID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Length = c.Int(nullable: false),
                        ThreeD = c.Boolean(nullable: false),
                        Language = c.String(nullable: false),
                        Subtitles = c.Boolean(nullable: false),
                        Genre = c.String(nullable: false),
                        Age = c.String(nullable: false),
                        RunTime = c.DateTime(nullable: false),
                        Director = c.String(nullable: false),
                        Actor = c.String(nullable: false),
                        Imdb = c.String(),
                        Trailer = c.String(),
                        Site = c.String(),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.MovieID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        StudentTickets = c.Int(nullable: false),
                        ElderlyTickets = c.Int(nullable: false),
                        ChildTickets = c.Int(nullable: false),
                        NormalTickets = c.Int(nullable: false),
                        TotalTickets = c.Int(nullable: false),
                        PopcornArrangement = c.Int(nullable: false),
                        StudentTicketsPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChildTicketsPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ElderlyTicketsPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NormalTicketsPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PopcornArrangementPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrintID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        SurveyID = c.Int(nullable: false, identity: true),
                        ScoreQ = c.Int(nullable: false),
                        MultipleChoiceQ = c.String(),
                        OpenQ = c.String(),
                        OpenQIsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SurveyID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        HallMovieID = c.Int(nullable: false),
                        Type = c.String(),
                        Seat = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HallMovies", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.HallMovies", "HallID", "dbo.Halls");
            DropForeignKey("dbo.Halls", "HallLayoutID", "dbo.HallLayouts");
            DropIndex("dbo.Halls", new[] { "HallLayoutID" });
            DropIndex("dbo.HallMovies", new[] { "HallID" });
            DropIndex("dbo.HallMovies", new[] { "MovieID" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Surveys");
            DropTable("dbo.Orders");
            DropTable("dbo.Movies");
            DropTable("dbo.Halls");
            DropTable("dbo.HallMovies");
            DropTable("dbo.HallLayouts");
            DropTable("dbo.Accounts");
        }
    }
}
