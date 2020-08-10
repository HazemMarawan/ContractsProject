using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContractsProject.Models
{
    public class Contract
    {
        [Key]
        public int contractId { get; set; }
        public int ContractType { get; set; }
        public string ClientName { get; set; }
        public string ClientType { get; set; }
        
        public string ClienId { get; set; }
        public string assossicationNumber { get; set; }
        public string commercialRegisterFile { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public ICollection<PieceOfGround> pieceOfGrounds { get; set; }
        public ICollection<OwnerSequence> OwnerSequences { get; set; }
        public ICollection<NationalIdPhoto> NationalIdPhotos { get; set; }
        public ICollection<ComercialRegister> ComercialRegisters { get; set; }
        
    }
}