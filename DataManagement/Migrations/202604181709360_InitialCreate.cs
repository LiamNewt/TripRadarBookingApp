namespace DataManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavedFlights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureAirport = c.String(),
                        ArrivalAirport = c.String(),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        AirlineCode = c.String(),
                        Price = c.Int(nullable: false),
                        CabinClass = c.String(),
                        SavedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SavedHotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotelName = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        PricePNight = c.Double(nullable: false),
                        ImageUrl = c.String(),
                        Arrival = c.String(),
                        Departure = c.String(),
                        RoomType = c.String(),
                        SavedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SavedHotels");
            DropTable("dbo.SavedFlights");
        }
    }
}
