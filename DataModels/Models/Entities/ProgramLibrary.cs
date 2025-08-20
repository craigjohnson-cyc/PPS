using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataModels.Models.Entities
{
    public class ProgramLibrary
    {
        public Int32 chaintype { get; set; } = 0;
        public string condition { get; set; } = string.Empty;
        public string criteria { get; set; } = string.Empty;
        public double criterilas { get; set; } = 0;
        public double criterimon { get; set; } = 0;
        public string criteriper { get; set; } = string.Empty;
        public string data { get; set; } = string.Empty;
        public string domainn { get; set; } = string.Empty;
        public bool env_factor { get; set; } = false;
        public double eval_lastn { get; set; } = 0;
        public string evalmethod { get; set; } = string.Empty;
        public bool increase { get; set; } = false;
        public Int32 indepyesno { get; set; } = 0;
        public string keywords { get; set; } = string.Empty;
        public string objective { get; set; } = string.Empty;
        public string perflevel { get; set; } = string.Empty;
        public Int32 perflevelcount { get; set; } = 0;
        public string progdesc { get; set; } = string.Empty;
        public Int32 progmeasur { get; set; } = 0;
        public string progsteps { get; set; } = string.Empty;
        public Int32 progstepscount { get; set; } = 0;
        public string strategy { get; set; } = string.Empty;
        public string taskanal { get; set; } = string.Empty;
        public Int32 taskanalcount { get; set; } = 0;
        public bool totaltask { get; set; } = false;
        public string timestamp_column { get; set; } = string.Empty;
        [Key]
        public int program_key { get; set; } = 0;
        public string strategy2 { get; set; } = string.Empty;
        public string strategy3 { get; set; } = string.Empty;
        public string strategy4 { get; set; } = string.Empty;
        public string strategy5 { get; set; } = string.Empty;
        public string strategy6 { get; set; } = string.Empty;
    }
}
