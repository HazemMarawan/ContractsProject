namespace ContractsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNationalIdPhoto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NationalIdPhotoes",
                c => new
                    {
                        NationalIdPhotoId = c.Int(nullable: false, identity: true),
                        NationalIdPhotoPath = c.String(),
                        ContractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NationalIdPhotoId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NationalIdPhotoes", "ContractId", "dbo.Contracts");
            DropIndex("dbo.NationalIdPhotoes", new[] { "ContractId" });
            DropTable("dbo.NationalIdPhotoes");
        }
    }
}
