using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.PickList
{
    public class piklist
    {
        public string code { get; set; } = string.Empty;
        public string fieldd { get; set; } = string.Empty;
        public string filee { get; set; } = string.Empty;
        public string htb { get; set; } = string.Empty;
        public string item { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public string longtitle { get; set; } = string.Empty;
        public double ordr { get; set; } = 0;
        public int pikname_key { get; set; } = 0;
        public byte[] timestamp_column { get; set; } 
        [Key]
        public int piklist_key { get; set; } = 0;
    }

}
