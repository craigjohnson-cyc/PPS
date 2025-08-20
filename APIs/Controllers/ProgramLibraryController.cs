using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using DataModels.Models.DTOs;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.Extensions.Options;
using System.Text.Json;
using ClientsApi.Data;
using DataModels.Models.Entities;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.AccessControl;
using System;

namespace PpsApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramLibraryController : ControllerBase
    {

        private PpsDBContext _context;  // DB

        public ProgramLibraryController(PpsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllLibraryPrograms()
        {
            return Ok(_context.proglib.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetLibraryProgramById(int id)
        {
            ProgramLibrary foundProgram = _context.proglib.Find(id);

            if (foundProgram == null)
                return NotFound();

            ProgramLibraryDto libraryProgramDto = new ProgramLibraryDto()
            {
                chaintype = foundProgram.chaintype,
                condition = foundProgram.condition,
                criteria = foundProgram.criteria,
                criterilas = foundProgram.criterilas,
                criterimon = foundProgram.criterimon,
                criteriper = foundProgram.criteriper,
                data = foundProgram.data,
                domainn = foundProgram.domainn,
                env_factor = foundProgram.env_factor,
                evalmethod = foundProgram.evalmethod,
                eval_lastn = foundProgram.eval_lastn,
                increase = foundProgram.increase,
                indepyesno = foundProgram.indepyesno,
                keywords = foundProgram.keywords,
                program_key = foundProgram.program_key,
                perflevel = foundProgram.perflevel,
                perflevelcount = foundProgram.perflevelcount,
                progdesc = foundProgram.progdesc,
                progmeasur = foundProgram.progmeasur,
                progsteps = foundProgram.progsteps,
                progstepscount = foundProgram.progstepscount,
                objective = foundProgram.objective,
                strategy = foundProgram.strategy,
                strategy2 = foundProgram.strategy2,
                strategy3 = foundProgram.strategy3,
                strategy4 = foundProgram.strategy4,
                strategy5 = foundProgram.strategy5,
                strategy6 = foundProgram.strategy6,
                taskanal = foundProgram.taskanal,
                taskanalcount = foundProgram.taskanalcount,
                timestamp_column = foundProgram.timestamp_column,
                totaltask = foundProgram.totaltask

            };

            return Ok(libraryProgramDto);

        }

        [HttpPost]
        public IActionResult AddLibraryProgram(ProgramLibraryDto addLibraryProgramDto)
        {
            var newLibraryProgram = new ProgramLibrary()
            {
                chaintype = addLibraryProgramDto.chaintype,
                condition = addLibraryProgramDto.condition,
                criteria = addLibraryProgramDto.criteria,
                criterilas = addLibraryProgramDto.criterilas,
                criterimon = addLibraryProgramDto.criterimon,
                criteriper = addLibraryProgramDto.criteriper,
                data = addLibraryProgramDto.data,
                domainn = addLibraryProgramDto.domainn,
                env_factor = addLibraryProgramDto.env_factor,
                evalmethod = addLibraryProgramDto.evalmethod,
                eval_lastn = addLibraryProgramDto.eval_lastn,
                increase = addLibraryProgramDto.increase,
                indepyesno = addLibraryProgramDto.indepyesno,
                keywords = addLibraryProgramDto.keywords,
                program_key = addLibraryProgramDto.program_key,
                perflevel = addLibraryProgramDto.perflevel,
                perflevelcount = addLibraryProgramDto.perflevelcount,
                progdesc = addLibraryProgramDto.progdesc,
                progmeasur = addLibraryProgramDto.progmeasur,
                progsteps = addLibraryProgramDto.progsteps,
                progstepscount = addLibraryProgramDto.progstepscount,
                objective = addLibraryProgramDto.objective,
                strategy = addLibraryProgramDto.strategy,
                strategy2 = addLibraryProgramDto.strategy2,
                strategy3 = addLibraryProgramDto.strategy3,
                strategy4 = addLibraryProgramDto.strategy4,
                strategy5 = addLibraryProgramDto.strategy5,
                strategy6 = addLibraryProgramDto.strategy6,
                taskanal = addLibraryProgramDto.taskanal,
                taskanalcount = addLibraryProgramDto.taskanalcount,
                timestamp_column = addLibraryProgramDto.timestamp_column,
                totaltask = addLibraryProgramDto.totaltask
            };

            _context.Add(newLibraryProgram);
            _context.SaveChanges();

            // map domain model (newClient) back to DTO
            //    Relly???  why not just update the key and return the orig DTO?
            addLibraryProgramDto.program_key = newLibraryProgram.program_key;

            return CreatedAtAction(nameof(GetLibraryProgramById), new { id = addLibraryProgramDto.program_key }, addLibraryProgramDto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateLibraryProgram()
        {
            //Console.WriteLine("**** Made it into PUT API");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var reader = new StreamReader(Request.Body);
            var postData = reader.ReadToEndAsync().Result;
            var updatedProgramLibraryDto = JsonSerializer.Deserialize<ProgramLibraryDto>(postData, options);
            if (updatedProgramLibraryDto is null)
            {
                Console.WriteLine("     ***  StreamReader(HttpContext.Request.Body) produced null obj");
            }
            // If null object received, exit
            if (updatedProgramLibraryDto == null || updatedProgramLibraryDto.program_key <= 0)
                return BadRequest();

            // ToDo:  Check Dto for Staff_key = 0, then we have an Add/Post

            //Client updatedClient = _context.Clients.Find(updatedClientDto.client_key);
            ProgramLibrary existingProgram = _context.proglib.FirstOrDefault(p => p.program_key == updatedProgramLibraryDto.program_key);

            // if client being updated not found, exit
            if (existingProgram == null)
                return NotFound();

            //Move data from Dto to Entity record
            existingProgram.chaintype = updatedProgramLibraryDto.chaintype;
            existingProgram.condition = updatedProgramLibraryDto.condition;
            existingProgram.criteria = updatedProgramLibraryDto.criteria;
            existingProgram.criterilas = updatedProgramLibraryDto.criterilas;
            existingProgram.criterimon = updatedProgramLibraryDto.criterimon;
            existingProgram.criteriper = updatedProgramLibraryDto.criteriper;
            existingProgram.data = updatedProgramLibraryDto.data;
            existingProgram.domainn = updatedProgramLibraryDto.domainn;
            existingProgram.env_factor = updatedProgramLibraryDto.env_factor;
            existingProgram.evalmethod = updatedProgramLibraryDto.evalmethod;
            existingProgram.eval_lastn = updatedProgramLibraryDto.eval_lastn;
            existingProgram.increase = updatedProgramLibraryDto.increase;
            existingProgram.indepyesno = updatedProgramLibraryDto.indepyesno;
            existingProgram.keywords = updatedProgramLibraryDto.keywords;
            existingProgram.program_key = updatedProgramLibraryDto.program_key;
            existingProgram.perflevel = updatedProgramLibraryDto.perflevel;
            existingProgram.perflevelcount = updatedProgramLibraryDto.perflevelcount;
            existingProgram.progdesc = updatedProgramLibraryDto.progdesc;
            existingProgram.progmeasur = updatedProgramLibraryDto.progmeasur;
            existingProgram.progsteps = updatedProgramLibraryDto.progsteps;
            existingProgram.progstepscount = updatedProgramLibraryDto.progstepscount;
            existingProgram.objective = updatedProgramLibraryDto.objective;
            existingProgram.strategy = updatedProgramLibraryDto.strategy;
            existingProgram.strategy2 = updatedProgramLibraryDto.strategy2;
            existingProgram.strategy3 = updatedProgramLibraryDto.strategy3;
            existingProgram.strategy4 = updatedProgramLibraryDto.strategy4;
            existingProgram.strategy5 = updatedProgramLibraryDto.strategy5;
            existingProgram.strategy6 = updatedProgramLibraryDto.strategy6;
            existingProgram.taskanal = updatedProgramLibraryDto.taskanal;
            existingProgram.taskanalcount = updatedProgramLibraryDto.taskanalcount;
            existingProgram.timestamp_column = updatedProgramLibraryDto.timestamp_column;
            existingProgram.totaltask = updatedProgramLibraryDto.totaltask;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteLibraryProgram(int id)
        {
            ProgramLibrary programLibraryRec = _context.proglib.Find(id);

            if (programLibraryRec is null)
            { return NotFound(); }

            _context.proglib.Remove(programLibraryRec);
            _context.SaveChanges();

            return Ok();
        }





    }
}
