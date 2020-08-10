namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOwnerSequence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OwnerSequences",
                c => new
                    {
                        SequenceId = c.Int(nullable: false, identity: true),
                        ClientOne = c.String(),
                        ClientTwo = c.String(),
                        Contract_contractId = c.Int(),
                    })
                .PrimaryKey(t => t.SequenceId)
                .ForeignKey("dbo.Contracts", t => t.Contract_contractId)
                .Index(t => t.Contract_contractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OwnerSequences", "Contract_contractId", "dbo.Contracts");
            DropIndex("dbo.OwnerSequences", new[] { "Contract_contractId" });
            DropTable("dbo.OwnerSequences");
        }
    }
}
