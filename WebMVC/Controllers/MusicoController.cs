using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    [Authorize]
    public class MusicoController : Controller
    {
        private readonly IMusicoHttpService _musicoHttpService;
        private readonly IBandaHttpService _bandaHttpService;

        public MusicoController(IMusicoHttpService musicoHttpService,
                                IBandaHttpService bandaHttpService)
        {

            _musicoHttpService = musicoHttpService;
            _bandaHttpService = bandaHttpService;
        }

        // GET: Musico
        public async Task<IActionResult> Index(MusicoIndexViewModel musicoIndexRequest)
        {
            var musicoIndexViewModel = new MusicoIndexViewModel
            {
                Search = musicoIndexRequest.Search,
                OrderAscendant = musicoIndexRequest.OrderAscendant,
                Musicos = await _musicoHttpService.GetAllAsync(
                    musicoIndexRequest.OrderAscendant,
                    musicoIndexRequest.Search)
            };

            return View(musicoIndexViewModel);
        }

        // GET: Musico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicoViewModel = await _musicoHttpService.GetByIdAsync(id.Value);

            if (musicoViewModel == null)
            {
                return NotFound();
            }

            return View(musicoViewModel);
        }

        // GET: Musico/Create
        public async Task<IActionResult> Create()
        {
            await PreencherSelectBandas();

            return View();
        }

        // POST: Musico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MusicoViewModel musicoViewModel)
        {
            if (!ModelState.IsValid)
            {
                await PreencherSelectBandas(musicoViewModel.BandaId);

                return View(musicoViewModel);
            }

            var musicoCriado = await _musicoHttpService.CreateAsync(musicoViewModel);

            return RedirectToAction(nameof(Details), new { id = musicoCriado.Id });
        }

        // GET: Musico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicoViewModel = await _musicoHttpService.GetByIdAsync(id.Value);
            if (musicoViewModel == null)
            {
                return NotFound();
            }

            await PreencherSelectBandas(musicoViewModel.BandaId);

            return View(musicoViewModel);
        }

        // POST: Musico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MusicoViewModel musicoViewModel)
        {
            if (id != musicoViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                await PreencherSelectBandas(musicoViewModel.BandaId);

                return View(musicoViewModel);
            }

            try
            {
                await _musicoHttpService.EditAsync(musicoViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await BandaModelExistsAsync(musicoViewModel.Id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Musico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicoViewModel = await _musicoHttpService.GetByIdAsync(id.Value);

            if (musicoViewModel == null)
            {
                return NotFound();
            }

            return View(musicoViewModel);
        }

        // POST: Musico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _musicoHttpService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task PreencherSelectBandas(int? bandaId = null)
        {
            var bandas = await _bandaHttpService.GetAllAsync(true);

            ViewBag.Bandas = new SelectList(bandas,
                nameof(BandaViewModel.Id),
                nameof(BandaViewModel.Nome),
                bandaId);
        }

        private async Task<bool> BandaModelExistsAsync(int id)
        {
            var banda = await _musicoHttpService.GetByIdAsync(id);

            var any = banda != null;

            return any;
        }
    }
}
