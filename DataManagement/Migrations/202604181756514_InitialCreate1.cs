namespace DataManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavedFlights", "ReturnDepartureAirport", c => c.String());
            AddColumn("dbo.SavedFlights", "ReturnArrivalAirport", c => c.String());
            AddColumn("dbo.SavedFlights", "ReturnArrivalTime", c => c.String());
            AddColumn("dbo.SavedFlights", "ReturnDepartureTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SavedFlights", "ReturnDepartureTime");
            DropColumn("dbo.SavedFlights", "ReturnArrivalTime");
            DropColumn("dbo.SavedFlights", "ReturnArrivalAirport");
            DropColumn("dbo.SavedFlights", "ReturnDepartureAirport");
        }
    }
}
