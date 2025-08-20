using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.DTOs
{
    public class ClientDto
    {
        [Key]
        public int client_key { get; set; }
        public string clientno { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string mname { get; set; }
        public string aka { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

    }
}
