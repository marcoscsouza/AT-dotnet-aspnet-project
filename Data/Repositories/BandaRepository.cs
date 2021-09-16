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
    public class BandaRepository : IBandaRepository
    {
        private readonly BandaATContext _BandaATContext;

        public BandaRepository(BandaATContext BandaATContext)
        {
            _BandaATContext = BandaATContext;
        }

        public async Task<IEnumerable<BandaModel>> GetAllAsync(bool orderAscendat, string search = null)
        {
            var bandas = orderAscendat
                ? _BandaATContext.Bandas.OrderBy(x => x.Nome)
                : _BandaATContext.Bandas.OrderByDescending(x => x.Nome);

            if (string.IsNullOrWhiteSpace(search))
            {
                return await _BandaATContext.Bandas.ToListAsync();
            }

            return await bandas
                .Where(x => x.Nome.Contains(search))
                .ToListAsync();
        }

        public async Task<BandaModel> GetByIdAsync(int id)
        {
            var banda = await _BandaATContext
                .Bandas
                .Include(x => x.Musicos)
                .FirstOrDefaultAsync(x => x.Id == id);

            return banda;
        }

        public async Task<BandaModel> CreateAsync(BandaModel bandaModel)
        {
            var banda = _BandaATContext.Bandas.Add(bandaModel);

            await _BandaATContext.SaveChangesAsync();

            return banda.Entity;
        }

        public async Task<BandaModel> EditAsync(BandaModel bandaModel)
        {
            var banda = _BandaATContext.Bandas.Update(bandaModel);

            await _BandaATContext.SaveChangesAsync();

            return banda.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var banda = await GetByIdAsync(id);

            _BandaATContext.Bandas.Remove(banda);

            await _BandaATContext.SaveChangesAsync();
        }

        

        public async Task<BandaModel> GetNomeNotFromThisIdAsync(string nome, int id)
        {
            var bandaModel = await _BandaATContext
                .Bandas
                .FirstOrDefaultAsync(x => x.Nome == nome && x.Id != id);

            return bandaModel;
        }
    }
}
