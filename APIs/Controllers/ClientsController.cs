using ClientsApi.Data;
using DataModels.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using DataModels.Models.DTOs;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace ClientsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private PpsDBContext _context;  // DB

        public ClientsController(PpsDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            // the LoadTestData routine is a very klugie way of adding test data
            // and should be replaced when a better data store is used.
            //******************************************************************
            //LoadTestData();

            return Ok(_context.Clients.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetClientById(int id)
        {
            Client foundClient = _context.Clients.Find(id);

            if (foundClient == null)
                return NotFound();

            return Ok(foundClient);

        }


        [HttpPost]

        public IActionResult AddClients(ClientDto addClientDto)
        {
            int newClientKey = _context.Clients.Max(c => c.client_key);
            newClientKey += 1;
            var newClient = new Client()
            {
                client_key = newClientKey,
                clientno = addClientDto.clientno,
                fname = addClientDto.fname,
                mname = addClientDto.mname,
                lname = addClientDto.lname,
                aka = addClientDto.aka,
                address = addClientDto.address,
                address2 = addClientDto.address2,
                city = addClientDto.city,
                state = addClientDto.state,
                zip = addClientDto.zip
            };



            _context.Add(newClient);
            _context.SaveChanges();

            // map domain model (newClient) back to DTO
            var clientDto = new ClientDto
            {
                client_key = newClient.client_key,
                clientno = newClient.clientno,
                fname = newClient.fname,
                mname = newClient.mname,
                lname = newClient.lname,
                aka = newClient.aka,
                address = newClient.address,
                address2 = newClient.address2,
                city = newClient.city,
                state = newClient.state,
                zip = newClient.zip
            };

            return CreatedAtAction(nameof(GetClientById), new { id = clientDto.client_key }, clientDto); //Ok(newClient);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateClient()
        {
            //Console.WriteLine("**** Made it into PUT API");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var reader = new StreamReader(Request.Body);
            var postData = reader.ReadToEndAsync().Result;
            var updatedClientDto = JsonSerializer.Deserialize<ClientDto>(postData, options);
            if (updatedClientDto is null)
            {
                Console.WriteLine("     ***  StreamReader(HttpContext.Request.Body) produced null obj");
            }
            // If null object received, exit
            if (updatedClientDto == null || updatedClientDto.client_key <= 0)
                return BadRequest();

            // ToDo:  Check Dto for client_key = 0, then we have an Add/Post

            //Client updatedClient = _context.Clients.Find(updatedClientDto.client_key);
            Client existingClient = _context.Clients.FirstOrDefault(c => c.client_key == updatedClientDto.client_key);

            // if client being updated not found, exit
            if (existingClient == null)
                return NotFound();

            //Move data from Dto to Entity record
            existingClient.client_key = updatedClientDto.client_key;
            existingClient.clientno = updatedClientDto.clientno;
            existingClient.fname = updatedClientDto.fname;
            existingClient.mname = updatedClientDto.mname;
            existingClient.lname = updatedClientDto.lname;
            existingClient.aka = updatedClientDto.aka;
            existingClient.address = updatedClientDto.address;
            existingClient.address2 = updatedClientDto.address2;
            existingClient.city = updatedClientDto.city;
            existingClient.state = updatedClientDto.state;
            existingClient.zip = updatedClientDto.zip;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteClient(int id)
        {
            Client client = _context.Clients.Find(id);

            if (client is null)
            { return NotFound(); }

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return Ok();
        }



        private void LoadTestData()
        {
            // if DB is empty, add mouse and Squirel
            var list = _context.Clients.ToList();
            if (list.Count == 0)
            {

                Client mouse = new Client
                {
                    clientno = "",
                    client_key = 1,
                    fname = "Mickey",
                    mname = "",
                    lname = "Mouse",
                    aka = "",
                    address = "9728 Cortez Dr.",
                    address2 = "",
                    city = "Knoxville",
                    state = "TN",
                    zip = "37923"
                };

                Client duck = new Client
                {
                    clientno = "",
                    client_key = 2,
                    fname = "Donald",
                    mname = "",
                    lname = "Duck",
                    aka = "",
                    address = "9728 Cortez Dr.",
                    address2 = "",
                    city = "Knoxville",
                    state = "TN",
                    zip = "37923"
                };

                _context.Clients.Add(mouse);
                _context.Clients.Add(duck);
                _context.SaveChanges();

            }
        }
    }

}

