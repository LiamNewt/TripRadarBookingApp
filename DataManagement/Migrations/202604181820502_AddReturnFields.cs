namespace DataManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReturnFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SavedFlights", "ReturnArrivalTime", c => c.DateTime());
            AlterColumn("dbo.SavedFlights", "ReturnDepartureTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SavedFlights", "ReturnDepartureTime", c => c.String());
            AlterColumn("dbo.SavedFlights", "ReturnArrivalTime", c => c.String());
        }
    }
}
