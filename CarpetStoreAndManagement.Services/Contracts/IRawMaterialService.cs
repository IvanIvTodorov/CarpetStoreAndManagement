using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IRawMaterialService
    {

        Task AddProductAsync(AddRawMaterialViewModel model, string type);
        Task AddColorAsync(string name);


    }
}
