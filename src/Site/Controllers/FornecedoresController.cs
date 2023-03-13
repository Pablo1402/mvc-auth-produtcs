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

    public class FornecedoresController : BaseControlller
    {
        private readonly IFornecedorRepositoy _fornecedorRepositoy;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepositoy fornecedorRepositoy, IMapper mapper)
        {
            _fornecedorRepositoy = fornecedorRepositoy;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<List<FornecedorViewModel>>(await _fornecedorRepositoy.GetAllAsync()));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorRepositoy.GetByIdAsync(id.Value);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<FornecedorViewModel>(fornecedor));
        }

        public IActionResult Create()
        {
            return View(new FornecedorViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                fornecedorViewModel.Id = Guid.NewGuid();
                await _fornecedorRepositoy.SaveAsync(_mapper.Map<Fornecedor>( fornecedorViewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorViewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorRepositoy.GetByIdAsync(id.Value);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<FornecedorViewModel>(fornecedor));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _fornecedorRepositoy.UpdateAsync(_mapper.Map<Fornecedor>(fornecedorViewModel));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FornecedorViewModelExists(fornecedorViewModel.Id))
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
            return View(fornecedorViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var fornecedor = await _fornecedorRepositoy.GetByIdAsync(id.Value);
            if (fornecedor == null)
                return NotFound();

            return View(_mapper.Map<FornecedorViewModel>(fornecedor));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedorViewModel = await _fornecedorRepositoy.GetByIdAsync(id);
            if (fornecedorViewModel != null)
            {
               await _fornecedorRepositoy.DeleteAsync(_mapper.Map<Fornecedor>(fornecedorViewModel));
            }
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FornecedorViewModelExists(Guid id)
        {
            var fornecedor =  await _fornecedorRepositoy.GetByIdAsync(id);
            return fornecedor != null;
        }
    }
}
