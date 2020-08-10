using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContractsProject.Models
{
    public class PieceOfGround
    {
        [Key]
        public int PieceOfGroundId { get; set; }
        public string Desc { get; set; }
        public int Fdan { get; set; }
        public int Eirat { get; set; }

        public int Sahm { get; set; }

        public string Location { get; set; }

        public string PieceNum { get; set; }

        public string PieceDoc { get; set; }
        public string CommitteeReport { get; set; }
        public string ClientReplys { get; set; }


        public string HowOwn { get; set; }

        public string DoumentNum { get; set; }  

        public string Decision { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }

    }
}