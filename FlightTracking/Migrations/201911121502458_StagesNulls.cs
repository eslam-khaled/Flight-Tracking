namespace FlightTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StagesNulls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customs", "ExtraTime", c => c.Double());
            AlterColumn("dbo.Inspectings", "ExtraTime", c => c.Double());
            AlterColumn("dbo.Luggages", "ExtraTime", c => c.Double());
            AlterColumn("dbo.Papers", "ExtraTime", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Papers", "ExtraTime", c => c.Double(nullable: false));
            AlterColumn("dbo.Luggages", "ExtraTime", c => c.Double(nullable: false));
            AlterColumn("dbo.Inspectings", "ExtraTime", c => c.Double(nullable: false));
            AlterColumn("dbo.Customs", "ExtraTime", c => c.Double(nullable: false));
        }
    }
}
