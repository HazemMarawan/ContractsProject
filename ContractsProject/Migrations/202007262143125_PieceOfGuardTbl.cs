namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PieceOfGuardTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PieceOfGrounds",
                c => new
                    {
                        PieceOfGroundId = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Contract_contractId = c.Int(),
                    })
                .PrimaryKey(t => t.PieceOfGroundId)
                .ForeignKey("dbo.Contracts", t => t.Contract_contractId)
                .Index(t => t.Contract_contractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PieceOfGrounds", "Contract_contractId", "dbo.Contracts");
            DropIndex("dbo.PieceOfGrounds", new[] { "Contract_contractId" });
            DropTable("dbo.PieceOfGrounds");
        }
    }
}
