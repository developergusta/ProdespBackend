using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prodesp.Domain.Models;
using Prodesp.Service.Interface;
using System;
using System.Threading.Tasks;

namespace Prodesp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImunobiologicoController : ControllerBase
    {
        private readonly IImunobiologicoService _imunobiologicoService;
        public ImunobiologicoController(IImunobiologicoService imunobiologicoService)
        {
            _imunobiologicoService = imunobiologicoService;
        }
        // GET: api/<ImunobiologicoController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _imunobiologicoService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ImunobiologicoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var imunobiologico = await _imunobiologicoService.Get(id);
                if(imunobiologico == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(imunobiologico);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ImunobiologicoController>
        [HttpPost]
        public async Task<IActionResult> Post(Imunobiologico imunobiologico)
        {
            try
            {
                var imunobiologicoInserido = await _imunobiologicoService.Add(imunobiologico);
                return StatusCode(StatusCodes.Status201Created, imunobiologicoInserido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ImunobiologicoController>/id
        [HttpPut("")]
        public async Task<IActionResult> Put(Imunobiologico imunobiologico)
        {
            try
            {
                await _imunobiologicoService.Update(imunobiologico);
                return Ok(imunobiologico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ImunobiologicoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _imunobiologicoService.Delete(id);
                return StatusCode(StatusCodes.Status200OK, "Imunobiológico excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
