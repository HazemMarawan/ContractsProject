namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPieceOfGroundData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PieceOfGrounds", "Location", c => c.String());
            AddColumn("dbo.PieceOfGrounds", "PieceNum", c => c.String());
            AddColumn("dbo.PieceOfGrounds", "PieceDoc", c => c.String());
            AddColumn("dbo.PieceOfGrounds", "HowOwn", c => c.String());
            AddColumn("dbo.PieceOfGrounds", "DoumentNum", c => c.String());
            AddColumn("dbo.PieceOfGrounds", "Decision", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PieceOfGrounds", "Decision");
            DropColumn("dbo.PieceOfGrounds", "DoumentNum");
            DropColumn("dbo.PieceOfGrounds", "HowOwn");
            DropColumn("dbo.PieceOfGrounds", "PieceDoc");
            DropColumn("dbo.PieceOfGrounds", "PieceNum");
            DropColumn("dbo.PieceOfGrounds", "Location");
        }
    }
}
