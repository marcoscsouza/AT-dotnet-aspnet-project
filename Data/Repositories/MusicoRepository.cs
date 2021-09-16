using Microsoft.EntityFrameworkCore;
using Model.Interfaces.Repositories;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MusicoRepository : IMusicoRepository
    {
        private readonly BandaATContext _bandaATContext;

        public MusicoRepository(BandaATContext bandaATContext)
        {
            _bandaATContext = bandaATContext;
        }

        public async Task<IEnumerable<MusicoModel>> GetAllAsync(bool orderAscendat, string search = null)
        {
            var musicos = orderAscendat
               ? _bandaATContext.Musicos.OrderBy(x => x.Nome)
               : _bandaATContext.Musicos.OrderByDescending(x => x.Nome);

            if (string.IsNullOrWhiteSpace(search))
            {
                return await _bandaATContext.Musicos
                    .Include(x => x.Banda)
                    .ToListAsync();
            }

            return await musicos
                .Include(x => x.Banda)
                .Where(x => x.Nome.Contains(search))
                .ToListAsync();

        }

        public async Task<MusicoModel> GetByIdAsync(int id)
        {
            var musico = await _bandaATContext
                .Musicos
                .Include(x => x.Banda)
                .FirstOrDefaultAsync(x => x.Id == id);

            return musico;
        }

        public async Task<MusicoModel> CreateAsync(MusicoModel musicoModel)
        {
            var musico = _bandaATContext.Musicos.Add(musicoModel);

            await _bandaATContext.SaveChangesAsync();

            return musico.Entity;
        }

        public async Task<MusicoModel> EditAsync(MusicoModel musicoModel)
        {
            var musico = _bandaATContext.Musicos.Update(musicoModel);

            await _bandaATContext.SaveChangesAsync();

            return musico.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var musico = await GetByIdAsync(id);

            _bandaATContext.Musicos.Remove(musico);

            await _bandaATContext.SaveChangesAsync();
        }
    }
}
