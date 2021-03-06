using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Interfaces.Services;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MusicoApiController : ControllerBase
    {
        private readonly IMusicoService _musicoService;

        public MusicoApiController(IMusicoService musicoService)
        {
            _musicoService = musicoService;
        }

        [HttpGet("{orderAscendat:bool}/{search?}")]
        public async Task<ActionResult<IEnumerable<MusicoModel>>> Get(
            bool orderAscendat,
            string search = null) /* ajustar parametros de filtro */
        {
            var musicos = await _musicoService.GetAllAsync(orderAscendat, search);

            return Ok(musicos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MusicoModel>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var musicoModel = await _musicoService.GetByIdAsync(id);

            if (musicoModel == null)
            {
                return NotFound();
            }

            return Ok(musicoModel);
        }

        [HttpPost]
        public async Task<ActionResult<MusicoModel>> Post([FromBody] MusicoModel musicoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(musicoModel);
            }

            var criarMusico = await _musicoService.CreateAsync(musicoModel);

            return Ok(criarMusico);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MusicoModel>> Put(int id, [FromBody] MusicoModel musicoModel)
        {
            if (id != musicoModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(musicoModel);
            }

            try
            {
                var editarMusico = await _musicoService.EditAsync(musicoModel);
                return Ok(editarMusico);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(409);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _musicoService.DeleteAsync(id);

            return Ok();
        }
    }
}
