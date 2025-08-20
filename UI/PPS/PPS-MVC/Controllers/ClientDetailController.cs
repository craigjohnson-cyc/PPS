using DataModels.Models.Entities;
using DataModels.Models.DTOs;
using DataModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Dynamic;
using DataModels.Models.PickList;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PPS_MVC.Controllers
{
    public class ClientDetailController : Controller
    {
        private readonly ILogger<ClientDetailController> _logger;

        public ClientDetailController(ILogger<ClientDetailController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> DisplayClientDetails(int id)
        {
            int selectedClientKey = id;

            // Get Client info for header
            //---------------------------
            Client selectedClient = await GetClient(selectedClientKey);

            // Get Client Detail info
            //-----------------------
            ClientDetail clientDetail = await GetClientDetail(selectedClientKey);

            // Load ResponsiblePersons array and add to mymodel
            // for drop down lists
            //-------------------------------------------------
            var respPersons = await GetResponsiblePersonValues();

            // Load piklist values and add to mymodel
            // for drop down lists
            //---------------------------------------
            var pikListValues = await GetPickListValues();


            ClientDetailView mymodel = new()
            {
                client = selectedClient,
                clientDetail = clientDetail,
                responsiblePersons = respPersons,
                pickListValues = pikListValues
            };

            if (clientDetail == null || clientDetail.clientDetail_key == 0)
            {
                return View("AddClientDetails", mymodel);  // this handles both Add and Edit
            }
            else
            {
                return View("DisplayClientDetails", mymodel);
            }
        }



        public async Task<ActionResult> AddClientDetails(int id)
        {

            int selectedClientKey = id;
            // Get Client info for header
            //---------------------------
            Client selectedClient = await GetClient(selectedClientKey);

            // Get Client Details
            //-------------------
            ClientDetail clientDetail = await GetClientDetail(selectedClientKey);

            // Load ResponsiblePersons array and add to mymodel
            // for drop down lists
            //-------------------------------------------------
            var respPersons = await GetResponsiblePersonValues();

            // Load piklist values and add to mymodel
            // for drop down lists
            //---------------------------------------
            var pikListValues = await GetPickListValues();


            ClientDetailView mymodel = new()
            {
                client = selectedClient,
                clientDetail = clientDetail,
                responsiblePersons = respPersons,
                pickListValues = pikListValues
            };
            // Display Screen
            //---------------
            return View(mymodel);
        }


        public async Task<ActionResult> EditClientDetails(int id)
        {
            int selectedClientKey = id;

            // Get Client info for header
            //---------------------------
            Client selectedClient = await GetClient(selectedClientKey);

            // Get Client Detail info
            //-----------------------
            ClientDetail clientDetail = await GetClientDetail(selectedClientKey);

            // Load ResponsiblePersons array and add to mymodel
            // for drop down lists
            //-------------------------------------------------
            var respPersons = await GetResponsiblePersonValues();

            // Load piklist values and add to mymodel
            // for drop down lists
            //---------------------------------------
            var pikListValues = await GetPickListValues();


            ClientDetailView mymodel = new()
            {
                client = selectedClient,
                clientDetail = clientDetail,
                responsiblePersons = respPersons,
                pickListValues = pikListValues
            };

            return View("AddClientDetails", mymodel);  // this handles both Add and Edit
        }


        public async Task<List<piklist>> GetPickListValues()
        {
            List<piklist> pikListValues = new List<piklist>();
            var pikListUrl = "https://localhost:7173/api/PikList";
            using (HttpClient pikListClient = new HttpClient())
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                pikListClient.BaseAddress = new Uri(pikListUrl);
                pikListClient.DefaultRequestHeaders.Accept.Clear();
                pikListClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response3 = await pikListClient.GetAsync(pikListUrl);
                if (response3.IsSuccessStatusCode)
                {
                    var pikListValuesJson = await response3.Content.ReadAsStringAsync();

                    pikListValues = JsonSerializer.Deserialize<List<piklist>>(pikListValuesJson);

                    if (pikListValues != null)
                    {
                        return pikListValues;
                    }
                }
            }
            var item = new piklist()
            {
                code = "",
                fieldd = "",
                filee = "",
                htb = "",
                item = "",
                location = "",
                longtitle = "",
                ordr = 0,
                piklist_key = 0,
                pikname_key = 0

            };
            pikListValues.Add(item);
            return pikListValues;
        }
        public async Task<List<ResponsiblePerson>> GetResponsiblePersonValues()
        {
            List<ResponsiblePerson> respPersons = new List<ResponsiblePerson>();
            var responsiblePersonUrl = "https://localhost:7173/api/ClientDetails";
            using (HttpClient responsiblePersonClient = new HttpClient())
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                responsiblePersonClient.BaseAddress = new Uri(responsiblePersonUrl);
                responsiblePersonClient.DefaultRequestHeaders.Accept.Clear();
                responsiblePersonClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response3 = await responsiblePersonClient.GetAsync(responsiblePersonUrl);
                if (response3.IsSuccessStatusCode)
                {
                    var responsiblePersonJson = await response3.Content.ReadAsStringAsync();

                    //List<ResponsiblePersonDto> responsiblePersonsList = JsonSerializer.Deserialize<List<ResponsiblePersonDto>>(responsiblePersonJson);
                    List<ResponsiblePerson> responsiblePersonsList = JsonSerializer.Deserialize<List<ResponsiblePerson>>(responsiblePersonJson);

                    //foreach (var p in responsiblePersonsList)
                    //{
                    //    var person = new ResponsiblePerson() { staffKey = p.staffKey, staffName = p.staffName };
                    //    respPersons.Add(person);
                    //}
                    if (responsiblePersonsList != null)
                    {
                        return responsiblePersonsList;
                    }
                }
                var item = new ResponsiblePerson()
                {
                    staffName = "",
                    staffKey = 0

                };
                respPersons.Add(item);
                return respPersons;
            }

        }

        public async Task<Client> GetClient(int selectedClientKey)
        {
            // Get Client info for header
            //---------------------------
            Client selectedClient = new Client();
            var clientUrl = "https://localhost:7173/api/Clients/" + selectedClientKey.ToString();
            using (HttpClient webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(clientUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response2 = await webClient.GetAsync(clientUrl);
                if (response2.IsSuccessStatusCode)
                {
                    var clientData = await response2.Content.ReadAsStringAsync();

                    selectedClient = JsonSerializer.Deserialize<Client>(clientData);
                }

            }
            if (selectedClient == null)
            {
                selectedClient.aka = "";
                selectedClient.address = "";
                selectedClient.address2 = "";
                selectedClient.clientno = "";
                selectedClient.client_key = 0;
                selectedClient.state = "";
                selectedClient.city = "";
                selectedClient.fname = "";
                selectedClient.mname = "";
                selectedClient.lname = "";
                selectedClient.zip = "";
            }
            return selectedClient;

        }

        public async Task<ClientDetail> GetClientDetail(int selectedClientKey)
        {
            var clientDetail = new ClientDetail();
            var apiUrl = "https://localhost:7173/api/ClientDetails/" + selectedClientKey.ToString();
            using (HttpClient wclient = new HttpClient())
            {
                wclient.BaseAddress = new Uri(apiUrl);
                wclient.DefaultRequestHeaders.Accept.Clear();
                wclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await wclient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    // Convert return data to <ClientDetailDto>
                    var clientDetailsDto = JsonSerializer.Deserialize<ClientDetailDto>(data);

                    if (clientDetailsDto == null)
                    {
                        clientDetailsDto = new ClientDetailDto();
                    }
                    else
                    {
                        clientDetail = new ClientDetail()
                        {
                            client_key = clientDetailsDto.client_key,
                            clientDetail_key = clientDetailsDto.clientDetail_key,
                            ssn = clientDetailsDto.ssn,
                            admitted = clientDetailsDto.admitted,
                            sex = clientDetailsDto.sex,
                            maidnm = clientDetailsDto.maidnm,
                            hphone = clientDetailsDto.hphone,
                            wphone = clientDetailsDto.wphone,
                            marital = clientDetailsDto.marital,
                            birthday = clientDetailsDto.birthday,
                            bill_id = clientDetailsDto.bill_id,
                            bill_code = clientDetailsDto.bill_code,
                            group1 = clientDetailsDto.group1,
                            group2 = clientDetailsDto.group2,
                            wphonext = clientDetailsDto.wphonext,
                            countleg = clientDetailsDto.countleg,
                            county = clientDetailsDto.county,
                            resp_key = clientDetailsDto.resp_key,
                            excaseman = clientDetailsDto.excaseman,
                            location = clientDetailsDto.location,
                            dayprogram = clientDetailsDto.dayprogram,
                            medicare = clientDetailsDto.medicare,
                            medicaid = clientDetailsDto.medicaid,
                            ethnic = clientDetailsDto.ethnic,
                            homewaiver = clientDetailsDto.homewaiver,
                            recstsupp = clientDetailsDto.recstsupp,
                            reppayee = clientDetailsDto.reppayee,
                            employer = clientDetailsDto.employer,
                            emptype = clientDetailsDto.emptype,
                            hiredate = clientDetailsDto.hiredate,
                            hrlyrate = clientDetailsDto.hrlyrate,
                            costtrans = clientDetailsDto.costtrans,
                            empnohrs = clientDetailsDto.empnohrs,
                            paymonth = clientDetailsDto.paymonth,
                            payamt = clientDetailsDto.payamt,
                            costtools = clientDetailsDto.costtools,
                            uimasocsec = clientDetailsDto.uimasocsec,
                            uimassi = clientDetailsDto.uimassi,
                            uimava = clientDetailsDto.uimava,
                            uimatrust = clientDetailsDto.uimatrust,
                            uimarb = clientDetailsDto.uimarb,
                            uimapen = clientDetailsDto.uimapen,
                            uimaint = clientDetailsDto.uimaint,
                            uimaothr = clientDetailsDto.uimaothr,
                            incnote = clientDetailsDto.incnote,
                            olades1 = clientDetailsDto.olades1,
                            olaval1 = clientDetailsDto.olaval1,
                            olades2 = clientDetailsDto.olades2,
                            olaval2 = clientDetailsDto.olaval2,
                            olades3 = clientDetailsDto.olades3,
                            olaval3 = clientDetailsDto.olaval3,
                            olades4 = clientDetailsDto.olades4,
                            olaval4 = clientDetailsDto.olaval4,
                            olades5 = clientDetailsDto.olades5,
                            olaval5 = clientDetailsDto.olaval5,
                            propval = clientDetailsDto.propval,
                            vehicval = clientDetailsDto.vehicval,
                            plotval = clientDetailsDto.plotval,
                            insval = clientDetailsDto.insval,
                            totalasset = clientDetailsDto.totalasset,
                            assetmon = clientDetailsDto.assetmon,
                            assetyear = clientDetailsDto.assetyear,
                            mr = clientDetailsDto.mr,
                            dd = clientDetailsDto.dd,
                            pd = clientDetailsDto.pd,
                            care_24hr = clientDetailsDto.care_24hr,
                            dsmdiag = clientDetailsDto.dsmdiag,
                            diag = clientDetailsDto.diag,
                            allergies = clientDetailsDto.allergies,
                            bloodtype = clientDetailsDto.bloodtype,
                            height = clientDetailsDto.height,
                            weight = clientDetailsDto.weight,
                            complexton = clientDetailsDto.complexton,
                            eyecolor = clientDetailsDto.eyecolor,
                            haircolor = clientDetailsDto.haircolor,
                            vision = clientDetailsDto.vision,
                            hearing = clientDetailsDto.hearing,
                            health = clientDetailsDto.health,
                            seizure = clientDetailsDto.seizure,
                            physician = clientDetailsDto.physician,
                            medalert = clientDetailsDto.medalert,
                            medadapt = clientDetailsDto.medadapt,
                            diet = clientDetailsDto.diet,
                            idmarks = clientDetailsDto.idmarks,
                            assisdev = clientDetailsDto.assisdev,
                            langus = clientDetailsDto.langus,
                            commlvle = clientDetailsDto.commlvle,
                            commmode = clientDetailsDto.commmode,
                            commlvlr = clientDetailsDto.commlvlr,
                            commmodr = clientDetailsDto.commmodr,
                            mentfunc = clientDetailsDto.mentfunc,
                            adapfunc = clientDetailsDto.adapfunc,
                            mobility = clientDetailsDto.mobility,
                            mobassist = clientDetailsDto.mobassist,
                            armhand = clientDetailsDto.armhand,
                            vocaskills = clientDetailsDto.vocaskills,
                            adaptdev = clientDetailsDto.adaptdev,
                            langspok = clientDetailsDto.langspok,
                            educalvl = clientDetailsDto.educalvl,
                            social = clientDetailsDto.social,
                            transfer = clientDetailsDto.transfer,
                            toilet = clientDetailsDto.toilet,
                            eating = clientDetailsDto.eating,
                            meal = clientDetailsDto.meal,
                            bathing = clientDetailsDto.bathing,
                            dressing = clientDetailsDto.dressing,
                            grooming = clientDetailsDto.grooming,
                            selffreq = clientDetailsDto.selffreq,
                            othrfreq = clientDetailsDto.othrfreq,
                            destrfreq = clientDetailsDto.destrfreq,
                            disrfreq = clientDetailsDto.disrfreq,
                            reptfreq = clientDetailsDto.reptfreq,
                            offfreq = clientDetailsDto.offfreq,
                            wibfreq = clientDetailsDto.wibfreq,
                            uncoopfreq = clientDetailsDto.uncoopfreq,
                            wanderfreq = clientDetailsDto.wanderfreq,
                            picafreq = clientDetailsDto.picafreq,
                            selfsev = clientDetailsDto.selfsev,
                            othrsev = clientDetailsDto.othrsev,
                            destrsev = clientDetailsDto.destrsev,
                            disrsev = clientDetailsDto.disrsev,
                            reptsev = clientDetailsDto.reptsev,
                            offsev = clientDetailsDto.offsev,
                            wibsev = clientDetailsDto.wibsev,
                            uncoopsev = clientDetailsDto.uncoopsev,
                            wandersev = clientDetailsDto.wandersev,
                            picasev = clientDetailsDto.picasev,
                            behavadapt = clientDetailsDto.behavadapt,
                            intakestat = clientDetailsDto.intakestat,
                            detdate = clientDetailsDto.detdate,
                            detcode = clientDetailsDto.detcode,
                            svcdate = clientDetailsDto.svcdate,
                            appdate = clientDetailsDto.appdate,
                            provision = clientDetailsDto.provision,
                            classasuit = clientDetailsDto.classasuit,
                            lastplace = clientDetailsDto.lastplace,
                            volunteer = clientDetailsDto.volunteer,
                            visitor_rs = clientDetailsDto.visitor_rs,
                            religion = clientDetailsDto.religion,
                            relig_note = clientDetailsDto.relig_note,
                            dayplace = clientDetailsDto.dayplace,
                            resprior = clientDetailsDto.resprior,
                            resplace = clientDetailsDto.resplace,
                            namerele = clientDetailsDto.namerele,
                            photoclr = clientDetailsDto.photoclr,
                            legalcomp = clientDetailsDto.legalcomp,
                            dol_adjuca = clientDetailsDto.dol_adjuca,
                            treason = clientDetailsDto.treason,
                            termdate = clientDetailsDto.termdate,
                            discsum = clientDetailsDto.discsum,
                            pictureext = clientDetailsDto.pictureext,
                            picfilename = clientDetailsDto.picfilename,
                            is_uscitz = clientDetailsDto.is_uscitz,
                            a_num = clientDetailsDto.a_num,
                            a_numexpdt = clientDetailsDto.a_numexpdt,

                            agept = clientDetailsDto.agept,
                            behavexist = clientDetailsDto.behavexist,
                            behavobjno = clientDetailsDto.behavobjno,
                            behavtitle = clientDetailsDto.behavtitle,
                            bfreefactr = clientDetailsDto.bfreefactr,
                            bgenhypoth = clientDetailsDto.bgenhypoth,
                            bhvintrval = clientDetailsDto.bhvintrval,
                            bhvrsp_key = clientDetailsDto.bhvrsp_key,
                            birthplace = clientDetailsDto.birthplace,
                            bprecursor = clientDetailsDto.bprecursor,
                            caseman = clientDetailsDto.caseman,
                            citizenshipcode = clientDetailsDto.citizenshipcode,
                            claid = clientDetailsDto.claid,
                            closcount = clientDetailsDto.closcount,
                            closdate = clientDetailsDto.closdate,
                            closdispcode = clientDetailsDto.closdispcode,
                            closrescode = clientDetailsDto.closrescode,
                            cntyorigincode = clientDetailsDto.cntyorigincode,
                            courttreatmentcode = clientDetailsDto.courttreatmentcode,
                            deldate = clientDetailsDto.deldate,
                            dfi_cfi_enroll = clientDetailsDto.dfi_cfi_enroll,
                            dfscaseid = clientDetailsDto.dfscaseid,
                            disch_date = clientDetailsDto.disch_date,
                            disch_reason = clientDetailsDto.disch_reason,
                            disch_time = clientDetailsDto.disch_time,
                            dsm4axis1 = clientDetailsDto.dsm4axis1,
                            dsm4axis2 = clientDetailsDto.dsm4axis2,
                            dsm4axis3 = clientDetailsDto.dsm4axis3,
                            dsm4axis4 = clientDetailsDto.dsm4axis4,
                            dsm4sofa = clientDetailsDto.dsm4sofa,
                            funpresnt = clientDetailsDto.funpresnt,
                            funvision = clientDetailsDto.funvision,
                            gdnstat = clientDetailsDto.gdnstat,
                            hispanicorigincode = clientDetailsDto.hispanicorigincode,
                            homepresnt = clientDetailsDto.homepresnt,
                            homevision = clientDetailsDto.homevision,
                            hospitalpref = clientDetailsDto.hospitalpref,
                            interpsvccode = clientDetailsDto.interpsvccode,
                            ippdate = clientDetailsDto.ippdate,
                            is_current = clientDetailsDto.is_current,
                            lastpdp = clientDetailsDto.lastpdp,
                            lernpresnt = clientDetailsDto.lernpresnt,
                            lernvision = clientDetailsDto.lernvision,
                            livunit_key = clientDetailsDto.livunit_key,
                            milstatcode = clientDetailsDto.milstatcode,
                            mmaidname = clientDetailsDto.mmaidname,
                            nextpdp = clientDetailsDto.nextpdp,
                            notepad = clientDetailsDto.notepad,
                            obj_met = clientDetailsDto.obj_met,
                            oth2presnt = clientDetailsDto.oth2presnt,
                            oth2vision = clientDetailsDto.oth2vision,
                            oth3presnt = clientDetailsDto.oth3presnt,
                            oth3vision = clientDetailsDto.oth3vision,
                            othrace = clientDetailsDto.othrace,
                            othragencies = clientDetailsDto.othragencies,
                            othrpresnt = clientDetailsDto.othrpresnt,
                            othrvision = clientDetailsDto.othrvision,
                            palspresnt = clientDetailsDto.palspresnt,
                            palsvision = clientDetailsDto.palsvision,
                            picture = clientDetailsDto.picture,
                            publicaidid = clientDetailsDto.publicaidid,
                            regcount = clientDetailsDto.regcount,
                            regdate = clientDetailsDto.regdate,
                            regrescode = clientDetailsDto.regrescode,
                            rep_payee = clientDetailsDto.rep_payee,
                            revduedate = clientDetailsDto.revduedate,
                            revfirst = clientDetailsDto.revfirst,
                            revlast = clientDetailsDto.revlast,
                            ROCSDD_DnLoad = clientDetailsDto.ROCSDD_DnLoad,
                            ROCS_DnLoad = clientDetailsDto.ROCS_DnLoad,
                            ROCS_UpLoad = clientDetailsDto.ROCS_UpLoad,
                            site = clientDetailsDto.site,
                            sname = clientDetailsDto.sname,
                            srcsuppins = clientDetailsDto.srcsuppins,
                            ssi_ssdi_eligcode = clientDetailsDto.ssi_ssdi_eligcode,
                            statefacid = clientDetailsDto.statefacid,
                            tca_code = clientDetailsDto.tca_code,
                            tca_origincode = clientDetailsDto.tca_origincode,
                            timestamp_column = clientDetailsDto.timestamp_column,
                            triggrdate = clientDetailsDto.triggrdate,
                            workpresnt = clientDetailsDto.workpresnt,
                            workvision = clientDetailsDto.workvision,
                            ytdleave = clientDetailsDto.ytdleave,
                            zipcode_origin = clientDetailsDto.zipcode_origin

                        };
                    }
                }
            }
            return clientDetail;
        }
    }

}
