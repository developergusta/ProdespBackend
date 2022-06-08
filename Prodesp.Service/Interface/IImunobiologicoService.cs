using Prodesp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Service.Interface
{
    public interface IImunobiologicoService
    {
        Task<Imunobiologico?> Add(Imunobiologico imunobiologico);
        Task Update(Imunobiologico imunobiologico);
        Task Delete(Guid id);
        Task<Imunobiologico?> Get(Guid id);
        Task<IEnumerable<Imunobiologico?>> GetAll();
    }
}
