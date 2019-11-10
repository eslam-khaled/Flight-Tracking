namespace FlightTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationShips3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customs");
            DropPrimaryKey("dbo.Inspectings");
            DropPrimaryKey("dbo.Luggages");
            DropPrimaryKey("dbo.Papers");
            AddColumn("dbo.Customs", "CurrentStageId", c => c.Int(nullable: false));
            AddColumn("dbo.Inspectings", "CurrentStageId", c => c.Int(nullable: false));
            AddColumn("dbo.Luggages", "CurrentStageId", c => c.Int(nullable: false));
            AddColumn("dbo.Papers", "CurrentStageId", c => c.Int(nullable: false));
            AddColumn("dbo.Passangers", "CurrentStageId", c => c.Int(nullable: false));
            AddColumn("dbo.Passangers", "plane_ID", c => c.Int());
            AddColumn("dbo.Planes", "countryFrom_ID", c => c.Int());
            AlterColumn("dbo.Customs", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Inspectings", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Luggages", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Papers", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Customs", "CurrentStageId");
            AddPrimaryKey("dbo.Inspectings", "CurrentStageId");
            AddPrimaryKey("dbo.Luggages", "CurrentStageId");
            AddPrimaryKey("dbo.Papers", "CurrentStageId");
            CreateIndex("dbo.Planes", "countryFrom_ID");
            CreateIndex("dbo.Passangers", "CurrentStageId");
            CreateIndex("dbo.Passangers", "plane_ID");
            CreateIndex("dbo.Customs", "CurrentStageId");
            CreateIndex("dbo.Inspectings", "CurrentStageId");
            CreateIndex("dbo.Luggages", "CurrentStageId");
            CreateIndex("dbo.Papers", "CurrentStageId");
            AddForeignKey("dbo.Planes", "countryFrom_ID", "dbo.CountryFroms", "ID");
            AddForeignKey("dbo.Customs", "CurrentStageId", "dbo.CurrentStages", "ID");
            AddForeignKey("dbo.Inspectings", "CurrentStageId", "dbo.CurrentStages", "ID");
            AddForeignKey("dbo.Luggages", "CurrentStageId", "dbo.CurrentStages", "ID");
            AddForeignKey("dbo.Papers", "CurrentStageId", "dbo.CurrentStages", "ID");
            AddForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Passangers", "plane_ID", "dbo.Planes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passangers", "plane_ID", "dbo.Planes");
            DropForeignKey("dbo.Passangers", "CurrentStageId", "dbo.CurrentStages");
            DropForeignKey("dbo.Papers", "CurrentStageId", "dbo.CurrentStages");
            DropForeignKey("dbo.Luggages", "CurrentStageId", "dbo.CurrentStages");
            DropForeignKey("dbo.Inspectings", "CurrentStageId", "dbo.CurrentStages");
            DropForeignKey("dbo.Customs", "CurrentStageId", "dbo.CurrentStages");
            DropForeignKey("dbo.Planes", "countryFrom_ID", "dbo.CountryFroms");
            DropIndex("dbo.Papers", new[] { "CurrentStageId" });
            DropIndex("dbo.Luggages", new[] { "CurrentStageId" });
            DropIndex("dbo.Inspectings", new[] { "CurrentStageId" });
            DropIndex("dbo.Customs", new[] { "CurrentStageId" });
            DropIndex("dbo.Passangers", new[] { "plane_ID" });
            DropIndex("dbo.Passangers", new[] { "CurrentStageId" });
            DropIndex("dbo.Planes", new[] { "countryFrom_ID" });
            DropPrimaryKey("dbo.Papers");
            DropPrimaryKey("dbo.Luggages");
            DropPrimaryKey("dbo.Inspectings");
            DropPrimaryKey("dbo.Customs");
            AlterColumn("dbo.Papers", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Luggages", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Inspectings", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customs", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Planes", "countryFrom_ID");
            DropColumn("dbo.Passangers", "plane_ID");
            DropColumn("dbo.Passangers", "CurrentStageId");
            DropColumn("dbo.Papers", "CurrentStageId");
            DropColumn("dbo.Luggages", "CurrentStageId");
            DropColumn("dbo.Inspectings", "CurrentStageId");
            DropColumn("dbo.Customs", "CurrentStageId");
            AddPrimaryKey("dbo.Papers", "ID");
            AddPrimaryKey("dbo.Luggages", "ID");
            AddPrimaryKey("dbo.Inspectings", "ID");
            AddPrimaryKey("dbo.Customs", "ID");
        }
    }
}
