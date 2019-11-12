namespace FlightTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassangerIdModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages");
            DropPrimaryKey("dbo.Passangers");
            AddColumn("dbo.Passangers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Passangers", "Id");
            AddForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages");
            DropPrimaryKey("dbo.Passangers");
            DropColumn("dbo.Passangers", "Id");
            AddPrimaryKey("dbo.Passangers", "CurrentStageId");
            AddForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages", "ID");
        }
    }
}
