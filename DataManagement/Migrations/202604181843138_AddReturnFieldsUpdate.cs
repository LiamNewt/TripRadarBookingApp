namespace DataManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReturnFieldsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavedHotels", "HotelDetName", c => c.String());
            DropColumn("dbo.SavedHotels", "HotelName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SavedHotels", "HotelName", c => c.String());
            DropColumn("dbo.SavedHotels", "HotelDetName");
        }
    }
}
