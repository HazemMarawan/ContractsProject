namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFieldsPieceOfGround : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PieceOfGrounds", "CommitteeReport", c => c.String());
            AddColumn("dbo.PieceOfGrounds", "ClientReplys", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PieceOfGrounds", "ClientReplys");
            DropColumn("dbo.PieceOfGrounds", "CommitteeReport");
        }
    }
}
