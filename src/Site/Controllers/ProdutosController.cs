using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Interfaces.Repositories;
using App.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.ViewModels;

namespace Site.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.GetAllAsync()));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoRepository.GetByIdAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProdutoViewModel>(produto));
        }

        public IActionResult Create()
        {
            return View(new ProdutoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                produtoViewModel.Id = Guid.NewGuid();
                await _produtoRepository.SaveAsync(_mapper.Map<Produto>(produtoViewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(produtoViewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoRepository.GetByIdAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<ProdutoViewModel>(produto));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _produtoRepository.UpdateAsync(_mapper.Map<Produto>(produtoViewModel));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProdutoViewModelExists(produtoViewModel.Id))
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
            return View(produtoViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var produto = await _produtoRepository.GetByIdAsync(id.Value);
            if (produto == null)
                return NotFound();

            return View(_mapper.Map<ProdutoViewModel>(produto));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto != null)
            {
                await _produtoRepository.DeleteAsync(_mapper.Map<Produto>(produto));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProdutoViewModelExists(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            return produto != null;
        }
    }
}
