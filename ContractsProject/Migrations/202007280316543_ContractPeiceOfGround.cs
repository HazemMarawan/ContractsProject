namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContractPeiceOfGround : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PieceOfGrounds", "Contract_contractId", "dbo.Contracts");
            DropIndex("dbo.PieceOfGrounds", new[] { "Contract_contractId" });
            RenameColumn(table: "dbo.PieceOfGrounds", name: "Contract_contractId", newName: "ContractId");
            AddColumn("dbo.Contracts", "ContractType", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "ClientName", c => c.String());
            AddColumn("dbo.Contracts", "ClientType", c => c.String());
            AddColumn("dbo.Contracts", "ClienId", c => c.String());
            AddColumn("dbo.Contracts", "assossicationNumber", c => c.String());
            AddColumn("dbo.Contracts", "commercialRegisterFile", c => c.String());
            AddColumn("dbo.Contracts", "Phone", c => c.String());
            AddColumn("dbo.Contracts", "Mobile", c => c.String());
            AddColumn("dbo.Contracts", "EmailAddress", c => c.String());
            AddColumn("dbo.Contracts", "Subject", c => c.String());
            AddColumn("dbo.PieceOfGrounds", "Desc", c => c.String());
            AddColumn("dbo.PieceOfGrounds", "Fdan", c => c.Int(nullable: false));
            AddColumn("dbo.PieceOfGrounds", "Eirat", c => c.Int(nullable: false));
            AddColumn("dbo.PieceOfGrounds", "Sahm", c => c.Int(nullable: false));
            AlterColumn("dbo.PieceOfGrounds", "ContractId", c => c.Int(nullable: false));
            CreateIndex("dbo.PieceOfGrounds", "ContractId");
            AddForeignKey("dbo.PieceOfGrounds", "ContractId", "dbo.Contracts", "contractId", cascadeDelete: true);
            DropColumn("dbo.Contracts", "Title");
            DropColumn("dbo.PieceOfGrounds", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PieceOfGrounds", "Location", c => c.String());
            AddColumn("dbo.Contracts", "Title", c => c.String());
            DropForeignKey("dbo.PieceOfGrounds", "ContractId", "dbo.Contracts");
            DropIndex("dbo.PieceOfGrounds", new[] { "ContractId" });
            AlterColumn("dbo.PieceOfGrounds", "ContractId", c => c.Int());
            DropColumn("dbo.PieceOfGrounds", "Sahm");
            DropColumn("dbo.PieceOfGrounds", "Eirat");
            DropColumn("dbo.PieceOfGrounds", "Fdan");
            DropColumn("dbo.PieceOfGrounds", "Desc");
            DropColumn("dbo.Contracts", "Subject");
            DropColumn("dbo.Contracts", "EmailAddress");
            DropColumn("dbo.Contracts", "Mobile");
            DropColumn("dbo.Contracts", "Phone");
            DropColumn("dbo.Contracts", "commercialRegisterFile");
            DropColumn("dbo.Contracts", "assossicationNumber");
            DropColumn("dbo.Contracts", "ClienId");
            DropColumn("dbo.Contracts", "ClientType");
            DropColumn("dbo.Contracts", "ClientName");
            DropColumn("dbo.Contracts", "ContractType");
            RenameColumn(table: "dbo.PieceOfGrounds", name: "ContractId", newName: "Contract_contractId");
            CreateIndex("dbo.PieceOfGrounds", "Contract_contractId");
            AddForeignKey("dbo.PieceOfGrounds", "Contract_contractId", "dbo.Contracts", "contractId");
        }
    }
}
