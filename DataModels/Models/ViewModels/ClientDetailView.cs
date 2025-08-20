using DataModels.Models.Entities;
using DataModels.Models.PickList;
using DataModels.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.ViewModels
{
    public class ClientDetailView
    {
        public required Client client { get; set; }

        public required ClientDetail clientDetail { get; set; }
        public required List<ResponsiblePerson> responsiblePersons {  get; set; } 

        public required List<piklist> pickListValues { get; set; }

    }
}
