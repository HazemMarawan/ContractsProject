namespace ContractsProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContractsDB : DbContext
    {
        // Your context has been configured to use a 'ContractsDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ContractsProject.Models.ContractsDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ContractsDB' 
        // connection string in the application configuration file.
        public ContractsDB()
            : base("name=ContractsDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<PieceOfGround> PieceOfGrounds { get; set; }
        public virtual DbSet<OwnerSequence> OwnerSequences { get; set; }
        public virtual DbSet<NationalIdPhoto> NationalIdPhotos { get; set; }
        public virtual DbSet<ComercialRegister> ComercialRegisters { get; set; }

        
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}