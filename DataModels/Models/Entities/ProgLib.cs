using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Models.Entities
{
    public class Proglib
    {
        public short chaintype { get; set; } = 0;
        public string condition { get; set; } = string.Empty;
        public string criteria { get; set; } = string.Empty;
        public double criterilas { get; set; } = 0;
        public double criterimon { get; set; } = 0;
        public string criteriper { get; set; } = string.Empty;
        public string data { get; set; } = string.Empty;
        public string domain_key { get; set; } = string.Empty;
        public string domainn { get; set; } = string.Empty;
        public bool env_factor { get; set; } = false;
        public double eval_lastn { get; set; } = 0;
        public string evalmethod { get; set; } = string.Empty;
        public bool increase { get; set; } = false;
        public short indepyesno { get; set; } = 0;
        public string keywords { get; set; } = string.Empty;
        public string objective { get; set; } = string.Empty;
        public string perflevel { get; set; } = string.Empty;
        public short perflevelcount { get; set; } = 0;
        public string progdesc { get; set; } = string.Empty;
        public short progmeasur { get; set; } = 0;
        public string progrm_key { get; set; } = string.Empty;
        public string progrm_ord { get; set; } = string.Empty;
        public string progsteps { get; set; } = string.Empty;
        public short progstepscount { get; set; } = 0;
        public string scale1_key { get; set; } = string.Empty;
        public string scale2_key { get; set; } = string.Empty;
        public string steps_key { get; set; } = string.Empty;
        public string strategy { get; set; } = string.Empty;
        public string taskanal { get; set; } = string.Empty;
        public short taskanalcount { get; set; } = 0;
        public bool totaltask { get; set; } = false;
            [Key]
        public int program_key { get; set; } = 0;
        public string strategy2 { get; set; } = string.Empty;
        public string strategy3 { get; set; } = string.Empty;
        public string strategy4 { get; set; } = string.Empty;
        public string strategy5 { get; set; } = string.Empty;
        public string strategy6 { get; set; } = string.Empty;
    }

}
