using Microsoft.EntityFrameworkCore;
using Prodesp.Domain.Models;
using Prodesp.Repository.Data;
using Prodesp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Repository.Implementation
{
    public class ImunobiologicoRepository : IImunobiologicoRepository
    {
        private readonly ProdespContext _prodespContext;

        public ImunobiologicoRepository(ProdespContext prodespContext)
        {
            _prodespContext = prodespContext;
        }

        public async Task Add(Imunobiologico imunobiologico)
        {
            await _prodespContext.Imunobiologicos.AddAsync(imunobiologico);
            await Commit();
        }

        public async Task Commit()
        {
            await _prodespContext.SaveChangesAsync();
        }

        public async Task Delete(Imunobiologico imunobiologico)
        {
            _prodespContext.Imunobiologicos.Remove(imunobiologico);
            await Commit();
        }

        public async Task<Imunobiologico?> Get(Guid id)
        {
            return await _prodespContext.Imunobiologicos.FindAsync(id);
        }

        public async Task<IEnumerable<Imunobiologico>> GetAll()
        {
            return await _prodespContext.Imunobiologicos.ToListAsync();
        }

        public async Task Update(Imunobiologico imunobiologico)
        {
            var objectToUpdate = await Get(imunobiologico.Id);
            if (objectToUpdate != null)
            {
                objectToUpdate.Fabricante = imunobiologico.Fabricante;
                objectToUpdate.AnoLote = imunobiologico.AnoLote;
                objectToUpdate.Nome = imunobiologico.Nome;
                _prodespContext.Imunobiologicos.Update(objectToUpdate);
                await Commit();
            }

        }
    }
}
