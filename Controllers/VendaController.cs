using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMercado.Models;

namespace ProjetoMercado.Controllers
{
    public class VendaController : Controller
    {
        private readonly Contexto _context;

        public VendaController(Contexto context)
        {
            _context = context;
        }

        // GET: Venda
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Venda.Include(v => v.Cliente).Include(v => v.Pagamento).Include(v => v.vendedor);
            return View(await contexto.ToListAsync());
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Pagamento)
                .Include(v => v.vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);

            venda.ProdutosList = await _context.VendaHasProduto
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .Where(v => v.VendaId == id).ToListAsync();

            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente");
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "PagamentoId", "FormaDePagamento");
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "NomeVendedor");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaId,ValorTotal,DataVenda,ClienteId,VendedorId,PagamentoId")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", venda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "PagamentoId", "FormaDePagamento", venda.PagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "NomeVendedor", venda.VendedorId);
            return View(venda);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", venda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "PagamentoId", "FormaDePagamento", venda.PagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "NomeVendedor", venda.VendedorId);
            return View(venda);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaId,ValorTotal,DataVenda,ClienteId,VendedorId,PagamentoId")] Venda venda)
        {
            if (id != venda.VendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.VendaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", venda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "PagamentoId", "FormaDePagamento", venda.PagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "NomeVendedor", venda.VendedorId);
            return View(venda);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Pagamento)
                .Include(v => v.vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venda == null)
            {
                return Problem("Entity set 'Contexto.Venda'  is null.");
            }
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
          return (_context.Venda?.Any(e => e.VendaId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> ImpressaoMercado(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Pagamento)
                .Include(v => v.vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);

            venda.ProdutosList = await _context.VendaHasProduto
                //busca os dados da outra tabela (INNERJOIN)
                .Include(x => x.Produto)
                //seleciona apenas os produtos daquela venda
                .Where(x => x.VendaId == id)
                //agrupa os produtos iguais
                .GroupBy(x => new { x.ProdutoId })
                //seleciona os dados do agrupamento
                .Select(vp => vp.OrderByDescending(x => x.ProdutoId).First())
                //converte tudo isso para lista
                .ToListAsync();

            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }
    }
}
