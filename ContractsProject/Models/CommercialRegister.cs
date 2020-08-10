using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContractsProject.Models
{
    public class ComercialRegister
    {
        [Key]
        public int ComercialRegisterPhotoId { get; set; }
        public string ComercialRegisterPhotoPath { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}