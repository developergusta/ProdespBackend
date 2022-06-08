using Prodesp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Repository.Interface
{
    public interface IImunobiologicoRepository
    {
        Task Add(Imunobiologico imunobiologico);
        Task Update(Imunobiologico imunobiologico);
        Task Delete(Imunobiologico imunobiologico);
        Task<Imunobiologico?> Get(Guid id);
        Task<IEnumerable<Imunobiologico>> GetAll();
        Task Commit();
    }
}
