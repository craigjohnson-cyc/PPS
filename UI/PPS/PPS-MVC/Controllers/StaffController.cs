using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DataModels.Models;
using DataModels.Models.Entities;
using DataModels.Models.DTOs;
using System.Collections.Generic;
using System.Net;

namespace PPS_MVC.Controllers
{
    public class StaffController : Controller
    {
        private readonly ILogger<StaffController> _logger;
        private string whereClause { get; set; }      
        public StaffController(ILogger<StaffController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> DisplayStaff(string whereClause)
        {
            //TODO - If whereClause is not null or empty, pass to API
            //-------------------------------------------------------

            // call GetAll Api
            var apiUrl = "https://localhost:7173/api/Staff";
            using (HttpClient wclient = new HttpClient())
            {
                wclient.BaseAddress = new Uri(apiUrl);
                wclient.DefaultRequestHeaders.Accept.Clear();
                wclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await wclient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    // Convert return data to list of StaffList
                    var list = JsonSerializer.Deserialize<List<StaffList>>(data);
                    // Present Screen
                    return View(list);
                }
                // 
                return View();
            }
        }
        public string AddStaff()
        {
            return "";
        }
        public string allStaff()
        {
            return "";
        }
        public string OnlyCurrentStaff()
        {
            whereClause = "where is_current = true";
            return whereClause;
        }
        public async Task<ActionResult> OnlyNonCurrentStaff()
        {
            var wc = "where is_current = false";
            return RedirectToAction("DisplayStaff", new { whereClause = wc });


        }
		public async Task<IActionResult> DisplayStaffDetails(int id)
		{
			if (id == 0)
			{
				// nothing to display, should redirect to add
				Staff newStaff = new Staff();
				return View("AddStaff", newStaff);
			}
			else
			{
				string apiUrl = $"https://localhost:7173/api/Staff/" + id.ToString();
				using (HttpClient wclient = new HttpClient())
				{
					HttpResponseMessage response = await wclient.GetAsync(apiUrl);
					if (response.IsSuccessStatusCode)
					{
						var options = new JsonSerializerOptions
						{
							PropertyNameCaseInsensitive = true
						};
						var reader = new StreamReader(response.Content.ReadAsStream());
						var retData = reader.ReadToEndAsync().Result;
						//Should we be receiving a Dto here?
						var staffToUpdate = JsonSerializer.Deserialize<StaffDto>(retData, options);
						// convert StaffDto to Staff
						Staff selectedStaff = new Staff()
						{
							address = staffToUpdate.address,
							address2 = staffToUpdate.address2,
							allrights = staffToUpdate.allrights,
							asignbynam = staffToUpdate.asignbynam,
							belong2_1 = staffToUpdate.belong2_1,
							belong2_2 = staffToUpdate.belong2_2,
							bilprovrid = staffToUpdate.belong2_2,
							birthday = staffToUpdate.birthday,
							city = staffToUpdate.city,
							contac_key = staffToUpdate.contac_key,
							ffirst = staffToUpdate.ffirst,
							group1perm = staffToUpdate.group1perm,
							group2perm = staffToUpdate.group2perm,
							is_current = staffToUpdate.is_current,
							is_sysadmin = staffToUpdate.is_sysadmin,
							lastcli = staffToUpdate.lastcli,
							llast = staffToUpdate.llast,
							location = staffToUpdate.location,
							middle = staffToUpdate.middle,
							moneyhr = staffToUpdate.moneyhr,
							mygroup = staffToUpdate.mygroup,
							my_actions = staffToUpdate.my_actions,
							permissage = staffToUpdate.permissage,
							phone = staffToUpdate.phone,
							positionn = staffToUpdate.positionn,
							revfirst = staffToUpdate.revfirst,
							revlast = staffToUpdate.revlast,
							revshowat = staffToUpdate.revshowat,
							secuassign = staffToUpdate.secuassign,
							secucasefi = staffToUpdate.secucasefi,
							secucaseis = staffToUpdate.secucaseis,
							secucasekey = staffToUpdate.secucasekey,
							secucasela = staffToUpdate.secucasela,
							secucasman = staffToUpdate.secucasman,
							secudaypr2 = staffToUpdate.secudaypr2,
							secudaypro = staffToUpdate.secudaypro,
							seculocat2 = staffToUpdate.seculocat2,
							seculocati = staffToUpdate.seculocati,
							secuobject = staffToUpdate.secuobject,
							security = staffToUpdate.security,
							security1 = staffToUpdate.security1,
							security2 = staffToUpdate.security2,
							secuschedu = staffToUpdate.secuschedu,
							secuservob = staffToUpdate.secuservob,
							secuspeci2 = staffToUpdate.secuspeci2,
							secuspecif = staffToUpdate.secuspecif,
							showobjdelmsg = staffToUpdate.showobjdelmsg,
							signpolicy = staffToUpdate.signpolicy,
							site = staffToUpdate.site,
							sorevhist = staffToUpdate.sorevhist,
							ssn = staffToUpdate.ssn,
							staff_id = staffToUpdate.staff_id,
							staff_key = staffToUpdate.staff_key,
							started = staffToUpdate.started,
							state = staffToUpdate.state,
							supres_bhvnote = staffToUpdate.supres_bhvnote,
							supres_chanobj = staffToUpdate.supres_chanobj,
							tableinfo = staffToUpdate.tableinfo,
							team_key = staffToUpdate.team_key,
							tooltips = staffToUpdate.tooltips,
							user1 = staffToUpdate.user1,
							user2 = staffToUpdate.user2,
							user3 = staffToUpdate.user3,
							username = staffToUpdate.username,
							viewpage1 = staffToUpdate.viewpage1,
							viewpage2 = staffToUpdate.viewpage2,
							viewpage3 = staffToUpdate.viewpage3,
							viewpage4 = staffToUpdate.viewpage4,
							viewpage5 = staffToUpdate.viewpage5,
							viewpage7 = staffToUpdate.viewpage7,
							viewpage8 = staffToUpdate.viewpage8,
							viewvision = staffToUpdate.viewvision,
							zip = staffToUpdate.zip
						};
						return View("DisplayStaffDetails", selectedStaff);

					}
					return View();
				}
			}
		}
		public async Task<IActionResult> EditStaffDetails(int id)
		{
			if (id == 0)
			{
				// nothing to display, should redirect to add
				Staff newStaff = new Staff();
				return View("AddStaff", newStaff);
			}
			else
			{
				string apiUrl = $"https://localhost:7173/api/Staff/" + id.ToString();
				using (HttpClient wclient = new HttpClient())
				{
					HttpResponseMessage response = await wclient.GetAsync(apiUrl);
					if (response.IsSuccessStatusCode)
					{
						var options = new JsonSerializerOptions
						{
							PropertyNameCaseInsensitive = true
						};
						var reader = new StreamReader(response.Content.ReadAsStream());
						var retData = reader.ReadToEndAsync().Result;
						//Should we be receiving a Dto here?
						var staffToUpdate = JsonSerializer.Deserialize<StaffDto>(retData, options);
						// convert StaffDto to Staff
						Staff selectedStaff = new Staff()
						{
							address = staffToUpdate.address,
							address2 = staffToUpdate.address2,
							allrights = staffToUpdate.allrights,
							asignbynam = staffToUpdate.asignbynam,
							belong2_1 = staffToUpdate.belong2_1,
							belong2_2 = staffToUpdate.belong2_2,
							bilprovrid = staffToUpdate.belong2_2,
							birthday = staffToUpdate.birthday,
							city = staffToUpdate.city,
							contac_key = staffToUpdate.contac_key,
							ffirst = staffToUpdate.ffirst,
							group1perm = staffToUpdate.group1perm,
							group2perm = staffToUpdate.group2perm,
							is_current = staffToUpdate.is_current,
							is_sysadmin = staffToUpdate.is_sysadmin,
							lastcli = staffToUpdate.lastcli,
							llast = staffToUpdate.llast,
							location = staffToUpdate.location,
							middle = staffToUpdate.middle,
							moneyhr = staffToUpdate.moneyhr,
							mygroup = staffToUpdate.mygroup,
							my_actions = staffToUpdate.my_actions,
							permissage = staffToUpdate.permissage,
							phone = staffToUpdate.phone,
							positionn = staffToUpdate.positionn,
							revfirst = staffToUpdate.revfirst,
							revlast = staffToUpdate.revlast,
							revshowat = staffToUpdate.revshowat,
							secuassign = staffToUpdate.secuassign,
							secucasefi = staffToUpdate.secucasefi,
							secucaseis = staffToUpdate.secucaseis,
							secucasekey = staffToUpdate.secucasekey,
							secucasela = staffToUpdate.secucasela,
							secucasman = staffToUpdate.secucasman,
							secudaypr2 = staffToUpdate.secudaypr2,
							secudaypro = staffToUpdate.secudaypro,
							seculocat2 = staffToUpdate.seculocat2,
							seculocati = staffToUpdate.seculocati,
							secuobject = staffToUpdate.secuobject,
							security = staffToUpdate.security,
							security1 = staffToUpdate.security1,
							security2 = staffToUpdate.security2,
							secuschedu = staffToUpdate.secuschedu,
							secuservob = staffToUpdate.secuservob,
							secuspeci2 = staffToUpdate.secuspeci2,
							secuspecif = staffToUpdate.secuspecif,
							showobjdelmsg = staffToUpdate.showobjdelmsg,
							signpolicy = staffToUpdate.signpolicy,
							site = staffToUpdate.site,
							sorevhist = staffToUpdate.sorevhist,
							ssn = staffToUpdate.ssn,
							staff_id = staffToUpdate.staff_id,
							staff_key = staffToUpdate.staff_key,
							started = staffToUpdate.started,
							state = staffToUpdate.state,
							supres_bhvnote = staffToUpdate.supres_bhvnote,
							supres_chanobj = staffToUpdate.supres_chanobj,
							tableinfo = staffToUpdate.tableinfo,
							team_key = staffToUpdate.team_key,
							tooltips = staffToUpdate.tooltips,
							user1 = staffToUpdate.user1,
							user2 = staffToUpdate.user2,
							user3 = staffToUpdate.user3,
							username = staffToUpdate.username,
							viewpage1 = staffToUpdate.viewpage1,
							viewpage2 = staffToUpdate.viewpage2,
							viewpage3 = staffToUpdate.viewpage3,
							viewpage4 = staffToUpdate.viewpage4,
							viewpage5 = staffToUpdate.viewpage5,
							viewpage7 = staffToUpdate.viewpage7,
							viewpage8 = staffToUpdate.viewpage8,
							viewvision = staffToUpdate.viewvision,
							zip = staffToUpdate.zip
						};
						return View("EditStaff", selectedStaff);

					}
					return View();
				}
			}
		}

		public async Task<ActionResult> SaveStaffDetails(Staff updatedStaff)
		{
			var url = "https://localhost:7173/api/Staff/"; // + client.client_key.ToString();

			//Client newClient = RemoveNullsFromNewClientObj(client);
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(url);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				// convert Client to Dto
				var updatedStaffDto = new StaffDto()
				{
					address = updatedStaff.address,
					address2 = updatedStaff.address2,
					allrights = updatedStaff.allrights,
					asignbynam = updatedStaff.asignbynam,
					belong2_1 = updatedStaff.belong2_1,
					belong2_2 = updatedStaff.belong2_2,
					bilprovrid = updatedStaff.belong2_2,
					birthday = updatedStaff.birthday,
					city = updatedStaff.city,
					contac_key = updatedStaff.contac_key,
					ffirst = updatedStaff.ffirst,
					group1perm = updatedStaff.group1perm,
					group2perm = updatedStaff.group2perm,
					is_current = updatedStaff.is_current,
					is_sysadmin = updatedStaff.is_sysadmin,
					lastcli = updatedStaff.lastcli,
					llast = updatedStaff.llast,
					location = updatedStaff.location,
					middle = updatedStaff.middle,
					moneyhr = updatedStaff.moneyhr,
					mygroup = updatedStaff.mygroup,
					my_actions = updatedStaff.my_actions,
					permissage = updatedStaff.permissage,
					phone = updatedStaff.phone,
					positionn = updatedStaff.positionn,
					revfirst = updatedStaff.revfirst,
					revlast = updatedStaff.revlast,
					revshowat = updatedStaff.revshowat,
					secuassign = updatedStaff.secuassign,
					secucasefi = updatedStaff.secucasefi,
					secucaseis = updatedStaff.secucaseis,
					secucasekey = updatedStaff.secucasekey,
					secucasela = updatedStaff.secucasela,
					secucasman = updatedStaff.secucasman,
					secudaypr2 = updatedStaff.secudaypr2,
					secudaypro = updatedStaff.secudaypro,
					seculocat2 = updatedStaff.seculocat2,
					seculocati = updatedStaff.seculocati,
					secuobject = updatedStaff.secuobject,
					security = updatedStaff.security,
					security1 = updatedStaff.security1,
					security2 = updatedStaff.security2,
					secuschedu = updatedStaff.secuschedu,
					secuservob = updatedStaff.secuservob,
					secuspeci2 = updatedStaff.secuspeci2,
					secuspecif = updatedStaff.secuspecif,
					showobjdelmsg = updatedStaff.showobjdelmsg,
					signpolicy = updatedStaff.signpolicy,
					site = updatedStaff.site,
					sorevhist = updatedStaff.sorevhist,
					ssn = updatedStaff.ssn,
					staff_id = updatedStaff.staff_id,
					staff_key = updatedStaff.staff_key,
					started = updatedStaff.started,
					state = updatedStaff.state,
					supres_bhvnote = updatedStaff.supres_bhvnote,
					supres_chanobj = updatedStaff.supres_chanobj,
					tableinfo = updatedStaff.tableinfo,
					team_key = updatedStaff.team_key,
					tooltips = updatedStaff.tooltips,
					user1 = updatedStaff.user1,
					user2 = updatedStaff.user2,
					user3 = updatedStaff.user3,
					username = updatedStaff.username,
					viewpage1 = updatedStaff.viewpage1,
					viewpage2 = updatedStaff.viewpage2,
					viewpage3 = updatedStaff.viewpage3,
					viewpage4 = updatedStaff.viewpage4,
					viewpage5 = updatedStaff.viewpage5,
					viewpage7 = updatedStaff.viewpage7,
					viewpage8 = updatedStaff.viewpage8,
					viewvision = updatedStaff.viewvision,
					zip = updatedStaff.zip
				};


				var response = await httpClient.PutAsJsonAsync<StaffDto>(url, updatedStaffDto);
				if (response.IsSuccessStatusCode)
				{
					//no action taken, just providing a breakpoint location
				}
			}

			return RedirectToAction("DisplayStaff");
		}

	}
}
