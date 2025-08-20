using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DataModels.Models;
using DataModels.Models.Entities;
using DataModels.Models.DTOs;
using System.Collections.Generic;
using System.Net;

namespace PPS_MVC.Controllers
{
    public class ClientListController : Controller
    {
        private readonly ILogger<ClientListController> _logger;

        public ClientListController(ILogger<ClientListController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> ListClients()
        {
            // call GetAll Api
            var apiUrl = "https://localhost:7173/api/Clients";
            using (HttpClient wclient = new HttpClient())
            {
                wclient.BaseAddress = new Uri(apiUrl);
                wclient.DefaultRequestHeaders.Accept.Clear();
                wclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await wclient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    // Convert return data to list of Client
                    var list = JsonSerializer.Deserialize<List<Client>>(data);
                    // Present Screen
                    return View(list);
                }
                // 
                return View();
            }
        }

        public async Task<ActionResult> DeleteClient(int id)
        {
            if (id != 0)
            {
                string apiUrl = $"https://localhost:7173/api/Clients/" + id.ToString();
                using (HttpClient wclient = new HttpClient())
                {
                    var response = await wclient.DeleteAsync(apiUrl);


                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ListClients");
                    }
                }
            }
            return RedirectToAction("ListClients");
        }
        public async Task<ActionResult> EditClient(int id)
        {
            if (id != 0)
            {
                string apiUrl = $"https://localhost:7173/api/Clients/" + id.ToString();
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
                        var clientToUpdate = JsonSerializer.Deserialize<Client>(retData, options);

                        return View("EditClient", clientToUpdate);


                    }
                }
            }
            else
            {
                // if client_key = 0, this is an add
                Client newClient = new Client();
                return View("EditClient",newClient);
            }

            return RedirectToAction("ListClients");

        }

        public async Task<ActionResult> UpdateClient(Client client)
        {
            var url = "https://localhost:7173/api/Clients/"; // + client.client_key.ToString();

            Client newClient = RemoveNullsFromNewClientObj(client);
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // convert Client to Dto
                var updatedClientDto = new ClientDto()
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


                var response = await httpClient.PostAsJsonAsync<ClientDto>(url, updatedClientDto);
                if (response.IsSuccessStatusCode)
                {
                    //no action taken, just providing a breakpoint location
                }
            }

            return RedirectToAction("ListClients");
        }

        private Client RemoveNullsFromNewClientObj(Client newClient)
        {
            newClient.clientno ??= "";
            newClient.fname ??= "";
            newClient.mname ??= "";
            newClient.aka ??= "";
            newClient.address ??= "";
            newClient.address2 ??= "";
            newClient.city ??= "";
            newClient.state ??= "";
            newClient.zip ??= "";

            return newClient;
        }

    }
}
