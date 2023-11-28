using Locadora.Data;
using Locadora.Interfaces;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Locadora.Controllers
{
    public class FilmeController : Controller
    {
        private readonly ILocadoraContext _context;

        public FilmeController(ILocadoraContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmes.OrderBy(i => i.Nome).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome, Genero, Preco, Quantidade, Sobre")] Filme filme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddFilmeAsync(filme);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("Erro de cadastro", "Não foi possível cadastrar a instituição.");
            }

            return View(filme);
        }

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.GetFilmeByIdAsync(id.Value);

            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("FilmeID", "Nome", "Genero", "Preco", "Quantidade", "Sobre")] Filme filme)
        {
            if (id != filme.FilmeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateFilmeAsync(filme);
                }
                catch (DbUpdateException)
                {
                    if (!FilmeExists(filme.FilmeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        private bool FilmeExists(long? filmeID)
        {
            // Implemente conforme necessário
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.GetFilmeByIdAsync(id.Value);

            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.GetFilmeByIdAsync(id.Value);

            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long? id)
        {
            var filme = await _context.GetFilmeByIdAsync(id.Value);

            await _context.DeleteFilmeAsync(id.Value);

            return RedirectToAction("Index");
        }
    }
}