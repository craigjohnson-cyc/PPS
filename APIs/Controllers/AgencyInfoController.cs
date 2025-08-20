using ClientsApi.Data;
using DataModels.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.VisualBasic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Text;
using System;
using DataModels.Models.DTOs;

namespace PpsApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyInfoController : ControllerBase
    {
        private PpsDBContext _context;  // DB

        public AgencyInfoController(PpsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllAgencyInfo()
        {
            int agencyId = 1;

            AgencyInfo agency = _context.SysInfo.Where(s => s.sysinfo_key == agencyId).FirstOrDefault();
            if (agency == null)
            {
                AgencyInfoDto agencyInfoDto = new AgencyInfoDto
                {
                    adultguard = agency.adultguard,
                    agencycode = agency.agencycode,
                    agencyname = agency.agencyname,
                    allmonth = agency.allmonth,
                    altcliname = agency.altcliname,
                    baseinnote = agency.baseinnote,
                    bgpic = agency.bgpic,
                    billobject = agency.billobject,
                    bl_allow = agency.bl_allow,
                    bl_map = agency.bl_map,
                    blocksign = agency.blocksign,
                    canblast = agency.canblast,
                    catgry_key = agency.catgry_key,
                    chkoradv = agency.chkoradv,
                    corp_path = agency.corp_path,
                    cr_overdue = agency.cr_overdue,
                    dailygraf = agency.dailygraf,
                    dateformat = agency.dateformat,
                    demouser1 = agency.demouser1,
                    demouser2 = agency.demouser2,
                    demouser3 = agency.demouser3,
                    dosesshist = agency.dosesshist,
                    domain_key = agency.domain_key,
                    enablegwiz = agency.enablegwiz,
                    epochyear = agency.epochyear,
                    exename = agency.exename,
                    fourdigtyr = agency.fourdigtyr,
                    from_psite = agency.from_psite,
                    goalib_key = agency.goalib_key,
                    goalsnm = agency.goalsnm,
                    group_key = agency.group_key,
                    guardiannm = agency.guardiannm,
                    hds_compat = agency.hds_compat,
                    importer = agency.importer,
                    inactivity = agency.inactivity,
                    is_both = agency.is_both,
                    is_corp = agency.is_corp,
                    iwill = agency.iwill,
                    keepactv = agency.keepactv,
                    keepai = agency.keepai,
                    keepassess = agency.keepassess,
                    keepbillin = agency.keepbillin,
                    keepelog = agency.keepelog,
                    keephist = agency.keephist,
                    keepnotes = agency.keepnotes,
                    keeprevs = agency.keeprevs,
                    keepserv = agency.keepserv,
                    keepsess = agency.keepsess,
                    keepstac = agency.keepstac,
                    keep_open = agency.keep_open,
                    lastdaymon = agency.lastdaymon,
                    lasticheck = agency.lasticheck,
                    lastpurge = agency.lastpurge,
                    lastsnapdr = agency.lastsnapdr,
                    lastsnapdt = agency.lastsnapdt,
                    librar_key = agency.librar_key,
                    longdates = agency.longdates,
                    makefolder = agency.makefolder,
                    minpasslen = agency.minpasslen,
                    monsnoprog = agency.monsnoprog,
                    multikeyok = agency.multikeyok,
                    nobehavior = agency.nobehavior,
                    nobkg = agency.nobkg,
                    noclient = agency.noclient,
                    nonaminuse = agency.nonaminuse,
                    norollfwd = agency.norollfwd,
                    notetext = agency.notetext,
                    objname = agency.objname,
                    oneapage = agency.oneapage,
                    pagefactor = agency.pagefactor,
                    permision2 = agency.permision2,
                    permission = agency.permission,
                    plan_key = agency.plan_key,
                    pn_overdue = agency.pn_overdue,
                    progplannm = agency.progplannm,
                    progrm_key = agency.progrm_key,
                    prompt_e1 = agency.prompt_e1,
                    prompt_e2 = agency.prompt_e2,
                    prompt_e3 = agency.prompt_e3,
                    providernm = agency.providernm,
                    p_banner = agency.p_banner,
                    p_name1 = agency.p_name1,
                    p_name2 = agency.p_name2,
                    p_name3 = agency.p_name3,
                    p_name4 = agency.p_name4,
                    p_name5 = agency.p_name5,
                    p_name6 = agency.p_name6,
                    recordbehv = agency.recordbehv,
                    remoteno = agency.remoteno,
                    reviewernm = agency.reviewernm,
                    reviewtyps = agency.reviewtyps,
                    revprefixs = agency.revprefixs,
                    scalable1 = agency.scalable1,
                    scales_key = agency.scales_key,
                    send_pdocs = agency.send_pdocs,
                    send_pics = agency.send_pics,
                    send_rdocs = agency.send_rdocs,
                    servoname = agency.servoname,
                    site = agency.site,
                    snapfreq = agency.snapfreq,
                    snapmnthly = agency.snapmnthly,
                    snaprotate = agency.snaprotate,
                    snapyearly = agency.snapyearly,
                    staffuser1 = agency.staffuser1,
                    staffuser2 = agency.staffuser2,
                    staffuser3 = agency.staffuser3,
                    staff_key = agency.staff_key,
                    stepdates = agency.stepdates,
                    stepercent = agency.stepercent,
                    stepname = agency.stepname,
                    stopicheck = agency.stopicheck,
                    strennum = agency.strennum,
                    targetgoal = agency.targetgoal,
                    timeout = agency.timeout,
                    trainname = agency.trainname,
                    ugly = agency.ugly,
                    version = agency.version,
                    visioname1 = agency.visioname1,
                    visioname2 = agency.visioname2,
                    visioname3 = agency.visioname3,
                    visioname4 = agency.visioname4,
                    visioname5 = agency.visioname5,
                    visioname6 = agency.visioname6,
                    visioname7 = agency.visioname7,
                    visioname8 = agency.visioname8,
                    weaknum = agency.weaknum,
                    wppath = agency.wppath,
                    xcasemannm = agency.xcasemannm,
                    yourplan1 = agency.yourplan1,
                    yourplan2 = agency.yourplan2,
                    yourplan3 = agency.yourplan3,
                    yourplan4 = agency.yourplan4,
                    yourplan5 = agency.yourplan5,
                    timestamp_column = agency.timestamp_column,
                    sysinfo_key = agency.sysinfo_key,
                    advansecur = agency.advansecur,
                    obj_author = agency.obj_author,
                    prefer_wp = agency.prefer_wp,
                    nodupobj = agency.nodupobj,
                    subagencyname = agency.subagencyname,
                    customcode = agency.customcode,
                    nodupobjno = agency.nodupobjno,
                    clikinprom = agency.clikinprom,
                    USECRITERI = agency.USECRITERI,
                    helpfile = agency.helpfile,
                    xsltemplat = agency.xsltemplat,
                    requsernam = agency.requsernam,
                    careplantitle = agency.careplantitle,
                    patchlog = agency.patchlog,
                    permissage = agency.permissage,
                    criteriaprint = agency.criteriaprint,
                    agencyadr1 = agency.agencyadr1,
                    agencyadr2 = agency.agencyadr2,
                    agencycity = agency.agencycity,
                    agencystate = agency.agencystate,
                    agencyzip = agency.agencyzip,
                    agencybphone = agency.agencybphone,
                    usecensus = agency.usecensus,
                    provmedicaidid = agency.provmedicaidid,
                    provmedicareid = agency.provmedicareid,
                    provvendorid = agency.provvendorid,
                    provEIN = agency.provEIN,
                    provNPI = agency.provNPI,
                    ai_listbox = agency.ai_listbox,
                    procodefil = agency.procodefil,
                    mayenter0 = agency.mayenter0,
                    append_to_connection_string = agency.append_to_connection_string,
                    lastbackupdone = agency.lastbackupdone
                };

                return Ok(agencyInfoDto);
            } else
            {
                return NotFound();
            }
        }
        [HttpPut]
        // update => edit
        public IActionResult UpdateAgencyInfo(int id, AgencyInfoDto updatedAgencyInfoDto)
        {
            AgencyInfo agencyInfo = _context.SysInfo.Find(id);

            if (agencyInfo == null)
            {
                return NotFound();
            }
            else
            {
                // update agencyInfo from updatedAgencyInfoDto
                agencyInfo.adultguard = updatedAgencyInfoDto.adultguard;
                agencyInfo.advansecur = updatedAgencyInfoDto.advansecur;
                agencyInfo.agencyadr1 = updatedAgencyInfoDto.agencyadr1;
                agencyInfo.agencyadr2 = updatedAgencyInfoDto.agencyadr2;
                agencyInfo.agencybphone = updatedAgencyInfoDto.agencybphone;
                agencyInfo.agencycity = updatedAgencyInfoDto.agencycity;
                agencyInfo.agencycode = updatedAgencyInfoDto.agencycode;
                agencyInfo.agencyname = updatedAgencyInfoDto.agencyname;
                agencyInfo.agencystate = updatedAgencyInfoDto.agencystate;
                agencyInfo.agencyzip = updatedAgencyInfoDto.agencyzip;
                agencyInfo.ai_listbox = updatedAgencyInfoDto.ai_listbox;
                agencyInfo.allmonth = updatedAgencyInfoDto.allmonth;
                agencyInfo.altcliname = updatedAgencyInfoDto.altcliname;
                agencyInfo.append_to_connection_string = updatedAgencyInfoDto.append_to_connection_string;
                agencyInfo.baseinnote = updatedAgencyInfoDto.baseinnote;
                agencyInfo.bgpic = updatedAgencyInfoDto.bgpic;
                agencyInfo.billobject = updatedAgencyInfoDto.billobject;
                agencyInfo.blocksign = updatedAgencyInfoDto.blocksign;
                agencyInfo.bl_allow = updatedAgencyInfoDto.bl_allow;
                agencyInfo.bl_map = updatedAgencyInfoDto.bl_map;
                agencyInfo.canblast = updatedAgencyInfoDto.canblast;
                agencyInfo.careplantitle = updatedAgencyInfoDto.careplantitle;
                agencyInfo.catgry_key = updatedAgencyInfoDto.catgry_key;
                agencyInfo.chkoradv = updatedAgencyInfoDto.chkoradv;
                agencyInfo.clikinprom = updatedAgencyInfoDto.clikinprom;
                agencyInfo.corp_path = updatedAgencyInfoDto.corp_path;
                agencyInfo.criteriaprint = updatedAgencyInfoDto.criteriaprint;
                agencyInfo.cr_overdue = updatedAgencyInfoDto.cr_overdue;
                agencyInfo.customcode = updatedAgencyInfoDto.customcode;
                agencyInfo.dateformat = updatedAgencyInfoDto.dateformat;
                agencyInfo.dailygraf = updatedAgencyInfoDto.dailygraf;
                agencyInfo.demouser1 = updatedAgencyInfoDto.demouser1;
                agencyInfo.demouser2 = updatedAgencyInfoDto.demouser2;
                agencyInfo.demouser3 = updatedAgencyInfoDto.demouser3;
                agencyInfo.domain_key = updatedAgencyInfoDto.domain_key;
                agencyInfo.dosesshist = updatedAgencyInfoDto.dosesshist;
                agencyInfo.enablegwiz = updatedAgencyInfoDto.enablegwiz;
                agencyInfo.epochyear = updatedAgencyInfoDto.epochyear;
                agencyInfo.exename = updatedAgencyInfoDto.exename;
                agencyInfo.fourdigtyr = updatedAgencyInfoDto.fourdigtyr;
                agencyInfo.from_psite = updatedAgencyInfoDto.from_psite;
                agencyInfo.goalib_key = updatedAgencyInfoDto.goalib_key;
                agencyInfo.goalsnm = updatedAgencyInfoDto.goalsnm;
                agencyInfo.group_key = updatedAgencyInfoDto.group_key;
                agencyInfo.guardiannm = updatedAgencyInfoDto.guardiannm;
                agencyInfo.hds_compat = updatedAgencyInfoDto.hds_compat;
                agencyInfo.helpfile = updatedAgencyInfoDto.helpfile;
                agencyInfo.importer = updatedAgencyInfoDto.importer;
                agencyInfo.inactivity= updatedAgencyInfoDto.inactivity;
                agencyInfo.is_both = updatedAgencyInfoDto.is_both;
                agencyInfo.is_corp = updatedAgencyInfoDto.is_corp;
                agencyInfo.iwill = updatedAgencyInfoDto.iwill;
                agencyInfo.keepactv = updatedAgencyInfoDto.keepactv;
                agencyInfo.keepai = updatedAgencyInfoDto.keepai;
                agencyInfo.keepassess = updatedAgencyInfoDto.keepassess;
                agencyInfo.keepbillin = updatedAgencyInfoDto.keepbillin;
                agencyInfo.keepelog = updatedAgencyInfoDto.keepelog;
                agencyInfo.keephist = updatedAgencyInfoDto.keephist;
                agencyInfo.keepnotes = updatedAgencyInfoDto.keepnotes;
                agencyInfo.keeprevs = updatedAgencyInfoDto.keeprevs;
                agencyInfo.keepserv = updatedAgencyInfoDto.keepserv;  
                agencyInfo.keepsess = updatedAgencyInfoDto.keepsess;
                agencyInfo.keepstac = updatedAgencyInfoDto.keepstac;
                agencyInfo.keep_open = updatedAgencyInfoDto.keep_open;
                agencyInfo.lastbackupdone = updatedAgencyInfoDto.lastbackupdone;
                agencyInfo.lastdaymon = updatedAgencyInfoDto.lastdaymon;
                agencyInfo.lasticheck = updatedAgencyInfoDto.lasticheck;
                agencyInfo.lastpurge = updatedAgencyInfoDto.lastpurge;
                agencyInfo.lastsnapdr = updatedAgencyInfoDto.lastsnapdr;
                agencyInfo.lastsnapdt = updatedAgencyInfoDto.lastsnapdt;
                agencyInfo.librar_key = updatedAgencyInfoDto.librar_key;
                agencyInfo.longdates = updatedAgencyInfoDto.longdates;
                agencyInfo.makefolder = updatedAgencyInfoDto.makefolder;
                agencyInfo.mayenter0 = updatedAgencyInfoDto.mayenter0;
                agencyInfo.minpasslen = updatedAgencyInfoDto.minpasslen;
                agencyInfo.monsnoprog = updatedAgencyInfoDto.monsnoprog;
                agencyInfo.multikeyok = updatedAgencyInfoDto.multikeyok;
                agencyInfo.nobehavior = updatedAgencyInfoDto.nobehavior;
                agencyInfo.nobkg = updatedAgencyInfoDto.nobkg;
                agencyInfo.noclient = updatedAgencyInfoDto.noclient;
                agencyInfo.nodupobj = updatedAgencyInfoDto.nodupobj;
                agencyInfo.nodupobjno = updatedAgencyInfoDto.nodupobjno;
                agencyInfo.nonaminuse = updatedAgencyInfoDto.nonaminuse;
                agencyInfo.norollfwd = updatedAgencyInfoDto.norollfwd;
                agencyInfo.notetext = updatedAgencyInfoDto.notetext;
                agencyInfo.objname = updatedAgencyInfoDto.objname;
                agencyInfo.obj_author = updatedAgencyInfoDto.obj_author;   
                agencyInfo.oneapage = updatedAgencyInfoDto.oneapage;
                agencyInfo.pagefactor = updatedAgencyInfoDto.pagefactor;
                agencyInfo.patchlog = updatedAgencyInfoDto.patchlog;
                agencyInfo.permision2 = updatedAgencyInfoDto.permision2;
                agencyInfo.permissage = updatedAgencyInfoDto.permissage;
                agencyInfo.permission = updatedAgencyInfoDto.permission;
                agencyInfo.plan_key = updatedAgencyInfoDto.plan_key;
                agencyInfo.pn_overdue = updatedAgencyInfoDto.pn_overdue;
                agencyInfo.prefer_wp = updatedAgencyInfoDto.prefer_wp;
                agencyInfo.procodefil = updatedAgencyInfoDto.procodefil;
                agencyInfo.progplannm = updatedAgencyInfoDto.progplannm;
                agencyInfo.progrm_key = updatedAgencyInfoDto.progrm_key;
                agencyInfo.prompt_e1 = updatedAgencyInfoDto.prompt_e1;
                agencyInfo.prompt_e2 = updatedAgencyInfoDto.prompt_e2;
                agencyInfo.prompt_e3 = updatedAgencyInfoDto.prompt_e3;
                agencyInfo.provEIN = updatedAgencyInfoDto.provEIN;
                agencyInfo.providernm = updatedAgencyInfoDto.providernm;
                agencyInfo.provmedicaidid = updatedAgencyInfoDto.provmedicaidid;
                agencyInfo.provmedicareid = updatedAgencyInfoDto.provmedicareid;
                agencyInfo.provNPI = updatedAgencyInfoDto.provNPI;
                agencyInfo.provvendorid = updatedAgencyInfoDto.provvendorid;
                agencyInfo.p_banner = updatedAgencyInfoDto.p_banner;
                agencyInfo.p_name1 = updatedAgencyInfoDto.p_name1;
                agencyInfo.p_name2 = updatedAgencyInfoDto.p_name2;
                agencyInfo.p_name3 = updatedAgencyInfoDto.p_name3;
                agencyInfo.p_name4 = updatedAgencyInfoDto.p_name4;
                agencyInfo.p_name5 = updatedAgencyInfoDto.p_name5;
                agencyInfo.p_name6 = updatedAgencyInfoDto.p_name6;
                agencyInfo.recordbehv = updatedAgencyInfoDto.recordbehv;
                agencyInfo.remoteno = updatedAgencyInfoDto.remoteno;
                agencyInfo.requsernam = updatedAgencyInfoDto.requsernam;
                agencyInfo.reviewernm = updatedAgencyInfoDto.reviewernm;
                agencyInfo.reviewtyps = updatedAgencyInfoDto.reviewtyps;
                agencyInfo.revprefixs = updatedAgencyInfoDto.revprefixs;
                agencyInfo.scalable1 = updatedAgencyInfoDto.scalable1;
                agencyInfo.scales_key = updatedAgencyInfoDto.scales_key;
                agencyInfo.send_pdocs = updatedAgencyInfoDto.send_pdocs;
                agencyInfo.send_pics = updatedAgencyInfoDto.send_pics;
                agencyInfo.send_rdocs = updatedAgencyInfoDto.send_rdocs;
                agencyInfo.servoname = updatedAgencyInfoDto.servoname;
                agencyInfo.site = updatedAgencyInfoDto.site;
                agencyInfo.snapfreq = updatedAgencyInfoDto.snapfreq;
                agencyInfo.snapmnthly = updatedAgencyInfoDto.snapmnthly;
                agencyInfo.snaprotate = updatedAgencyInfoDto.snaprotate;
                agencyInfo.snapyearly = updatedAgencyInfoDto.snapyearly;
                agencyInfo.staffuser1 = updatedAgencyInfoDto.staffuser1;
                agencyInfo.staffuser2 = updatedAgencyInfoDto.staffuser2;
                agencyInfo.staffuser3 = updatedAgencyInfoDto.staffuser3;
                agencyInfo.staff_key = updatedAgencyInfoDto.staff_key;
                agencyInfo.stepdates = updatedAgencyInfoDto.stepdates;
                agencyInfo.stepercent = updatedAgencyInfoDto.stepercent;
                agencyInfo.stepname = updatedAgencyInfoDto.stepname;
                agencyInfo.stopicheck = updatedAgencyInfoDto.stopicheck;
                agencyInfo.strennum = updatedAgencyInfoDto.strennum;
                agencyInfo.subagencyname = updatedAgencyInfoDto.subagencyname;
                agencyInfo.targetgoal = updatedAgencyInfoDto.targetgoal;
                agencyInfo.timeout = updatedAgencyInfoDto.timeout;
                agencyInfo.trainname = updatedAgencyInfoDto.trainname;
                agencyInfo.ugly = updatedAgencyInfoDto.ugly;
                agencyInfo.usecensus = updatedAgencyInfoDto.usecensus;
                agencyInfo.USECRITERI = updatedAgencyInfoDto.USECRITERI;
                agencyInfo.version = updatedAgencyInfoDto.version;
                agencyInfo.visioname1 = updatedAgencyInfoDto.visioname1;
                agencyInfo.visioname2 = updatedAgencyInfoDto.visioname2;
                agencyInfo.visioname3 = updatedAgencyInfoDto.visioname3;
                agencyInfo.visioname4 = updatedAgencyInfoDto.visioname4;
                agencyInfo.visioname5 = updatedAgencyInfoDto.visioname5;
                agencyInfo.visioname6 = updatedAgencyInfoDto.visioname6;
                agencyInfo.visioname7 = updatedAgencyInfoDto.visioname7;
                agencyInfo.visioname8 = updatedAgencyInfoDto.visioname8;
                agencyInfo.weaknum = updatedAgencyInfoDto.weaknum;
                agencyInfo.wppath = updatedAgencyInfoDto.wppath;
                agencyInfo.xcasemannm = updatedAgencyInfoDto.xcasemannm;
                agencyInfo.xsltemplat = updatedAgencyInfoDto.xsltemplat;
                agencyInfo.yourplan1 = updatedAgencyInfoDto.yourplan1;
                agencyInfo.yourplan2 = updatedAgencyInfoDto.yourplan2;
                agencyInfo.yourplan3 = updatedAgencyInfoDto.yourplan3;
                agencyInfo.yourplan4 = updatedAgencyInfoDto.yourplan4;
                agencyInfo.yourplan5 = updatedAgencyInfoDto.yourplan5;

                _context.SaveChanges();
                return Ok(updatedAgencyInfoDto);
            }
        }

        [HttpPost]
        // create => add
        public IActionResult AddAgencyInfo(AgencyInfoDto agencyInfoDto)
        {
            if (agencyInfoDto == null)
            {
                return BadRequest();
            }
            int agencyId = 1;
            AgencyInfo agency = _context.SysInfo.Find(agencyId);
            if (agency == null)
            {
                // create new AgencyInfo, populate with agencyInfoDto and add to DB
                AgencyInfo agencyInfo = new AgencyInfo()
                {
                    adultguard = agencyInfoDto.adultguard,
                    advansecur = agencyInfoDto.advansecur,
                    agencyadr1 = agencyInfoDto.agencyadr1,
                    agencyadr2 = agencyInfoDto.agencyadr2,
                    agencybphone = agencyInfoDto.agencybphone,
                    agencycity = agencyInfoDto.agencycity,
                    agencycode = agencyInfoDto.agencycode,
                    agencyname = agencyInfoDto.agencyname,
                    agencystate = agencyInfoDto.agencystate,
                    agencyzip = agencyInfoDto.agencyzip,
                    ai_listbox = agencyInfoDto.ai_listbox,
                    allmonth = agencyInfoDto.allmonth,
                    altcliname = agencyInfoDto.altcliname,
                    append_to_connection_string = agencyInfoDto.append_to_connection_string,
                    baseinnote = agencyInfoDto.baseinnote,
                    bgpic = agencyInfoDto.bgpic,
                    billobject = agencyInfoDto.billobject,
                    blocksign = agencyInfoDto.blocksign,
                    bl_allow = agencyInfoDto.bl_allow,
                    bl_map = agencyInfoDto.bl_map,
                    canblast = agencyInfoDto.canblast,
                    careplantitle = agencyInfoDto.careplantitle,
                    catgry_key = agencyInfoDto.catgry_key,
                    chkoradv = agencyInfoDto.chkoradv,
                    clikinprom = agencyInfoDto.clikinprom,
                    corp_path = agencyInfoDto.corp_path,
                    criteriaprint = agencyInfoDto.criteriaprint,
                    cr_overdue = agencyInfoDto.cr_overdue,
                    customcode = agencyInfoDto.customcode,
                    dailygraf = agencyInfoDto.dailygraf,
                    dateformat = agencyInfoDto.dateformat,
                    demouser1 = agencyInfoDto.demouser1,
                    demouser2 = agencyInfoDto.demouser2,
                    demouser3 = agencyInfoDto.demouser3,
                    domain_key = agencyInfoDto.domain_key,
                    dosesshist = agencyInfoDto.dosesshist,
                    enablegwiz = agencyInfoDto.enablegwiz,
                    epochyear = agencyInfoDto.epochyear,
                    exename = agencyInfoDto.exename,
                    fourdigtyr = agencyInfoDto.fourdigtyr,
                    from_psite = agencyInfoDto.from_psite,
                    goalib_key = agencyInfoDto.goalib_key,
                    goalsnm = agencyInfoDto.goalsnm,
                    group_key = agencyInfoDto.group_key,
                    guardiannm = agencyInfoDto.guardiannm,
                    hds_compat = agencyInfoDto.hds_compat,
                    helpfile = agencyInfoDto.helpfile,
                    importer = agencyInfoDto.importer,
                    inactivity = agencyInfoDto.inactivity,
                    is_both = agencyInfoDto.is_both,
                    is_corp = agencyInfoDto.is_corp,
                    iwill = agencyInfoDto.iwill,
                    keepactv = agencyInfoDto.keepactv,
                    keepai = agencyInfoDto.keepai,
                    keepassess = agencyInfoDto.keepassess,
                    keepbillin = agencyInfoDto.keepbillin,
                    keepelog = agencyInfoDto.keepelog,
                    keephist = agencyInfoDto.keephist,
                    keepnotes = agencyInfoDto.keepnotes,
                    keeprevs = agencyInfoDto.keeprevs,
                    keepserv = agencyInfoDto.keepserv,
                    keepsess = agencyInfoDto.keepsess,
                    keepstac = agencyInfoDto.keepstac,
                    keep_open = agencyInfoDto.keep_open,
                    lastbackupdone = agencyInfoDto.lastbackupdone,
                    lastdaymon = agencyInfoDto.lastdaymon,
                    lasticheck = agencyInfoDto.lasticheck,
                    lastpurge = agencyInfoDto.lastpurge,
                    lastsnapdr = agencyInfoDto.lastsnapdr,
                    lastsnapdt = agencyInfoDto.lastsnapdt,
                    librar_key = agencyInfoDto.librar_key,
                    longdates = agencyInfoDto.longdates,
                    makefolder = agencyInfoDto.makefolder,
                    mayenter0 = agencyInfoDto.mayenter0,
                    minpasslen = agencyInfoDto.minpasslen,
                    monsnoprog = agencyInfoDto.monsnoprog,
                    multikeyok = agencyInfoDto.multikeyok,
                    nobehavior = agencyInfoDto.nobehavior,
                    nobkg = agencyInfoDto.nobkg,
                    noclient = agencyInfoDto.noclient,
                    nodupobj = agencyInfoDto.nodupobj,
                    nodupobjno = agencyInfoDto.nodupobjno,
                    nonaminuse = agencyInfoDto.nonaminuse,
                    norollfwd = agencyInfoDto.norollfwd,
                    notetext = agencyInfoDto.notetext,
                    objname = agencyInfoDto.objname,
                    obj_author = agencyInfoDto.obj_author,
                    oneapage = agencyInfoDto.oneapage,
                    pagefactor = agencyInfoDto.pagefactor,
                    patchlog = agencyInfoDto.patchlog,
                    permision2 = agencyInfoDto.permision2,
                    permissage = agencyInfoDto.permissage,
                    permission = agencyInfoDto.permission,
                    plan_key = agencyInfoDto.plan_key,
                    pn_overdue = agencyInfoDto.pn_overdue,
                    prefer_wp = agencyInfoDto.prefer_wp,
                    procodefil = agencyInfoDto.procodefil,
                    progplannm = agencyInfoDto.progplannm,
                    progrm_key = agencyInfoDto.progrm_key,
                    prompt_e1 = agencyInfoDto.prompt_e1,
                    prompt_e2 = agencyInfoDto.prompt_e2,
                    prompt_e3 = agencyInfoDto.prompt_e3,
                    provEIN = agencyInfoDto.provEIN,
                    providernm = agencyInfoDto.providernm,
                    provmedicaidid = agencyInfoDto.provmedicaidid,
                    provmedicareid = agencyInfoDto.provmedicareid,
                    provNPI = agencyInfoDto.provNPI,
                    provvendorid = agencyInfoDto.provvendorid,
                    p_banner = agencyInfoDto.p_banner,
                    p_name1 = agencyInfoDto.p_name1,
                    p_name2 = agencyInfoDto.p_name2,
                    p_name3 = agencyInfoDto.p_name3,
                    p_name4 = agencyInfoDto.p_name4,
                    p_name5 = agencyInfoDto.p_name5,
                    p_name6 = agencyInfoDto.p_name6,
                    recordbehv = agencyInfoDto.recordbehv,
                    remoteno = agencyInfoDto.remoteno,
                    requsernam = agencyInfoDto.requsernam,
                    reviewernm = agencyInfoDto.reviewernm,
                    reviewtyps = agencyInfoDto.reviewtyps,
                    revprefixs = agencyInfoDto.revprefixs,
                    scalable1 = agencyInfoDto.scalable1,
                    scales_key = agencyInfoDto.scales_key,
                    send_pdocs = agencyInfoDto.send_pdocs,
                    send_pics = agencyInfoDto.send_pics,
                    send_rdocs = agencyInfoDto.send_rdocs,
                    servoname = agencyInfoDto.servoname,
                    site = agencyInfoDto.site,
                    snapfreq = agencyInfoDto.snapfreq,
                    snapmnthly = agencyInfoDto.snapmnthly,
                    snaprotate = agencyInfoDto.snaprotate,
                    snapyearly = agencyInfoDto.snapyearly,
                    staffuser1 = agencyInfoDto.staffuser1,
                    staffuser2 = agencyInfoDto.staffuser2,
                    staffuser3 = agencyInfoDto.staffuser3,
                    staff_key = agencyInfoDto.staff_key,
                    stepdates = agencyInfoDto.stepdates,
                    stepercent = agencyInfoDto.stepercent,
                    stepname = agencyInfoDto.stepname,
                    stopicheck = agencyInfoDto.stopicheck,
                    strennum = agencyInfoDto.strennum,
                    subagencyname = agencyInfoDto.subagencyname,
                    sysinfo_key = 1,
                    targetgoal = agencyInfoDto.targetgoal,
                    timeout = agencyInfoDto.timeout,
                    trainname = agencyInfoDto.trainname,
                    USECRITERI = agencyInfoDto.USECRITERI,
                    ugly = agencyInfoDto.ugly,
                    usecensus = agencyInfoDto.usecensus,
                    version = agencyInfoDto.version,
                    visioname1 = agencyInfoDto.visioname1,
                    visioname2  = agencyInfoDto.visioname2,
                    visioname3 = agencyInfoDto.visioname3,
                    visioname4 = agencyInfoDto.visioname4,
                    visioname5 = agencyInfoDto.visioname5,
                    visioname6 = agencyInfoDto.visioname6,
                    visioname7  = agencyInfoDto.visioname7,
                    visioname8 = agencyInfoDto.visioname8,
                    weaknum = agencyInfoDto.weaknum,
                    wppath = agencyInfoDto.wppath,
                    xcasemannm = agencyInfoDto.xcasemannm,
                    yourplan1 = agencyInfoDto.yourplan1,
                    yourplan2 = agencyInfoDto.yourplan2,
                    yourplan3 = agencyInfoDto.yourplan3,
                    yourplan4 = agencyInfoDto.yourplan4,
                    yourplan5 = agencyInfoDto.yourplan5,


                };

                _context.Add(agencyInfo);
                _context.SaveChanges();

                return Ok(new AgencyInfo { });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
