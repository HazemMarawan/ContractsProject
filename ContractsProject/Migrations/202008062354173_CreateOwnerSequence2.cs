namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOwnerSequence2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OwnerSequences", "Contract_contractId", "dbo.Contracts");
            DropIndex("dbo.OwnerSequences", new[] { "Contract_contractId" });
            RenameColumn(table: "dbo.OwnerSequences", name: "Contract_contractId", newName: "ContractId");
            AlterColumn("dbo.OwnerSequences", "ContractId", c => c.Int(nullable: false));
            CreateIndex("dbo.OwnerSequences", "ContractId");
            AddForeignKey("dbo.OwnerSequences", "ContractId", "dbo.Contracts", "contractId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OwnerSequences", "ContractId", "dbo.Contracts");
            DropIndex("dbo.OwnerSequences", new[] { "ContractId" });
            AlterColumn("dbo.OwnerSequences", "ContractId", c => c.Int());
            RenameColumn(table: "dbo.OwnerSequences", name: "ContractId", newName: "Contract_contractId");
            CreateIndex("dbo.OwnerSequences", "Contract_contractId");
            AddForeignKey("dbo.OwnerSequences", "Contract_contractId", "dbo.Contracts", "contractId");
        }
    }
}
