using DataModels.Models.Entities;


public interface IClientService
{
    Task<List<Client>> GetClients(); 
    Task<Client> GetClient(int id);
    Task<HttpResponseMessage> AddClient(Client client);
    Task<HttpResponseMessage> UpdateClient(Client client);
    Task<HttpResponseMessage> DeleteClient(int id);
}

