using Prodesp.Domain.Models;
using Prodesp.Repository.Interface;
using Prodesp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Service.Implementation
{
    public class ImunobiologicoService : IImunobiologicoService
    {
        private readonly IImunobiologicoRepository _imunobiologicoRepository;
        public ImunobiologicoService(IImunobiologicoRepository imunobiologicoRepository)
        {
            _imunobiologicoRepository = imunobiologicoRepository;
        }
        public async Task<Imunobiologico?> Add(Imunobiologico imunobiologico)
        {
            imunobiologico.DataCadastro = DateTime.UtcNow;
            imunobiologico.Id = Guid.NewGuid();
            await _imunobiologicoRepository.Add(imunobiologico);
            return imunobiologico;
        }

        public async Task Delete(Guid id)
        {
            var imunobiologico = await _imunobiologicoRepository.Get(id);
            if (imunobiologico != null)
            {
                await _imunobiologicoRepository.Delete(imunobiologico);
            }
        }

        public async Task<Imunobiologico?> Get(Guid id)
        {
            return await _imunobiologicoRepository.Get(id);
        }

        public async Task<IEnumerable<Imunobiologico?>> GetAll()
        {
            return await _imunobiologicoRepository.GetAll();
        }

        public async Task Update(Imunobiologico imunobiologico)
        {
            await _imunobiologicoRepository.Update(imunobiologico);
        }
    }
}
