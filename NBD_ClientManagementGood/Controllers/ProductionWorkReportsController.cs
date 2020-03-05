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
    public class ProductionWorkReportsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public ProductionWorkReportsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: ProductionWorkReports
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductionWorkReport.ToListAsync());
        }

        // GET: ProductionWorkReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionWorkReport = await _context.ProductionWorkReport
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionWorkReport == null)
            {
                return NotFound();
            }

            return View(productionWorkReport);
        }

        // GET: ProductionWorkReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductionWorkReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Submitter,SubmissionDate")] ProductionWorkReport productionWorkReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionWorkReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productionWorkReport);
        }

        // GET: ProductionWorkReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionWorkReport = await _context.ProductionWorkReport.FindAsync(id);
            if (productionWorkReport == null)
            {
                return NotFound();
            }
            return View(productionWorkReport);
        }

        // POST: ProductionWorkReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Submitter,SubmissionDate")] ProductionWorkReport productionWorkReport)
        {
            if (id != productionWorkReport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionWorkReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionWorkReportExists(productionWorkReport.ID))
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
            return View(productionWorkReport);
        }

        // GET: ProductionWorkReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionWorkReport = await _context.ProductionWorkReport
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionWorkReport == null)
            {
                return NotFound();
            }

            return View(productionWorkReport);
        }

        // POST: ProductionWorkReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionWorkReport = await _context.ProductionWorkReport.FindAsync(id);
            _context.ProductionWorkReport.Remove(productionWorkReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionWorkReportExists(int id)
        {
            return _context.ProductionWorkReport.Any(e => e.ID == id);
        }
    }
}
