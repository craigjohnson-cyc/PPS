using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Entities
{
    public class Staff
    {
        public string address { get; set; } = string.Empty;
        public string address2 { get; set; } = string.Empty;
        public bool allrights { get; set; } = false;
        public bool asignbynam { get; set; } = false;
        public string belong2_1 { get; set; } = string.Empty;
        public string belong2_2 { get; set; } = string.Empty;
        public DateTime birthday { get; set; } = DateTime.Now;
        public string city { get; set; } = string.Empty;
        public int contac_key { get; set; } = 0;
        //public byte[] cryptopublickey { get; set; } = new byte[0];
        public string ffirst { get; set; } = string.Empty;
        public string group1perm { get; set; } = string.Empty;
        public string group2perm { get; set; } = string.Empty;
        public bool is_current { get; set; } = false;
        public bool is_sysadmin { get; set; } = false;
        public string llast { get; set; } = string.Empty;
        public int lastcli { get; set; } = 0;
        public string location { get; set; } = string.Empty;
        public string middle { get; set; } = string.Empty;
        public double moneyhr { get; set; } = 0;
        public string my_actions { get; set; } = string.Empty;
        public double mygroup { get; set; } = 0;
        //public string password { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string positionn { get; set; } = string.Empty;
        //public double pw { get; set; } = 0;
        public string revfirst { get; set; } = string.Empty;
        public string revlast { get; set; } = string.Empty;
        public string revshowat { get; set; } = string.Empty;
        public bool secuassign { get; set; } = false;
        public string secucasefi { get; set; } = string.Empty;
        public bool secucaseis { get; set; } = false;
        public int secucasekey { get; set; } = 0;
        public string secucasela { get; set; } = string.Empty;
        public bool secucasman { get; set; } = false;
        public string secudaypr2 { get; set; } = string.Empty;
        public bool secudaypro { get; set; } = false;
        public string seculocat2 { get; set; } = string.Empty;
        public bool seculocati { get; set; } = false;
        public bool secuobject { get; set; } = false;
        public Int16 security { get; set; } = 0;
        public string security1 { get; set; } = string.Empty;
        public string security2 { get; set; } = string.Empty;
        public bool secuschedu { get; set; } = false;
        public bool secuservob { get; set; } = false;
        public string secuspeci2 { get; set; } = string.Empty;
        public bool secuspecif { get; set; } = false;
        public bool signpolicy { get; set; } = false;
        public string site { get; set; } = string.Empty;
        public string ssn { get; set; } = string.Empty;
        public string staff_id { get; set; } = string.Empty;
        public DateTime started { get; set; } = DateTime.Now;
        public string state { get; set; } = string.Empty;
        public bool supres_chanobj { get; set; } = false;
        public bool tooltips { get; set; } = false;
        public string user1 { get; set; } = string.Empty;
        public string user2 { get; set; } = string.Empty;
        public string user3 { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string zip { get; set; } = string.Empty;
        public int team_key { get; set; } = 0;
        //public string timestamp_column { get; set; } = string.Empty;
        [Key]
        public int staff_key { get; set; } = 0;
        public bool viewpage1 { get; set; } = false;
        public bool viewpage2 { get; set; } = false;
        public bool viewpage3 { get; set; } = false;
        public bool viewpage4 { get; set; } = false;
        public bool viewpage5 { get; set; } = false;
        public bool viewpage7 { get; set; } = false;
        public bool viewpage8 { get; set; } = false;
        public bool viewvision { get; set; } = false;
        public bool showobjdelmsg { get; set; } = false;
        public DateTime permissage { get; set; } = DateTime.Now;
        public string tableinfo { get; set; } = string.Empty;
        public bool sorevhist { get; set; } = false;
        public bool supres_bhvnote { get; set; } = false;
        public string bilprovrid { get; set; } = string.Empty;

    }
}
