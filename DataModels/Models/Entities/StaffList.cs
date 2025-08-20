using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Entities
{
    public class StaffList
    {
        [Key]
        public int staff_key { get; set; } = 0;
        public string ffirst { get; set; } = string.Empty;
        public string llast { get; set; } = string.Empty;
        public string positionn { get; set; } = string.Empty;
        public bool is_current { get; set; } = false;


    }
}
