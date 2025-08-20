using Microsoft.EntityFrameworkCore;
using ClientsApi.Data;
using DataModels.Models.Entities;
using DataModels.Models;
using DataModels.Models.PickList;

namespace ClientsApi.Data
{

    public class PpsDBContext : DbContext
    {
        public DbSet<AgencyInfo> SysInfo { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientDetail> ClientDetails { get; set; }
        public DbSet<piklist> piklist { get; set; }
        public DbSet<ProgramLibrary> proglib { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public PpsDBContext(DbContextOptions<PpsDBContext> options)
            :base(options)
        {
            
        }
    }
}
