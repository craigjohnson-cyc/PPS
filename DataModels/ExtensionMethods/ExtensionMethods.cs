using DataModels.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

// Define an interface named IMyInterface.
namespace DefineIMyInterface
{
    public interface IMyInterface
    {
        // Any class that implements IMyInterface must define a method
        // that matches the following signature.
        void DeepCopy();
    }
}

namespace DataModels.ExtensionMethods
{
    using DefineIMyInterface;
    using System;
    public static class MyExtensions
    {

        public static ClientDetail DeepCopy<ClientDetail>(this ClientDetail self)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }
            else
            {
                string serialized = JsonSerializer.Serialize(self);
                return JsonSerializer.Deserialize<ClientDetail>(serialized);
            }
        }
    }


}
