namespace FlightTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKforPassanger : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Passangers", name: "plane_ID", newName: "PassangerPlaneId");
            RenameColumn(table: "dbo.Passangers", name: "Stages_StageID", newName: "PassangerStageId");
            RenameIndex(table: "dbo.Passangers", name: "IX_plane_ID", newName: "IX_PassangerPlaneId");
            RenameIndex(table: "dbo.Passangers", name: "IX_Stages_StageID", newName: "IX_PassangerStageId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Passangers", name: "IX_PassangerStageId", newName: "IX_Stages_StageID");
            RenameIndex(table: "dbo.Passangers", name: "IX_PassangerPlaneId", newName: "IX_plane_ID");
            RenameColumn(table: "dbo.Passangers", name: "PassangerStageId", newName: "Stages_StageID");
            RenameColumn(table: "dbo.Passangers", name: "PassangerPlaneId", newName: "plane_ID");
        }
    }
}
