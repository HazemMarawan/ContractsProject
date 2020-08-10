namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commReg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComercialRegisters",
                c => new
                    {
                        ComercialRegisterPhotoId = c.Int(nullable: false, identity: true),
                        ComercialRegisterPhotoPath = c.String(),
                        ContractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComercialRegisterPhotoId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComercialRegisters", "ContractId", "dbo.Contracts");
            DropIndex("dbo.ComercialRegisters", new[] { "ContractId" });
            DropTable("dbo.ComercialRegisters");
        }
    }
}
