namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditPeiceOfGround : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PieceOfGrounds", "PieceOfGroundPhotoPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PieceOfGrounds", "PieceOfGroundPhotoPath", c => c.String());
        }
    }
}
