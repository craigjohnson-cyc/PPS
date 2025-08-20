using DataModels.Models.Entities;
public interface IClientDetailService
{
    Task<Client> GetClientDetails(int id);
    Task<HttpResponseMessage> AddClientDetails(ClientDetail clientDetails);
    Task<HttpResponseMessage> UpdateClientDetails(ClientDetail clientDetails);
    Task<HttpResponseMessage> DeleteClientDetails(int id);
}
