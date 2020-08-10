namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePhotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OwnerSequences", "OwnerSequencePhotoPath", c => c.String());
            AddColumn("dbo.PieceOfGrounds", "PieceOfGroundPhotoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PieceOfGrounds", "PieceOfGroundPhotoPath");
            DropColumn("dbo.OwnerSequences", "OwnerSequencePhotoPath");
        }
    }
}
