using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Entities
{
    public class Client
    {
        [Key]
        public int client_key { get; set; }
        public string clientno { get; set; } = string.Empty;
        [Required]
        public string fname { get; set; } = string.Empty;
        [Required]
        public string lname { get; set; } = string.Empty;
        public string mname { get; set; } = string.Empty;   
        public string aka { get; set; } = string.Empty;
        [Required]
        public string address { get; set; } = string.Empty;
        public string address2 { get; set; } = string.Empty;
        [Required]
        public string city { get; set; } = string.Empty;
        [Required]
        public string state { get; set; } = string.Empty;
        [Required]
        public string zip { get; set; } = string.Empty; 


    }
}
