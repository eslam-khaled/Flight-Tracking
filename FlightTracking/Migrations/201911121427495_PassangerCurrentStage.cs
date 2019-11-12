namespace FlightTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassangerCurrentStage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages");
            DropIndex("dbo.Passangers", new[] { "CurrentStageId" });
            AlterColumn("dbo.Passangers", "CurrentStageId", c => c.Int());
            CreateIndex("dbo.Passangers", "CurrentStageId");
            AddForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages");
            DropIndex("dbo.Passangers", new[] { "CurrentStageId" });
            AlterColumn("dbo.Passangers", "CurrentStageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Passangers", "CurrentStageId");
            AddForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages", "ID", cascadeDelete: true);
        }
    }
}
