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
using DataModels.Models.PickList;
using System.Diagnostics;
using System.Security.Claims;
using System.Linq;
using AutoMapper;

namespace PpsApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDetailsController : ControllerBase
    {
        private PpsDBContext _context;  // DB

        public ClientDetailsController(PpsDBContext context)
        {
            _context = context;
        }
        // ClientDetails is a one to one relationship with Clients
        // Therefor a get all for client does not make sence in this case
        //***************************************************************
        [HttpGet]
        public IActionResult GetResponsiblePersons()
        {
            var stafflist = _context.Staff
                                .Where(s => s.staff_key == s.staff_key)
                                .Select( s => new {staffKey = s.staff_key,
                                                   staffName = s.ffirst.Trim() + " " + s.llast.Trim()
                                })
                                .ToList();

            return Ok(stafflist);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetClientDetailsById(int id)
        {
            //  Lookup needs to be by Client_key,  Not ClientDetails_key
            //ClientDetail foundClient = _context.ClientDetails.Find(id);

            // get Data from Database - Domain Model (Entities)
            ClientDetail foundClientDetail = _context.ClientDetails.Where(x => x.client_key == id).FirstOrDefault();

            if (foundClientDetail == null)
                return NotFound();
            else
            {
                // map domain model to DTOs
                var foundClientDetailDto = new ClientDetailDto();
                foundClientDetailDto.clientDetail_key = foundClientDetail.clientDetail_key;
                foundClientDetailDto.client_key = foundClientDetail.client_key;
                foundClientDetailDto.ssn = foundClientDetail.ssn;
                foundClientDetailDto.admitted = foundClientDetail.admitted;
                foundClientDetailDto.sex = foundClientDetail.sex;
                foundClientDetailDto.maidnm = foundClientDetail.maidnm;
                foundClientDetailDto.hphone = foundClientDetail.hphone;
                foundClientDetailDto.wphone = foundClientDetail.wphone;
                foundClientDetailDto.marital = foundClientDetail.marital;
                foundClientDetailDto.birthday = foundClientDetail.birthday;
                foundClientDetailDto.bill_id = foundClientDetail.bill_id;
                foundClientDetailDto.bill_code = foundClientDetail.bill_code;
                foundClientDetailDto.group1 = foundClientDetail.group1;
                foundClientDetailDto.group2 = foundClientDetail.group2;
                foundClientDetailDto.wphonext = foundClientDetail.wphonext;
                foundClientDetailDto.countleg = foundClientDetail.countleg;
                foundClientDetailDto.county = foundClientDetail.county;
                foundClientDetailDto.resp_key = foundClientDetail.resp_key;
                foundClientDetailDto.excaseman = foundClientDetail.excaseman;
                foundClientDetailDto.location = foundClientDetail.location;
                foundClientDetailDto.dayprogram = foundClientDetail.dayprogram;
                foundClientDetailDto.medicare = foundClientDetail.medicare;
                foundClientDetailDto.medicaid = foundClientDetail.medicaid;
                foundClientDetailDto.ethnic = foundClientDetail.ethnic;
                foundClientDetailDto.homewaiver = foundClientDetail.homewaiver;
                foundClientDetailDto.recstsupp = foundClientDetail.recstsupp;
                foundClientDetailDto.reppayee = foundClientDetail.reppayee;
                foundClientDetailDto.employer = foundClientDetail.employer;
                foundClientDetailDto.emptype = foundClientDetail.emptype;
                foundClientDetailDto.hiredate = foundClientDetail.hiredate;
                foundClientDetailDto.hrlyrate = foundClientDetail.hrlyrate;
                foundClientDetailDto.costtrans = foundClientDetail.costtrans;
                foundClientDetailDto.empnohrs = foundClientDetail.empnohrs;
                foundClientDetailDto.paymonth = foundClientDetail.paymonth;
                foundClientDetailDto.payamt = foundClientDetail.payamt;
                foundClientDetailDto.costtools = foundClientDetail.costtools;
                foundClientDetailDto.uimasocsec = foundClientDetail.uimasocsec;
                foundClientDetailDto.uimassi = foundClientDetail.uimassi;
                foundClientDetailDto.uimava = foundClientDetail.uimava;
                foundClientDetailDto.uimatrust = foundClientDetail.uimatrust;
                foundClientDetailDto.uimarb = foundClientDetail.uimarb;
                foundClientDetailDto.uimapen = foundClientDetail.uimapen;
                foundClientDetailDto.uimaint = foundClientDetail.uimaint;
                foundClientDetailDto.uimaothr = foundClientDetail.uimaothr;
                foundClientDetailDto.incnote = foundClientDetail.incnote;
                foundClientDetailDto.olades1 = foundClientDetail.olades1;
                foundClientDetailDto.olaval1 = foundClientDetail.olaval1;
                foundClientDetailDto.olades2 = foundClientDetail.olades2;
                foundClientDetailDto.olaval2 = foundClientDetail.olaval2;
                foundClientDetailDto.olades3 = foundClientDetail.olades3;
                foundClientDetailDto.olaval3 = foundClientDetail.olaval3;
                foundClientDetailDto.olades4 = foundClientDetail.olades4;
                foundClientDetailDto.olaval4 = foundClientDetail.olaval4;
                foundClientDetailDto.olades5 = foundClientDetail.olades5;
                foundClientDetailDto.olaval5 = foundClientDetail.olaval5;
                foundClientDetailDto.propval = foundClientDetail.propval;
                foundClientDetailDto.vehicval = foundClientDetail.vehicval;
                foundClientDetailDto.plotval = foundClientDetail.plotval;
                foundClientDetailDto.insval = foundClientDetail.insval;
                foundClientDetailDto.totalasset = foundClientDetail.totalasset;
                foundClientDetailDto.assetmon = foundClientDetail.assetmon;
                foundClientDetailDto.assetyear = foundClientDetail.assetyear;
                foundClientDetailDto.mr = foundClientDetail.mr;
                foundClientDetailDto.dd = foundClientDetail.dd;
                foundClientDetailDto.pd = foundClientDetail.pd;
                foundClientDetailDto.care_24hr = foundClientDetail.care_24hr;
                foundClientDetailDto.dsmdiag = foundClientDetail.dsmdiag;
                foundClientDetailDto.diag = foundClientDetail.diag;
                foundClientDetailDto.allergies = foundClientDetail.allergies;
                foundClientDetailDto.bloodtype = foundClientDetail.bloodtype;
                foundClientDetailDto.height = foundClientDetail.height;
                foundClientDetailDto.weight = foundClientDetail.weight;
                foundClientDetailDto.complexton = foundClientDetail.complexton;
                foundClientDetailDto.eyecolor = foundClientDetail.eyecolor;
                foundClientDetailDto.haircolor = foundClientDetail.haircolor;
                foundClientDetailDto.vision = foundClientDetail.vision;
                foundClientDetailDto.hearing = foundClientDetail.hearing;
                foundClientDetailDto.health = foundClientDetail.health;
                foundClientDetailDto.seizure = foundClientDetail.seizure;
                foundClientDetailDto.physician = foundClientDetail.physician;
                foundClientDetailDto.medalert = foundClientDetail.medalert;
                foundClientDetailDto.medadapt = foundClientDetail.medadapt;
                foundClientDetailDto.diet = foundClientDetail.diet;
                foundClientDetailDto.idmarks = foundClientDetail.idmarks;
                foundClientDetailDto.assisdev = foundClientDetail.assisdev;
                foundClientDetailDto.langus = foundClientDetail.langus;
                foundClientDetailDto.commlvle = foundClientDetail.commlvle;
                foundClientDetailDto.commmode = foundClientDetail.commmode;
                foundClientDetailDto.commlvlr = foundClientDetail.commlvlr;
                foundClientDetailDto.commmodr = foundClientDetail.commmodr;
                foundClientDetailDto.mentfunc = foundClientDetail.mentfunc;
                foundClientDetailDto.adapfunc = foundClientDetail.adapfunc;
                foundClientDetailDto.mobility = foundClientDetail.mobility;
                foundClientDetailDto.mobassist = foundClientDetail.mobassist;
                foundClientDetailDto.armhand = foundClientDetail.armhand;
                foundClientDetailDto.vocaskills = foundClientDetail.vocaskills;
                foundClientDetailDto.adaptdev = foundClientDetail.adaptdev;
                foundClientDetailDto.langspok = foundClientDetail.langspok;
                foundClientDetailDto.educalvl = foundClientDetail.educalvl;
                foundClientDetailDto.social = foundClientDetail.social;
                foundClientDetailDto.transfer = foundClientDetail.transfer;
                foundClientDetailDto.toilet = foundClientDetail.toilet;
                foundClientDetailDto.eating = foundClientDetail.eating;
                foundClientDetailDto.meal = foundClientDetail.meal;
                foundClientDetailDto.bathing = foundClientDetail.bathing;
                foundClientDetailDto.dressing = foundClientDetail.dressing;
                foundClientDetailDto.grooming = foundClientDetail.grooming;
                foundClientDetailDto.selffreq = foundClientDetail.selffreq;
                foundClientDetailDto.othrfreq = foundClientDetail.othrfreq;
                foundClientDetailDto.destrfreq = foundClientDetail.destrfreq;
                foundClientDetailDto.disrfreq = foundClientDetail.disrfreq;
                foundClientDetailDto.reptfreq = foundClientDetail.reptfreq;
                foundClientDetailDto.offfreq = foundClientDetail.offfreq;
                foundClientDetailDto.wibfreq = foundClientDetail.wibfreq;
                foundClientDetailDto.uncoopfreq = foundClientDetail.uncoopfreq;
                foundClientDetailDto.wanderfreq = foundClientDetail.wanderfreq;
                foundClientDetailDto.picafreq = foundClientDetail.picafreq;
                foundClientDetailDto.selfsev = foundClientDetail.selfsev;
                foundClientDetailDto.othrsev = foundClientDetail.othrsev;
                foundClientDetailDto.destrsev = foundClientDetail.destrsev;
                foundClientDetailDto.disrsev = foundClientDetail.disrsev;
                foundClientDetailDto.reptsev = foundClientDetail.reptsev;
                foundClientDetailDto.offsev = foundClientDetail.offsev;
                foundClientDetailDto.wibsev = foundClientDetail.wibsev;
                foundClientDetailDto.uncoopsev = foundClientDetail.uncoopsev;
                foundClientDetailDto.wandersev = foundClientDetail.wandersev;
                foundClientDetailDto.picasev = foundClientDetail.picasev;
                foundClientDetailDto.behavadapt = foundClientDetail.behavadapt;
                foundClientDetailDto.intakestat = foundClientDetail.intakestat;
                foundClientDetailDto.detdate = foundClientDetail.detdate;
                foundClientDetailDto.detcode = foundClientDetail.detcode;
                foundClientDetailDto.svcdate = foundClientDetail.svcdate;
                foundClientDetailDto.appdate = foundClientDetail.appdate;
                foundClientDetailDto.provision = foundClientDetail.provision;
                foundClientDetailDto.classasuit = foundClientDetail.classasuit;
                foundClientDetailDto.lastplace = foundClientDetail.lastplace;
                foundClientDetailDto.volunteer = foundClientDetail.volunteer;
                foundClientDetailDto.visitor_rs = foundClientDetail.visitor_rs;
                foundClientDetailDto.religion = foundClientDetail.religion;
                foundClientDetailDto.relig_note = foundClientDetail.relig_note;
                foundClientDetailDto.dayplace = foundClientDetail.dayplace;
                foundClientDetailDto.resprior = foundClientDetail.resprior;
                foundClientDetailDto.resplace = foundClientDetail.resplace;
                foundClientDetailDto.namerele = foundClientDetail.namerele;
                foundClientDetailDto.photoclr = foundClientDetail.photoclr;
                foundClientDetailDto.legalcomp = foundClientDetail.legalcomp;
                foundClientDetailDto.dol_adjuca = foundClientDetail.dol_adjuca;
                foundClientDetailDto.treason = foundClientDetail.treason;
                foundClientDetailDto.termdate = foundClientDetail.termdate;
                foundClientDetailDto.discsum = foundClientDetail.discsum;
                foundClientDetailDto.pictureext = foundClientDetail.pictureext;
                foundClientDetailDto.picfilename = foundClientDetail.picfilename;
                foundClientDetailDto.is_uscitz = foundClientDetail.is_uscitz;
                foundClientDetailDto.a_num = foundClientDetail.a_num;
                foundClientDetailDto.a_numexpdt = foundClientDetail.a_numexpdt;

                foundClientDetailDto.agept = foundClientDetail.agept;
                foundClientDetailDto.behavexist = foundClientDetail.behavexist;
                foundClientDetailDto.behavobjno = foundClientDetail.behavobjno;
                foundClientDetailDto.behavtitle = foundClientDetail.behavtitle;
                foundClientDetailDto.bfreefactr = foundClientDetail.bfreefactr;
                foundClientDetailDto.bgenhypoth = foundClientDetail.bgenhypoth;
                foundClientDetailDto.bhvintrval = foundClientDetail.bhvintrval;
                foundClientDetailDto.bhvrsp_key = foundClientDetail.bhvrsp_key;
                foundClientDetailDto.birthplace = foundClientDetail.birthplace;
                foundClientDetailDto.bprecursor = foundClientDetail.bprecursor;
                foundClientDetailDto.caseman = foundClientDetail.caseman;
                foundClientDetailDto.citizenshipcode = foundClientDetail.citizenshipcode;
                foundClientDetailDto.claid = foundClientDetail.claid;
                foundClientDetailDto.clientDetail_key = foundClientDetail.clientDetail_key; //  should we be passing this value?
                foundClientDetailDto.closcount = foundClientDetail.closcount;
                foundClientDetailDto.closdate = foundClientDetail.closdate;
                foundClientDetailDto.closdispcode = foundClientDetail.closdispcode;
                foundClientDetailDto.closrescode = foundClientDetail.closrescode;
                foundClientDetailDto.cntyorigincode = foundClientDetail.cntyorigincode;
                foundClientDetailDto.courttreatmentcode = foundClientDetail.courttreatmentcode;
                foundClientDetailDto.deldate = foundClientDetail.deldate;
                foundClientDetailDto.dfi_cfi_enroll = foundClientDetail.dfi_cfi_enroll;
                foundClientDetailDto.dfscaseid = foundClientDetail.dfscaseid;
                foundClientDetailDto.disch_date = foundClientDetail.disch_date;
                foundClientDetailDto.disch_reason = foundClientDetail.disch_reason;
                foundClientDetailDto.disch_time = foundClientDetail.disch_time;
                foundClientDetailDto.dsm4axis1 = foundClientDetail.dsm4axis1;
                foundClientDetailDto.dsm4axis2 = foundClientDetail.dsm4axis2;
                foundClientDetailDto.dsm4axis3 = foundClientDetail.dsm4axis3;
                foundClientDetailDto.dsm4axis4 = foundClientDetail.dsm4axis4;
                foundClientDetailDto.dsm4sofa = foundClientDetail.dsm4sofa;
                foundClientDetailDto.funpresnt = foundClientDetail.funpresnt;
                foundClientDetailDto.funvision = foundClientDetail.funvision;
                foundClientDetailDto.gdnstat = foundClientDetail.gdnstat;
                foundClientDetailDto.hispanicorigincode = foundClientDetail.hispanicorigincode;
                foundClientDetailDto.homepresnt = foundClientDetail.homepresnt;
                foundClientDetailDto.homevision = foundClientDetail.homevision;
                foundClientDetailDto.hospitalpref = foundClientDetail.hospitalpref;
                foundClientDetailDto.interpsvccode = foundClientDetail.interpsvccode;
                foundClientDetailDto.ippdate = foundClientDetail.ippdate;
                foundClientDetailDto.is_current = foundClientDetail.is_current;
                foundClientDetailDto.lastpdp = foundClientDetail.lastpdp;
                foundClientDetailDto.lernpresnt = foundClientDetail.lernpresnt;
                foundClientDetailDto.lernvision = foundClientDetail.lernvision;
                foundClientDetailDto.livunit_key = foundClientDetail.livunit_key;
                foundClientDetailDto.milstatcode = foundClientDetail.milstatcode;
                foundClientDetailDto.mmaidname = foundClientDetail.mmaidname;
                foundClientDetailDto.nextpdp = foundClientDetail.nextpdp;
                foundClientDetailDto.notepad = foundClientDetail.notepad;
                foundClientDetailDto.obj_met = foundClientDetail.obj_met;
                foundClientDetailDto.oth2presnt = foundClientDetail.oth2presnt;
                foundClientDetailDto.oth2vision = foundClientDetail.oth2vision;
                foundClientDetailDto.oth3presnt = foundClientDetail.oth3presnt;
                foundClientDetailDto.oth3vision = foundClientDetail.oth3vision;
                foundClientDetailDto.othrace = foundClientDetail.othrace;
                foundClientDetailDto.othragencies = foundClientDetail.othragencies;
                foundClientDetailDto.othrpresnt = foundClientDetail.othrpresnt;
                foundClientDetailDto.othrvision = foundClientDetail.othrvision;
                foundClientDetailDto.palspresnt = foundClientDetail.palspresnt;
                foundClientDetailDto.palsvision = foundClientDetail.palsvision;
                foundClientDetailDto.picture = foundClientDetail.picture;
                foundClientDetailDto.publicaidid = foundClientDetail.publicaidid;
                foundClientDetailDto.regcount = foundClientDetail.regcount;
                foundClientDetailDto.regdate = foundClientDetail.regdate;
                foundClientDetailDto.regrescode = foundClientDetail.regrescode;
                foundClientDetailDto.rep_payee = foundClientDetail.rep_payee;
                foundClientDetailDto.revduedate = foundClientDetail.revduedate;
                foundClientDetailDto.revfirst = foundClientDetail.revfirst;
                foundClientDetailDto.revlast = foundClientDetail.revlast;
                foundClientDetailDto.ROCSDD_DnLoad = foundClientDetail.ROCSDD_DnLoad;
                foundClientDetailDto.ROCS_DnLoad = foundClientDetail.ROCS_DnLoad;
                foundClientDetailDto.ROCS_UpLoad = foundClientDetail.ROCS_UpLoad;
                foundClientDetailDto.site = foundClientDetail.site;
                foundClientDetailDto.sname = foundClientDetail.sname;
                foundClientDetailDto.srcsuppins = foundClientDetail.srcsuppins;
                foundClientDetailDto.ssi_ssdi_eligcode = foundClientDetail.ssi_ssdi_eligcode;
                foundClientDetailDto.statefacid = foundClientDetail.statefacid;
                foundClientDetailDto.tca_code = foundClientDetail.tca_code;
                foundClientDetailDto.tca_origincode = foundClientDetail.tca_origincode;
                foundClientDetailDto.timestamp_column = foundClientDetail.timestamp_column;
                foundClientDetailDto.triggrdate = foundClientDetail.triggrdate;
                foundClientDetailDto.workpresnt = foundClientDetail.workpresnt;
                foundClientDetailDto.workvision = foundClientDetail.workvision;
                foundClientDetailDto.ytdleave = foundClientDetail.ytdleave;
                foundClientDetailDto.zipcode_origin = foundClientDetail.zipcode_origin;


                //return DTO
                return Ok(foundClientDetailDto);
            }
        }


        [HttpPost]
        public IActionResult AddClientDetails(ClientDetailDto addClientDetailDto)
        {
            var newClientDetail = new ClientDetail()
            {
                client_key = addClientDetailDto.client_key,
                ssn = addClientDetailDto.ssn,
                admitted = addClientDetailDto.admitted,
                sex = addClientDetailDto.sex,
                maidnm = addClientDetailDto.maidnm,
                hphone = addClientDetailDto.hphone,
                wphone = addClientDetailDto.wphone,
                marital = addClientDetailDto.marital,
                birthday = addClientDetailDto.birthday,
                bill_id = addClientDetailDto.bill_id,
                bill_code = addClientDetailDto.bill_code,
                group1 = addClientDetailDto.group1,
                group2 = addClientDetailDto.group2,
                wphonext = addClientDetailDto.wphonext,
                countleg = addClientDetailDto.countleg,
                county = addClientDetailDto.county,
                resp_key = addClientDetailDto.resp_key,
                excaseman = addClientDetailDto.excaseman,
                location = addClientDetailDto.location,
                dayprogram = addClientDetailDto.dayprogram,
                medicare = addClientDetailDto.medicare,
                medicaid = addClientDetailDto.medicaid,
                ethnic = addClientDetailDto.ethnic,
                homewaiver = addClientDetailDto.homewaiver,
                recstsupp = addClientDetailDto.recstsupp,
                reppayee = addClientDetailDto.reppayee,
                employer = addClientDetailDto.employer,
                emptype = addClientDetailDto.emptype,
                hiredate = addClientDetailDto.hiredate,
                hrlyrate = addClientDetailDto.hrlyrate,
                costtrans = addClientDetailDto.costtrans,
                empnohrs = addClientDetailDto.empnohrs,
                paymonth = addClientDetailDto.paymonth,
                payamt = addClientDetailDto.payamt,
                costtools = addClientDetailDto.costtools,
                uimasocsec = addClientDetailDto.uimasocsec,
                uimassi = addClientDetailDto.uimassi,
                uimava = addClientDetailDto.uimava,
                uimatrust = addClientDetailDto.uimatrust,
                uimarb = addClientDetailDto.uimarb,
                uimapen = addClientDetailDto.uimapen,
                uimaint = addClientDetailDto.uimaint,
                uimaothr = addClientDetailDto.uimaothr,
                incnote = addClientDetailDto.incnote,
                olades1 = addClientDetailDto.olades1,
                olaval1 = addClientDetailDto.olaval1,
                olades2 = addClientDetailDto.olades2,
                olaval2 = addClientDetailDto.olaval2,
                olades3 = addClientDetailDto.olades3,
                olaval3 = addClientDetailDto.olaval3,
                olades4 = addClientDetailDto.olades4,
                olaval4 = addClientDetailDto.olaval4,
                olades5 = addClientDetailDto.olades5,
                olaval5 = addClientDetailDto.olaval5,
                propval = addClientDetailDto.propval,
                vehicval = addClientDetailDto.vehicval,
                plotval = addClientDetailDto.plotval,
                insval = addClientDetailDto.insval,
                totalasset = addClientDetailDto.totalasset,
                assetmon = addClientDetailDto.assetmon,
                assetyear = addClientDetailDto.assetyear,
                mr = addClientDetailDto.mr,
                dd = addClientDetailDto.dd,
                pd = addClientDetailDto.pd,
                care_24hr = addClientDetailDto.care_24hr,
                dsmdiag = addClientDetailDto.dsmdiag,
                diag = addClientDetailDto.diag,
                allergies = addClientDetailDto.allergies,
                bloodtype = addClientDetailDto.bloodtype,
                height = addClientDetailDto.height,
                weight = addClientDetailDto.weight,
                complexton = addClientDetailDto.complexton,
                eyecolor = addClientDetailDto.eyecolor,
                haircolor = addClientDetailDto.haircolor,
                vision = addClientDetailDto.vision,
                hearing = addClientDetailDto.hearing,
                health = addClientDetailDto.health,
                seizure = addClientDetailDto.seizure,
                physician = addClientDetailDto.physician,
                medalert = addClientDetailDto.medalert,
                medadapt = addClientDetailDto.medadapt,
                diet = addClientDetailDto.diet,
                idmarks = addClientDetailDto.idmarks,
                assisdev = addClientDetailDto.assisdev,
                langus = addClientDetailDto.langus,
                commlvle = addClientDetailDto.commlvle,
                commmode = addClientDetailDto.commmode,
                commlvlr = addClientDetailDto.commlvlr,
                commmodr = addClientDetailDto.commmodr,
                mentfunc = addClientDetailDto.mentfunc,
                adapfunc = addClientDetailDto.adapfunc,
                mobility = addClientDetailDto.mobility,
                mobassist = addClientDetailDto.mobassist,
                armhand = addClientDetailDto.armhand,
                vocaskills = addClientDetailDto.vocaskills,
                adaptdev = addClientDetailDto.adaptdev,
                langspok = addClientDetailDto.langspok,
                educalvl = addClientDetailDto.educalvl,
                social = addClientDetailDto.social,
                transfer = addClientDetailDto.transfer,
                toilet = addClientDetailDto.toilet,
                eating = addClientDetailDto.eating,
                meal = addClientDetailDto.meal,
                bathing = addClientDetailDto.bathing,
                dressing = addClientDetailDto.dressing,
                grooming = addClientDetailDto.grooming,
                selffreq = addClientDetailDto.selffreq,
                othrfreq = addClientDetailDto.othrfreq,
                destrfreq = addClientDetailDto.destrfreq,
                disrfreq = addClientDetailDto.disrfreq,
                reptfreq = addClientDetailDto.reptfreq,
                offfreq = addClientDetailDto.offfreq,
                wibfreq = addClientDetailDto.wibfreq,
                uncoopfreq = addClientDetailDto.uncoopfreq,
                wanderfreq = addClientDetailDto.wanderfreq,
                picafreq = addClientDetailDto.picafreq,
                selfsev = addClientDetailDto.selfsev,
                othrsev = addClientDetailDto.othrsev,
                destrsev = addClientDetailDto.destrsev,
                disrsev = addClientDetailDto.disrsev,
                reptsev = addClientDetailDto.reptsev,
                offsev = addClientDetailDto.offsev,
                wibsev = addClientDetailDto.wibsev,
                uncoopsev = addClientDetailDto.uncoopsev,
                wandersev = addClientDetailDto.wandersev,
                picasev = addClientDetailDto.picasev,
                behavadapt = addClientDetailDto.behavadapt,
                intakestat = addClientDetailDto.intakestat,
                detdate = addClientDetailDto.detdate,
                detcode = addClientDetailDto.detcode,
                svcdate = addClientDetailDto.svcdate,
                appdate = addClientDetailDto.appdate,
                provision = addClientDetailDto.provision,
                classasuit = addClientDetailDto.classasuit,
                lastplace = addClientDetailDto.lastplace,
                volunteer = addClientDetailDto.volunteer,
                visitor_rs = addClientDetailDto.visitor_rs,
                religion = addClientDetailDto.religion,
                relig_note = addClientDetailDto.relig_note,
                dayplace = addClientDetailDto.dayplace,
                resprior = addClientDetailDto.resprior,
                resplace = addClientDetailDto.resplace,
                namerele = addClientDetailDto.namerele,
                photoclr = addClientDetailDto.photoclr,
                legalcomp = addClientDetailDto.legalcomp,
                dol_adjuca = addClientDetailDto.dol_adjuca,
                treason = addClientDetailDto.treason,
                termdate = addClientDetailDto.termdate,
                discsum = addClientDetailDto.discsum,
                pictureext = addClientDetailDto.pictureext,
                picfilename = addClientDetailDto.picfilename,
                is_uscitz = addClientDetailDto.is_uscitz,
                a_num = addClientDetailDto.a_num,
                a_numexpdt = addClientDetailDto.a_numexpdt,

                agept = addClientDetailDto.agept,
                behavexist = addClientDetailDto.behavexist,
                behavobjno = addClientDetailDto.behavobjno,
                behavtitle = addClientDetailDto.behavtitle,
                bfreefactr = addClientDetailDto.bfreefactr,
                bgenhypoth = addClientDetailDto.bgenhypoth,
                bhvintrval = addClientDetailDto.bhvintrval,
                bhvrsp_key = addClientDetailDto.bhvrsp_key,
                birthplace = addClientDetailDto.birthplace,
                bprecursor = addClientDetailDto.bprecursor,
                caseman = addClientDetailDto.caseman,
                citizenshipcode = addClientDetailDto.citizenshipcode,
                claid = addClientDetailDto.claid,
                clientDetail_key = addClientDetailDto.clientDetail_key, //  should we be passing this value?
                closcount = addClientDetailDto.closcount,
                closdate = addClientDetailDto.closdate,
                closdispcode = addClientDetailDto.closdispcode,
                closrescode = addClientDetailDto.closrescode,
                cntyorigincode = addClientDetailDto.cntyorigincode,
                courttreatmentcode = addClientDetailDto.courttreatmentcode,
                deldate = addClientDetailDto.deldate,
                dfi_cfi_enroll = addClientDetailDto.dfi_cfi_enroll,
                dfscaseid = addClientDetailDto.dfscaseid,
                disch_date = addClientDetailDto.disch_date,
                disch_reason = addClientDetailDto.disch_reason,
                disch_time = addClientDetailDto.disch_time,
                dsm4axis1 = addClientDetailDto.dsm4axis1,
                dsm4axis2 = addClientDetailDto.dsm4axis2,
                dsm4axis3 = addClientDetailDto.dsm4axis3,
                dsm4axis4 = addClientDetailDto.dsm4axis4,
                dsm4sofa = addClientDetailDto.dsm4sofa,
                funpresnt = addClientDetailDto.funpresnt,
                funvision = addClientDetailDto.funvision,
                gdnstat = addClientDetailDto.gdnstat,
                hispanicorigincode = addClientDetailDto.hispanicorigincode,
                homepresnt = addClientDetailDto.homepresnt,
                homevision = addClientDetailDto.homevision,
                hospitalpref = addClientDetailDto.hospitalpref,
                interpsvccode = addClientDetailDto.interpsvccode,
                ippdate = addClientDetailDto.ippdate,
                is_current = addClientDetailDto.is_current,
                lastpdp = addClientDetailDto.lastpdp,
                lernpresnt = addClientDetailDto.lernpresnt,
                lernvision = addClientDetailDto.lernvision,
                livunit_key = addClientDetailDto.livunit_key,
                milstatcode = addClientDetailDto.milstatcode,
                mmaidname = addClientDetailDto.mmaidname,
                nextpdp = addClientDetailDto.nextpdp,
                notepad = addClientDetailDto.notepad,
                obj_met = addClientDetailDto.obj_met,
                oth2presnt = addClientDetailDto.oth2presnt,
                oth2vision = addClientDetailDto.oth2vision,
                oth3presnt = addClientDetailDto.oth3presnt,
                oth3vision = addClientDetailDto.oth3vision,
                othrace = addClientDetailDto.othrace,
                othragencies = addClientDetailDto.othragencies,
                othrpresnt = addClientDetailDto.othrpresnt,
                othrvision = addClientDetailDto.othrvision,
                palspresnt = addClientDetailDto.palspresnt,
                palsvision = addClientDetailDto.palsvision,
                picture = addClientDetailDto.picture,
                publicaidid = addClientDetailDto.publicaidid,
                regcount = addClientDetailDto.regcount,
                regdate = addClientDetailDto.regdate,
                regrescode = addClientDetailDto.regrescode,
                rep_payee = addClientDetailDto.rep_payee,
                revduedate = addClientDetailDto.revduedate,
                revfirst = addClientDetailDto.revfirst,
                revlast = addClientDetailDto.revlast,
                ROCSDD_DnLoad = addClientDetailDto.ROCSDD_DnLoad,
                ROCS_DnLoad = addClientDetailDto.ROCS_DnLoad,
                ROCS_UpLoad = addClientDetailDto.ROCS_UpLoad,
                site = addClientDetailDto.site,
                sname = addClientDetailDto.sname,
                srcsuppins = addClientDetailDto.srcsuppins,
                ssi_ssdi_eligcode = addClientDetailDto.ssi_ssdi_eligcode,
                statefacid = addClientDetailDto.statefacid,
                tca_code = addClientDetailDto.tca_code,
                tca_origincode = addClientDetailDto.tca_origincode,
                timestamp_column = addClientDetailDto.timestamp_column,
                triggrdate = addClientDetailDto.triggrdate,
                workpresnt = addClientDetailDto.workpresnt,
                workvision = addClientDetailDto.workvision,
                ytdleave = addClientDetailDto.ytdleave,
                zipcode_origin = addClientDetailDto.zipcode_origin
            };



            _context.Add(newClientDetail);
            _context.SaveChanges();

            return Ok(newClientDetail);
        }

        [HttpPut]
        public IActionResult UpdateClientDetail(int id, ClientDetailDto updatedClientDetailDto)
        {
            ClientDetail updatedClientDetail = _context.ClientDetails.Find(id);

            if (updatedClientDetail == null)
                return NotFound();

            //Move data from Entity record to Dto
            updatedClientDetail.ssn = updatedClientDetailDto.ssn;
            updatedClientDetail.admitted = updatedClientDetailDto.admitted;
            updatedClientDetail.sex = updatedClientDetailDto.sex;
            updatedClientDetail.maidnm = updatedClientDetailDto.maidnm;
            updatedClientDetail.hphone = updatedClientDetailDto.hphone;
            updatedClientDetail.wphone = updatedClientDetailDto.wphone;
            updatedClientDetail.marital = updatedClientDetailDto.marital;
            updatedClientDetail.birthday = updatedClientDetailDto.birthday;
            updatedClientDetail.bill_id = updatedClientDetailDto.bill_id;
            updatedClientDetail.bill_code = updatedClientDetailDto.bill_code;
            updatedClientDetail.group1 = updatedClientDetailDto.group1;
            updatedClientDetail.group2 = updatedClientDetailDto.group2;
            updatedClientDetail.wphonext = updatedClientDetailDto.wphonext;
            updatedClientDetail.countleg = updatedClientDetailDto.countleg;
            updatedClientDetail.county = updatedClientDetailDto.county;
            updatedClientDetail.resp_key = updatedClientDetailDto.resp_key;
            updatedClientDetail.excaseman = updatedClientDetailDto.excaseman;
            updatedClientDetail.location = updatedClientDetailDto.location;
            updatedClientDetail.dayprogram = updatedClientDetailDto.dayprogram;
            updatedClientDetail.medicare = updatedClientDetailDto.medicare;
            updatedClientDetail.medicaid = updatedClientDetailDto.medicaid;
            updatedClientDetail.ethnic = updatedClientDetailDto.ethnic;
            updatedClientDetail.homewaiver = updatedClientDetailDto.homewaiver;
            updatedClientDetail.recstsupp = updatedClientDetailDto.recstsupp;
            updatedClientDetail.reppayee = updatedClientDetailDto.reppayee;
            updatedClientDetail.employer = updatedClientDetailDto.employer;
            updatedClientDetail.emptype = updatedClientDetailDto.emptype;
            updatedClientDetail.hiredate = updatedClientDetailDto.hiredate;
            updatedClientDetail.hrlyrate = updatedClientDetailDto.hrlyrate;
            updatedClientDetail.costtrans = updatedClientDetailDto.costtrans;
            updatedClientDetail.empnohrs = updatedClientDetailDto.empnohrs;
            updatedClientDetail.paymonth = updatedClientDetailDto.paymonth;
            updatedClientDetail.payamt = updatedClientDetailDto.payamt;
            updatedClientDetail.costtools = updatedClientDetailDto.costtools;
            updatedClientDetail.uimasocsec = updatedClientDetailDto.uimasocsec;
            updatedClientDetail.uimassi = updatedClientDetailDto.uimassi;
            updatedClientDetail.uimava = updatedClientDetailDto.uimava;
            updatedClientDetail.uimatrust = updatedClientDetailDto.uimatrust;
            updatedClientDetail.uimarb = updatedClientDetailDto.uimarb;
            updatedClientDetail.uimapen = updatedClientDetailDto.uimapen;
            updatedClientDetail.uimaint = updatedClientDetailDto.uimaint;
            updatedClientDetail.uimaothr = updatedClientDetailDto.uimaothr;
            updatedClientDetail.incnote = updatedClientDetailDto.incnote;
            updatedClientDetail.olades1 = updatedClientDetailDto.olades1;
            updatedClientDetail.olaval1 = updatedClientDetailDto.olaval1;
            updatedClientDetail.olades2 = updatedClientDetailDto.olades2;
            updatedClientDetail.olaval2 = updatedClientDetailDto.olaval2;
            updatedClientDetail.olades3 = updatedClientDetailDto.olades3;
            updatedClientDetail.olaval3 = updatedClientDetailDto.olaval3;
            updatedClientDetail.olades4 = updatedClientDetailDto.olades4;
            updatedClientDetail.olaval4 = updatedClientDetailDto.olaval4;
            updatedClientDetail.olades5 = updatedClientDetailDto.olades5;
            updatedClientDetail.olaval5 = updatedClientDetailDto.olaval5;
            updatedClientDetail.propval = updatedClientDetailDto.propval;
            updatedClientDetail.vehicval = updatedClientDetailDto.vehicval;
            updatedClientDetail.plotval = updatedClientDetailDto.plotval;
            updatedClientDetail.insval = updatedClientDetailDto.insval;
            updatedClientDetail.totalasset = updatedClientDetailDto.totalasset;
            updatedClientDetail.assetmon = updatedClientDetailDto.assetmon;
            updatedClientDetail.assetyear = updatedClientDetailDto.assetyear;
            updatedClientDetail.mr = updatedClientDetailDto.mr;
            updatedClientDetail.dd = updatedClientDetailDto.dd;
            updatedClientDetail.pd = updatedClientDetailDto.pd;
            updatedClientDetail.care_24hr = updatedClientDetailDto.care_24hr;
            updatedClientDetail.dsmdiag = updatedClientDetailDto.dsmdiag;
            updatedClientDetail.diag = updatedClientDetailDto.diag;
            updatedClientDetail.allergies = updatedClientDetailDto.allergies;
            updatedClientDetail.bloodtype = updatedClientDetailDto.bloodtype;
            updatedClientDetail.height = updatedClientDetailDto.height;
            updatedClientDetail.weight = updatedClientDetailDto.weight;
            updatedClientDetail.complexton = updatedClientDetailDto.complexton;
            updatedClientDetail.eyecolor = updatedClientDetailDto.eyecolor;
            updatedClientDetail.haircolor = updatedClientDetailDto.haircolor;
            updatedClientDetail.vision = updatedClientDetailDto.vision;
            updatedClientDetail.hearing = updatedClientDetailDto.hearing;
            updatedClientDetail.health = updatedClientDetailDto.health;
            updatedClientDetail.seizure = updatedClientDetailDto.seizure;
            updatedClientDetail.physician = updatedClientDetailDto.physician;
            updatedClientDetail.medalert = updatedClientDetailDto.medalert;
            updatedClientDetail.medadapt = updatedClientDetailDto.medadapt;
            updatedClientDetail.diet = updatedClientDetailDto.diet;
            updatedClientDetail.idmarks = updatedClientDetailDto.idmarks;
            updatedClientDetail.assisdev = updatedClientDetailDto.assisdev;
            updatedClientDetail.langus = updatedClientDetailDto.langus;
            updatedClientDetail.commlvle = updatedClientDetailDto.commlvle;
            updatedClientDetail.commmode = updatedClientDetailDto.commmode;
            updatedClientDetail.commlvlr = updatedClientDetailDto.commlvlr;
            updatedClientDetail.commmodr = updatedClientDetailDto.commmodr;
            updatedClientDetail.mentfunc = updatedClientDetailDto.mentfunc;
            updatedClientDetail.adapfunc = updatedClientDetailDto.adapfunc;
            updatedClientDetail.mobility = updatedClientDetailDto.mobility;
            updatedClientDetail.mobassist = updatedClientDetailDto.mobassist;
            updatedClientDetail.armhand = updatedClientDetailDto.armhand;
            updatedClientDetail.vocaskills = updatedClientDetailDto.vocaskills;
            updatedClientDetail.adaptdev = updatedClientDetailDto.adaptdev;
            updatedClientDetail.langspok = updatedClientDetailDto.langspok;
            updatedClientDetail.educalvl = updatedClientDetailDto.educalvl;
            updatedClientDetail.social = updatedClientDetailDto.social;
            updatedClientDetail.transfer = updatedClientDetailDto.transfer;
            updatedClientDetail.toilet = updatedClientDetailDto.toilet;
            updatedClientDetail.eating = updatedClientDetailDto.eating;
            updatedClientDetail.meal = updatedClientDetailDto.meal;
            updatedClientDetail.bathing = updatedClientDetailDto.bathing;
            updatedClientDetail.dressing = updatedClientDetailDto.dressing;
            updatedClientDetail.grooming = updatedClientDetailDto.grooming;
            updatedClientDetail.selffreq = updatedClientDetailDto.selffreq;
            updatedClientDetail.othrfreq = updatedClientDetailDto.othrfreq;
            updatedClientDetail.destrfreq = updatedClientDetailDto.destrfreq;
            updatedClientDetail.disrfreq = updatedClientDetailDto.disrfreq;
            updatedClientDetail.reptfreq = updatedClientDetailDto.reptfreq;
            updatedClientDetail.offfreq = updatedClientDetailDto.offfreq;
            updatedClientDetail.wibfreq = updatedClientDetailDto.wibfreq;
            updatedClientDetail.uncoopfreq = updatedClientDetailDto.uncoopfreq;
            updatedClientDetail.wanderfreq = updatedClientDetailDto.wanderfreq;
            updatedClientDetail.picafreq = updatedClientDetailDto.picafreq;
            updatedClientDetail.selfsev = updatedClientDetailDto.selfsev;
            updatedClientDetail.othrsev = updatedClientDetailDto.othrsev;
            updatedClientDetail.destrsev = updatedClientDetailDto.destrsev;
            updatedClientDetail.disrsev = updatedClientDetailDto.disrsev;
            updatedClientDetail.reptsev = updatedClientDetailDto.reptsev;
            updatedClientDetail.offsev = updatedClientDetailDto.offsev;
            updatedClientDetail.wibsev = updatedClientDetailDto.wibsev;
            updatedClientDetail.uncoopsev = updatedClientDetailDto.uncoopsev;
            updatedClientDetail.wandersev = updatedClientDetailDto.wandersev;
            updatedClientDetail.picasev = updatedClientDetailDto.picasev;
            updatedClientDetail.behavadapt = updatedClientDetailDto.behavadapt;
            updatedClientDetail.intakestat = updatedClientDetailDto.intakestat;
            updatedClientDetail.detdate = updatedClientDetailDto.detdate;
            updatedClientDetail.detcode = updatedClientDetailDto.detcode;
            updatedClientDetail.svcdate = updatedClientDetailDto.svcdate;
            updatedClientDetail.appdate = updatedClientDetailDto.appdate;
            updatedClientDetail.provision = updatedClientDetailDto.provision;
            updatedClientDetail.classasuit = updatedClientDetailDto.classasuit;
            updatedClientDetail.lastplace = updatedClientDetailDto.lastplace;
            updatedClientDetail.volunteer = updatedClientDetailDto.volunteer;
            updatedClientDetail.visitor_rs = updatedClientDetailDto.visitor_rs;
            updatedClientDetail.religion = updatedClientDetailDto.religion;
            updatedClientDetail.relig_note = updatedClientDetailDto.relig_note;
            updatedClientDetail.dayplace = updatedClientDetailDto.dayplace;
            updatedClientDetail.resprior = updatedClientDetailDto.resprior;
            updatedClientDetail.resplace = updatedClientDetailDto.resplace;
            updatedClientDetail.namerele = updatedClientDetailDto.namerele;
            updatedClientDetail.photoclr = updatedClientDetailDto.photoclr;
            updatedClientDetail.legalcomp = updatedClientDetailDto.legalcomp;
            updatedClientDetail.dol_adjuca = updatedClientDetailDto.dol_adjuca;
            updatedClientDetail.treason = updatedClientDetailDto.treason;
            updatedClientDetail.termdate = updatedClientDetailDto.termdate;
            updatedClientDetail.discsum = updatedClientDetailDto.discsum;
            updatedClientDetail.pictureext = updatedClientDetailDto.pictureext;
            updatedClientDetail.picfilename = updatedClientDetailDto.picfilename;
            updatedClientDetail.is_uscitz = updatedClientDetailDto.is_uscitz;
            updatedClientDetail.a_num = updatedClientDetailDto.a_num;
            updatedClientDetail.a_numexpdt = updatedClientDetailDto.a_numexpdt;

            updatedClientDetail.agept = updatedClientDetailDto.agept;
            updatedClientDetail.behavexist = updatedClientDetailDto.behavexist;
            updatedClientDetail.behavobjno = updatedClientDetailDto.behavobjno;
            updatedClientDetail.behavtitle = updatedClientDetailDto.behavtitle;
            updatedClientDetail.bfreefactr = updatedClientDetailDto.bfreefactr;
            updatedClientDetail.bgenhypoth = updatedClientDetailDto.bgenhypoth;
            updatedClientDetail.bhvintrval = updatedClientDetailDto.bhvintrval;
            updatedClientDetail.bhvrsp_key = updatedClientDetailDto.bhvrsp_key;
            updatedClientDetail.birthplace = updatedClientDetailDto.birthplace;
            updatedClientDetail.bprecursor = updatedClientDetailDto.bprecursor;
            updatedClientDetail.caseman = updatedClientDetailDto.caseman;
            updatedClientDetail.citizenshipcode = updatedClientDetailDto.citizenshipcode;
            updatedClientDetail.claid = updatedClientDetailDto.claid;
            updatedClientDetail.clientDetail_key = updatedClientDetailDto.clientDetail_key; //  should we be passing this value?
            updatedClientDetail.closcount = updatedClientDetailDto.closcount;
            updatedClientDetail.closdate = updatedClientDetailDto.closdate;
            updatedClientDetail.closdispcode = updatedClientDetailDto.closdispcode;
            updatedClientDetail.closrescode = updatedClientDetailDto.closrescode;
            updatedClientDetail.cntyorigincode = updatedClientDetailDto.cntyorigincode;
            updatedClientDetail.courttreatmentcode = updatedClientDetailDto.courttreatmentcode;
            updatedClientDetail.deldate = updatedClientDetailDto.deldate;
            updatedClientDetail.dfi_cfi_enroll = updatedClientDetailDto.dfi_cfi_enroll;
            updatedClientDetail.dfscaseid = updatedClientDetailDto.dfscaseid;
            updatedClientDetail.disch_date = updatedClientDetailDto.disch_date;
            updatedClientDetail.disch_reason = updatedClientDetailDto.disch_reason;
            updatedClientDetail.disch_time = updatedClientDetailDto.disch_time;
            updatedClientDetail.dsm4axis1 = updatedClientDetailDto.dsm4axis1;
            updatedClientDetail.dsm4axis2 = updatedClientDetailDto.dsm4axis2;
            updatedClientDetail.dsm4axis3 = updatedClientDetailDto.dsm4axis3;
            updatedClientDetail.dsm4axis4 = updatedClientDetailDto.dsm4axis4;
            updatedClientDetail.dsm4sofa = updatedClientDetailDto.dsm4sofa;
            updatedClientDetail.funpresnt = updatedClientDetailDto.funpresnt;
            updatedClientDetail.funvision = updatedClientDetailDto.funvision;
            updatedClientDetail.gdnstat = updatedClientDetailDto.gdnstat;
            updatedClientDetail.hispanicorigincode = updatedClientDetailDto.hispanicorigincode;
            updatedClientDetail.homepresnt = updatedClientDetailDto.homepresnt;
            updatedClientDetail.homevision = updatedClientDetailDto.homevision;
            updatedClientDetail.hospitalpref = updatedClientDetailDto.hospitalpref;
            updatedClientDetail.interpsvccode = updatedClientDetailDto.interpsvccode;
            updatedClientDetail.ippdate = updatedClientDetailDto.ippdate;
            updatedClientDetail.is_current = updatedClientDetailDto.is_current;
            updatedClientDetail.lastpdp = updatedClientDetailDto.lastpdp;
            updatedClientDetail.lernpresnt = updatedClientDetailDto.lernpresnt;
            updatedClientDetail.lernvision = updatedClientDetailDto.lernvision;
            updatedClientDetail.livunit_key = updatedClientDetailDto.livunit_key;
            updatedClientDetail.milstatcode = updatedClientDetailDto.milstatcode;
            updatedClientDetail.mmaidname = updatedClientDetailDto.mmaidname;
            updatedClientDetail.nextpdp = updatedClientDetailDto.nextpdp;
            updatedClientDetail.notepad = updatedClientDetailDto.notepad;
            updatedClientDetail.obj_met = updatedClientDetailDto.obj_met;
            updatedClientDetail.oth2presnt = updatedClientDetailDto.oth2presnt;
            updatedClientDetail.oth2vision = updatedClientDetailDto.oth2vision;
            updatedClientDetail.oth3presnt = updatedClientDetailDto.oth3presnt;
            updatedClientDetail.oth3vision = updatedClientDetailDto.oth3vision;
            updatedClientDetail.othrace = updatedClientDetailDto.othrace;
            updatedClientDetail.othragencies = updatedClientDetailDto.othragencies;
            updatedClientDetail.othrpresnt = updatedClientDetailDto.othrpresnt;
            updatedClientDetail.othrvision = updatedClientDetailDto.othrvision;
            updatedClientDetail.palspresnt = updatedClientDetailDto.palspresnt;
            updatedClientDetail.palsvision = updatedClientDetailDto.palsvision;
            updatedClientDetail.picture = updatedClientDetailDto.picture;
            updatedClientDetail.publicaidid = updatedClientDetailDto.publicaidid;
            updatedClientDetail.regcount = updatedClientDetailDto.regcount;
            updatedClientDetail.regdate = updatedClientDetailDto.regdate;
            updatedClientDetail.regrescode = updatedClientDetailDto.regrescode;
            updatedClientDetail.rep_payee = updatedClientDetailDto.rep_payee;
            updatedClientDetail.revduedate = updatedClientDetailDto.revduedate;
            updatedClientDetail.revfirst = updatedClientDetailDto.revfirst;
            updatedClientDetail.revlast = updatedClientDetailDto.revlast;
            updatedClientDetail.ROCSDD_DnLoad = updatedClientDetailDto.ROCSDD_DnLoad;
            updatedClientDetail.ROCS_DnLoad = updatedClientDetailDto.ROCS_DnLoad;
            updatedClientDetail.ROCS_UpLoad = updatedClientDetailDto.ROCS_UpLoad;
            updatedClientDetail.site = updatedClientDetailDto.site;
            updatedClientDetail.sname = updatedClientDetailDto.sname;
            updatedClientDetail.srcsuppins = updatedClientDetailDto.srcsuppins;
            updatedClientDetail.ssi_ssdi_eligcode = updatedClientDetailDto.ssi_ssdi_eligcode;
            updatedClientDetail.statefacid = updatedClientDetailDto.statefacid;
            updatedClientDetail.tca_code = updatedClientDetailDto.tca_code;
            updatedClientDetail.tca_origincode = updatedClientDetailDto.tca_origincode;
            updatedClientDetail.timestamp_column = updatedClientDetailDto.timestamp_column;
            updatedClientDetail.triggrdate = updatedClientDetailDto.triggrdate;
            updatedClientDetail.workpresnt = updatedClientDetailDto.workpresnt;
            updatedClientDetail.workvision = updatedClientDetailDto.workvision;
            updatedClientDetail.ytdleave = updatedClientDetailDto.ytdleave;
            updatedClientDetail.zipcode_origin = updatedClientDetailDto.zipcode_origin;

            _context.SaveChanges();
            return Ok(updatedClientDetail);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteClientDetail(int id)
        {

            ClientDetail clientDetail = _context.ClientDetails.Find(id);

            if (clientDetail is null)
            { return NotFound(); }

            _context.Remove(clientDetail);
            _context.SaveChanges();

            return Ok();
        }




    }

}
