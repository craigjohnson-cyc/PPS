using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using DataModels.Models.DTOs;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.Extensions.Options;
using System.Text.Json;
using ClientsApi.Data;
using DataModels.Models.Entities;

namespace PpsApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private PpsDBContext _context;  // DB

        public StaffController(PpsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStaff()
        {
            var staffMembers = _context.Staff.Select(x => new
            {
                staff_key = x.staff_key,
                ffirst = x.ffirst,
                llast = x.llast,
                positionn = x.positionn,
                is_current = x.is_current
            });
            return Ok(staffMembers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStaffById(int id)
        {
            Staff foundStaff = _context.Staff.Find(id);

            if (foundStaff == null)
                return NotFound();

            StaffDto staffDto = new StaffDto()
            {
                address = foundStaff.address,
                address2 = foundStaff.address2,
                allrights = foundStaff.allrights,
                asignbynam = foundStaff.asignbynam,
                belong2_1 = foundStaff.belong2_1,
                belong2_2 = foundStaff.belong2_2,
                bilprovrid = foundStaff.belong2_2,
                birthday = foundStaff.birthday,
                city = foundStaff.city,
                contac_key = foundStaff.contac_key,
                //cryptopublickey = foundStaff.cryptopublickey,
                ffirst = foundStaff.ffirst,
                group1perm = foundStaff.group1perm,
                group2perm = foundStaff.group2perm,
                is_current = foundStaff.is_current,
                is_sysadmin = foundStaff.is_sysadmin,
                lastcli = foundStaff.lastcli,
                llast = foundStaff.llast,
                location = foundStaff.location,
                middle = foundStaff.middle,
                moneyhr = foundStaff.moneyhr,
                mygroup = foundStaff.mygroup,
                my_actions = foundStaff.my_actions,
                permissage = foundStaff.permissage,
                phone = foundStaff.phone,
                positionn = foundStaff.positionn,
                revfirst = foundStaff.revfirst,
                revlast = foundStaff.revlast,
                revshowat = foundStaff.revshowat,
                secuassign = foundStaff.secuassign,
                secucasefi = foundStaff.secucasefi,
                secucaseis = foundStaff.secucaseis,
                secucasekey = foundStaff.secucasekey,
                secucasela = foundStaff.secucasela,
                secucasman = foundStaff.secucasman,
                secudaypr2 = foundStaff.secudaypr2,
                secudaypro = foundStaff.secudaypro,
                seculocat2 = foundStaff.seculocat2,
                seculocati = foundStaff.seculocati,
                secuobject = foundStaff.secuobject,
                security = foundStaff.security,
                security1 = foundStaff.security1,
                security2 = foundStaff.security2,
                secuschedu = foundStaff.secuschedu,
                secuservob = foundStaff.secuservob,
                secuspeci2 = foundStaff.secuspeci2,
                secuspecif = foundStaff.secuspecif,
                showobjdelmsg = foundStaff.showobjdelmsg,
                signpolicy = foundStaff.signpolicy,
                site = foundStaff.site,
                sorevhist = foundStaff.sorevhist,
                ssn = foundStaff.ssn,
                staff_id = foundStaff.staff_id,
                staff_key = foundStaff.staff_key,
                started = foundStaff.started,
                state = foundStaff.state,
                supres_bhvnote = foundStaff.supres_bhvnote,
                supres_chanobj = foundStaff.supres_chanobj,
                tableinfo = foundStaff.tableinfo,
                team_key = foundStaff.team_key,
                tooltips = foundStaff.tooltips,
                user1 = foundStaff.user1,
                user2 = foundStaff.user2,
                user3 = foundStaff.user3,
                username = foundStaff.username,
                viewpage1 = foundStaff.viewpage1,
                viewpage2 = foundStaff.viewpage2,
                viewpage3 = foundStaff.viewpage3,
                viewpage4 = foundStaff.viewpage4,
                viewpage5 = foundStaff.viewpage5,
                viewpage7 = foundStaff.viewpage7,
                viewpage8 = foundStaff.viewpage8,   
                viewvision = foundStaff.viewvision,
                zip = foundStaff.zip
            };
            
            return Ok(staffDto);

        }

        [HttpPost]
        public IActionResult AddStaff(StaffDto addStaffDto)
        {
            var newStaff = new Staff()
            {
                address = addStaffDto.address,
                address2 = addStaffDto.address2,
                allrights = addStaffDto.allrights,
                asignbynam = addStaffDto.asignbynam,
                belong2_1 = addStaffDto.belong2_1,
                belong2_2 = addStaffDto.belong2_2,
                bilprovrid = addStaffDto.belong2_2,
                birthday = addStaffDto.birthday,
                city = addStaffDto.city,
                contac_key = addStaffDto.contac_key,
                //cryptopublickey = addStaffDto.cryptopublickey,
                ffirst = addStaffDto.ffirst,
                group1perm = addStaffDto.group1perm,
                group2perm = addStaffDto.group2perm,
                is_current = addStaffDto.is_current,
                is_sysadmin = addStaffDto.is_sysadmin,
                lastcli = addStaffDto.lastcli,
                llast = addStaffDto.llast,
                location = addStaffDto.location,
                middle = addStaffDto.middle,
                moneyhr = addStaffDto.moneyhr,
                mygroup = addStaffDto.mygroup,
                my_actions = addStaffDto.my_actions,
                permissage = addStaffDto.permissage,
                phone = addStaffDto.phone,
                positionn = addStaffDto.positionn,
                revfirst = addStaffDto.revfirst,
                revlast = addStaffDto.revlast,
                revshowat = addStaffDto.revshowat,
                secuassign = addStaffDto.secuassign,
                secucasefi = addStaffDto.secucasefi,
                secucaseis = addStaffDto.secucaseis,
                secucasekey = addStaffDto.secucasekey,
                secucasela = addStaffDto.secucasela,
                secucasman = addStaffDto.secucasman,
                secudaypr2 = addStaffDto.secudaypr2,
                secudaypro = addStaffDto.secudaypro,
                seculocat2 = addStaffDto.seculocat2,
                seculocati = addStaffDto.seculocati,
                secuobject = addStaffDto.secuobject,
                security = addStaffDto.security,
                security1 = addStaffDto.security1,
                security2 = addStaffDto.security2,
                secuschedu = addStaffDto.secuschedu,
                secuservob = addStaffDto.secuservob,
                secuspeci2 = addStaffDto.secuspeci2,
                secuspecif = addStaffDto.secuspecif,
                showobjdelmsg = addStaffDto.showobjdelmsg,
                signpolicy = addStaffDto.signpolicy,
                site = addStaffDto.site,
                sorevhist = addStaffDto.sorevhist,
                ssn = addStaffDto.ssn,
                staff_id = addStaffDto.staff_id,
                staff_key = addStaffDto.staff_key,
                started = addStaffDto.started,
                state = addStaffDto.state,
                supres_bhvnote = addStaffDto.supres_bhvnote,
                supres_chanobj = addStaffDto.supres_chanobj,
                tableinfo = addStaffDto.tableinfo,
                team_key = addStaffDto.team_key,
                tooltips = addStaffDto.tooltips,
                user1 = addStaffDto.user1,
                user2 = addStaffDto.user2,
                user3 = addStaffDto.user3,
                username = addStaffDto.username,
                viewpage1 = addStaffDto.viewpage1,
                viewpage2 = addStaffDto.viewpage2,
                viewpage3 = addStaffDto.viewpage3,
                viewpage4 = addStaffDto.viewpage4,
                viewpage5 = addStaffDto.viewpage5,
                viewpage7 = addStaffDto.viewpage7,
                viewpage8 = addStaffDto.viewpage8,
                viewvision = addStaffDto.viewvision,
                zip = addStaffDto.zip
            };

            _context.Add(newStaff);
            _context.SaveChanges();

            // map domain model (newClient) back to DTO
            //    Relly???  why not just update the key and return the orig DTO?
            addStaffDto.staff_key = newStaff.staff_key;

            return CreatedAtAction(nameof(GetStaffById), new { id = addStaffDto.staff_key }, addStaffDto); //Ok(newClient);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateStaff()
        {
            //Console.WriteLine("**** Made it into PUT API");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var reader = new StreamReader(Request.Body);
            var postData = reader.ReadToEndAsync().Result;
            var updatedStaffDto = JsonSerializer.Deserialize<StaffDto>(postData, options);
            if (updatedStaffDto is null)
            {
                Console.WriteLine("     ***  StreamReader(HttpContext.Request.Body) produced null obj");
            }
            // If null object received, exit
            if (updatedStaffDto == null || updatedStaffDto.staff_key <= 0)
                return BadRequest();

            // ToDo:  Check Dto for Staff_key = 0, then we have an Add/Post

            //Client updatedClient = _context.Clients.Find(updatedClientDto.client_key);
            Staff existingStaff = _context.Staff.FirstOrDefault(s => s.staff_key == updatedStaffDto.staff_key);

            // if client being updated not found, exit
            if (existingStaff == null)
                return NotFound();

            //Move data from Dto to Entity record
            existingStaff.address = updatedStaffDto.address ?? string.Empty;
            existingStaff.address2 = updatedStaffDto.address2 ?? string.Empty;
            existingStaff.allrights = updatedStaffDto.allrights ? false : updatedStaffDto.allrights;
            existingStaff.asignbynam = updatedStaffDto.asignbynam ? false : updatedStaffDto.asignbynam;
            existingStaff.belong2_1 = updatedStaffDto.belong2_1 ?? string.Empty;
            existingStaff.belong2_2 = updatedStaffDto.belong2_2 ?? string.Empty;
            existingStaff.bilprovrid = updatedStaffDto.bilprovrid ?? string.Empty;
            existingStaff.birthday = updatedStaffDto.birthday;
            existingStaff.city = updatedStaffDto.city ?? string.Empty;
            existingStaff.contac_key = updatedStaffDto.contac_key;
            //existingStaff.cryptopublickey = updatedStaffDto.cryptopublickey;
            existingStaff.ffirst = updatedStaffDto.ffirst ?? string.Empty;
            existingStaff.group1perm = updatedStaffDto.group1perm ?? string.Empty;
            existingStaff.group2perm = updatedStaffDto.group2perm ?? string.Empty;
            existingStaff.is_current = updatedStaffDto.is_current ? false : updatedStaffDto.is_current;
            existingStaff.is_sysadmin = updatedStaffDto.is_sysadmin ? false : updatedStaffDto.is_sysadmin;
            existingStaff.lastcli = updatedStaffDto.lastcli;
            existingStaff.llast = updatedStaffDto.llast ?? string.Empty;
            existingStaff.location = updatedStaffDto.location ?? string.Empty;
            existingStaff.middle = updatedStaffDto.middle ?? string.Empty;
            existingStaff.moneyhr = updatedStaffDto.moneyhr;
            existingStaff.mygroup = updatedStaffDto.mygroup;
            existingStaff.my_actions = updatedStaffDto.my_actions ?? string.Empty;
            existingStaff.phone = updatedStaffDto.phone ?? string.Empty;
            existingStaff.positionn = updatedStaffDto.positionn ?? string.Empty;
            existingStaff.revfirst = updatedStaffDto.revfirst ?? string.Empty;
            existingStaff.revlast = updatedStaffDto.revlast ?? string.Empty;
            existingStaff.revshowat = updatedStaffDto.revshowat ?? string.Empty;
            existingStaff.secuassign = updatedStaffDto.secuassign ? false : updatedStaffDto.secuassign;
            existingStaff.secucasefi = updatedStaffDto.secucasefi ?? string.Empty;
            existingStaff.secucaseis = updatedStaffDto.secucaseis ? false : updatedStaffDto.secucaseis;
            existingStaff.secucasekey = updatedStaffDto.secucasekey;
            existingStaff.secucasela = updatedStaffDto.secucasela ?? string.Empty;
            existingStaff.secucasman = updatedStaffDto.secucasman ? false : updatedStaffDto.secucasman;
            existingStaff.secudaypr2 = updatedStaffDto.secudaypr2 ?? string.Empty;
            existingStaff.secudaypro = updatedStaffDto.secudaypro ? false : updatedStaffDto.secudaypro;
            existingStaff.seculocat2 = updatedStaffDto.seculocat2 ?? string.Empty;
            existingStaff.seculocati = updatedStaffDto.seculocati ? false : updatedStaffDto.seculocati;
            existingStaff.secuobject = updatedStaffDto.secuobject ? false : updatedStaffDto.secuobject;
            existingStaff.security = updatedStaffDto.security;
            existingStaff.security1 = updatedStaffDto.security1 ?? string.Empty;
            existingStaff.security2 = updatedStaffDto.security2 ?? string.Empty;
            existingStaff.secuschedu = updatedStaffDto.secuschedu ? false : updatedStaffDto.secuschedu;
            existingStaff.secuservob = updatedStaffDto.secuservob ? false : updatedStaffDto.secuservob;
            existingStaff.secuspeci2 = updatedStaffDto.secuspeci2 ?? string.Empty;
            existingStaff.secuspecif = updatedStaffDto.secuspecif ? false : updatedStaffDto.secuspecif;
            existingStaff.showobjdelmsg = updatedStaffDto.showobjdelmsg ? false : updatedStaffDto.showobjdelmsg;
            existingStaff.signpolicy = updatedStaffDto.signpolicy ? false : updatedStaffDto.signpolicy;
            existingStaff.site = updatedStaffDto.site ?? string.Empty;
            existingStaff.sorevhist = updatedStaffDto.sorevhist ? false : updatedStaffDto.sorevhist;
            existingStaff.ssn = updatedStaffDto.ssn ?? string.Empty;
            existingStaff.staff_id = updatedStaffDto.staff_id;
            existingStaff.started = updatedStaffDto.started;
            existingStaff.state = updatedStaffDto.state ?? string.Empty;
            existingStaff.supres_bhvnote = updatedStaffDto.supres_bhvnote ? false : updatedStaffDto.supres_bhvnote;
            existingStaff.supres_chanobj = updatedStaffDto.supres_chanobj ? false : updatedStaffDto.supres_chanobj;
            existingStaff.tableinfo = updatedStaffDto.tableinfo ?? string.Empty;
            existingStaff.team_key = updatedStaffDto.team_key;
            existingStaff.tooltips = updatedStaffDto.tooltips ? false : updatedStaffDto.tooltips;
            existingStaff.user1 = updatedStaffDto.user1 ?? string.Empty;
            existingStaff.user2 = updatedStaffDto.user2 ?? string.Empty;
            existingStaff.user3 = updatedStaffDto.user3 ?? string.Empty;
            existingStaff.username = updatedStaffDto.username ?? string.Empty;
            existingStaff.viewpage1 = updatedStaffDto.viewpage1 ? false : updatedStaffDto.viewpage1;
            existingStaff.viewpage2 = updatedStaffDto.viewpage2 ? false : updatedStaffDto.viewpage2;
            existingStaff.viewpage3 = updatedStaffDto.viewpage3 ? false : updatedStaffDto.viewpage3;
            existingStaff.viewpage4 = updatedStaffDto.viewpage4 ? false : updatedStaffDto.viewpage4;
            existingStaff.viewpage5 = updatedStaffDto.viewpage5 ? false : updatedStaffDto.viewpage5;
            existingStaff.viewpage7 = updatedStaffDto.viewpage7 ? false : updatedStaffDto.viewpage7;
            existingStaff.viewpage8 = updatedStaffDto.viewpage8 ? false : updatedStaffDto.viewpage8;
            existingStaff.viewvision = updatedStaffDto.viewvision ? false : updatedStaffDto.viewvision; 
            existingStaff.zip = updatedStaffDto.zip ?? string.Empty;


            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteStaff(int id)
        {
            Staff staff = _context.Staff.Find(id);

            if (staff is null)
            { return NotFound(); }

            _context.Staff.Remove(staff);
            _context.SaveChanges();

            return Ok();
        }



    }
}
