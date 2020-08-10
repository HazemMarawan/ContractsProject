using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractsProject.Models
{
    public class NationalIdPhoto
    {
        public int NationalIdPhotoId { get; set; }
        public string NationalIdPhotoPath { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}