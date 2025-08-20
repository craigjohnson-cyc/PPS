
using DataModels.Models.Entities;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Components;

public partial class ClientService() : IClientService
{
    //[Inject]
    private readonly HttpClient _httpClient;

    public ClientService(HttpClient httpClient) : this()
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> AddClient(Client client)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Client>("Clients", client);
        return response;
    }
    public async Task<HttpResponseMessage> UpdateClient(Client client)
    {
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Client>("Clients", client);
        return response;
    }
    public async Task<HttpResponseMessage> DeleteClient(int id)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync("Clients/" + id.ToString().Trim());
        return response;
    }

    public async Task<Client> GetClient(int id)
    {
        if(id >= 0)
        {
            Client client = await _httpClient.GetFromJsonAsync<Client>("Clients/" + id.ToString().Trim());

            if (client == null)
            {
                throw new Exception("Failed to load client");
            }
            else
            {
                return client;
            }

        }
        else
        {
            throw new Exception("Invalid client id");
        }
    }

    public async Task<List<Client>> GetClients()
    {
        //List<Client> clientList = new List<Client>();
        List<Client> clientList = await _httpClient.GetFromJsonAsync<List<Client>>("Clients");

        if (clientList == null)
        {
            throw new Exception("Failed to load clients");
        }
        else
        {
            return clientList;
        }       
    }


}
