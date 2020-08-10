using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContractsProject.Models
{
    public class OwnerSequence
    {
        [Key]
        public int SequenceId { get; set; }
        public string ClientOne { get; set; }
        public string ClientTwo { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public string OwnerSequencePhotoPath { get; set; }

    }
}