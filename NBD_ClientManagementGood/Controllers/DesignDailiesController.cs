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
    public class DesignDailiesController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public DesignDailiesController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: DesignDailies
        public async Task<IActionResult> Index()
        {
            return View(await _context.DesignDaily.ToListAsync());
        }

        // GET: DesignDailies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designDaily = await _context.DesignDaily
                .FirstOrDefaultAsync(m => m.ID == id);
            if (designDaily == null)
            {
                return NotFound();
            }

            return View(designDaily);
        }

        // GET: DesignDailies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DesignDailies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Stage,Hours,Task,Submitter,SubmissionDate")] DesignDaily designDaily)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designDaily);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(designDaily);
        }

        // GET: DesignDailies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designDaily = await _context.DesignDaily.FindAsync(id);
            if (designDaily == null)
            {
                return NotFound();
            }
            return View(designDaily);
        }

        // POST: DesignDailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Stage,Hours,Task,Submitter,SubmissionDate")] DesignDaily designDaily)
        {
            if (id != designDaily.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designDaily);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignDailyExists(designDaily.ID))
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
            return View(designDaily);
        }

        // GET: DesignDailies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designDaily = await _context.DesignDaily
                .FirstOrDefaultAsync(m => m.ID == id);
            if (designDaily == null)
            {
                return NotFound();
            }

            return View(designDaily);
        }

        // POST: DesignDailies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designDaily = await _context.DesignDaily.FindAsync(id);
            _context.DesignDaily.Remove(designDaily);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignDailyExists(int id)
        {
            return _context.DesignDaily.Any(e => e.ID == id);
        }
    }
}
