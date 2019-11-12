namespace FlightTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customs", "CurrentStageId", "dbo.CurrentStages");
            DropForeignKey("dbo.Inspectings", "CurrentStageId", "dbo.CurrentStages");
            DropForeignKey("dbo.Luggages", "CurrentStageId", "dbo.CurrentStages");
            DropForeignKey("dbo.Papers", "CurrentStageId", "dbo.CurrentStages");
            DropForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages");
            DropIndex("dbo.Passangers", new[] { "CurrentStageId" });
            DropIndex("dbo.Customs", new[] { "CurrentStageId" });
            DropIndex("dbo.Inspectings", new[] { "CurrentStageId" });
            DropIndex("dbo.Luggages", new[] { "CurrentStageId" });
            DropIndex("dbo.Papers", new[] { "CurrentStageId" });
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        StageID = c.Int(nullable: false, identity: true),
                        StageName = c.String(),
                        EstimatedTime = c.Int(nullable: false),
                        ExtraTime = c.Int(),
                    })
                .PrimaryKey(t => t.StageID);
            
            AddColumn("dbo.Passangers", "Stages_StageID", c => c.Int());
            CreateIndex("dbo.Passangers", "Stages_StageID");
            AddForeignKey("dbo.Passangers", "Stages_StageID", "dbo.Stages", "StageID");
            DropColumn("dbo.Passangers", "CurrentStageId");
            DropTable("dbo.CurrentStages");
            DropTable("dbo.Customs");
            DropTable("dbo.Inspectings");
            DropTable("dbo.Luggages");
            DropTable("dbo.Papers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        CurrentStageId = c.Int(nullable: false),
                        StageName = c.Int(nullable: false),
                        EstimatedTime = c.Double(nullable: false),
                        ExtraTime = c.Double(),
                    })
                .PrimaryKey(t => t.CurrentStageId);
            
            CreateTable(
                "dbo.Luggages",
                c => new
                    {
                        CurrentStageId = c.Int(nullable: false),
                        StageName = c.Int(nullable: false),
                        EstimatedTime = c.Double(nullable: false),
                        ExtraTime = c.Double(),
                    })
                .PrimaryKey(t => t.CurrentStageId);
            
            CreateTable(
                "dbo.Inspectings",
                c => new
                    {
                        CurrentStageId = c.Int(nullable: false),
                        StageName = c.Int(nullable: false),
                        EstimatedTime = c.Double(nullable: false),
                        ExtraTime = c.Double(),
                    })
                .PrimaryKey(t => t.CurrentStageId);
            
            CreateTable(
                "dbo.Customs",
                c => new
                    {
                        CurrentStageId = c.Int(nullable: false),
                        ID = c.Int(nullable: false),
                        StageName = c.Int(nullable: false),
                        EstimatedTime = c.Double(nullable: false),
                        ExtraTime = c.Double(),
                    })
                .PrimaryKey(t => t.CurrentStageId);
            
            CreateTable(
                "dbo.CurrentStages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Passangers", "CurrentStageId", c => c.Int());
            DropForeignKey("dbo.Passangers", "Stages_StageID", "dbo.Stages");
            DropIndex("dbo.Passangers", new[] { "Stages_StageID" });
            DropColumn("dbo.Passangers", "Stages_StageID");
            DropTable("dbo.Stages");
            CreateIndex("dbo.Papers", "CurrentStageId");
            CreateIndex("dbo.Luggages", "CurrentStageId");
            CreateIndex("dbo.Inspectings", "CurrentStageId");
            CreateIndex("dbo.Customs", "CurrentStageId");
            CreateIndex("dbo.Passangers", "CurrentStageId");
            AddForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages", "ID");
            AddForeignKey("dbo.Papers", "CurrentStageId", "dbo.CurrentStages", "ID");
            AddForeignKey("dbo.Luggages", "CurrentStageId", "dbo.CurrentStages", "ID");
            AddForeignKey("dbo.Inspectings", "CurrentStageId", "dbo.CurrentStages", "ID");
            AddForeignKey("dbo.Customs", "CurrentStageId", "dbo.CurrentStages", "ID");
        }
    }
}
