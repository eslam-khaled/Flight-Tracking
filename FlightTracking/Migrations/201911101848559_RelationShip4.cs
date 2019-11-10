namespace FlightTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationShip4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages");
            DropPrimaryKey("dbo.Passangers");
            AddPrimaryKey("dbo.Passangers", "CurrentStageId");
            AddForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages", "ID");
            DropColumn("dbo.Passangers", "ID");
            DropColumn("dbo.Inspectings", "ID");
            DropColumn("dbo.Luggages", "ID");
            DropColumn("dbo.Papers", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Papers", "ID", c => c.Int(nullable: false));
            AddColumn("dbo.Luggages", "ID", c => c.Int(nullable: false));
            AddColumn("dbo.Inspectings", "ID", c => c.Int(nullable: false));
            AddColumn("dbo.Passangers", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages");
            DropPrimaryKey("dbo.Passangers");
            AddPrimaryKey("dbo.Passangers", "ID");
            AddForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages", "ID", cascadeDelete: true);
        }
    }
}
