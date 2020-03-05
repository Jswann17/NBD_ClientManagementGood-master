using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBD_ClientManagementGood.Data;
using NBD_ClientManagementGood.Models;

namespace NBD_ClientManagementGood.Controllers
{
    public class DesignBudgetsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public DesignBudgetsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: DesignBudgets
        public async Task<IActionResult> Index()
        {
            return View(await _context.DesignBudget.ToListAsync());
        }

        // GET: DesignBudgets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designBudget = await _context.DesignBudget
                .FirstOrDefaultAsync(m => m.ID == id);
            if (designBudget == null)
            {
                return NotFound();
            }

            return View(designBudget);
        }

        // GET: DesignBudgets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DesignBudgets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CurrentHours,EstHours,HoursTotal,SubmissionDate,Submitter")] DesignBudget designBudget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designBudget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(designBudget);
        }

        // GET: DesignBudgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designBudget = await _context.DesignBudget.FindAsync(id);
            if (designBudget == null)
            {
                return NotFound();
            }
            return View(designBudget);
        }

        // POST: DesignBudgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CurrentHours,EstHours,HoursTotal,SubmissionDate,Submitter")] DesignBudget designBudget)
        {
            if (id != designBudget.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designBudget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignBudgetExists(designBudget.ID))
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
            return View(designBudget);
        }

        // GET: DesignBudgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designBudget = await _context.DesignBudget
                .FirstOrDefaultAsync(m => m.ID == id);
            if (designBudget == null)
            {
                return NotFound();
            }

            return View(designBudget);
        }

        // POST: DesignBudgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designBudget = await _context.DesignBudget.FindAsync(id);
            _context.DesignBudget.Remove(designBudget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignBudgetExists(int id)
        {
            return _context.DesignBudget.Any(e => e.ID == id);
        }
    }
}
