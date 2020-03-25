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
    public class LabourReportsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public LabourReportsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: LabourReports
        public async Task<IActionResult> Index()
        {
            return View(await _context.LabourReport.ToListAsync());
        }

        // GET: LabourReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourReport = await _context.LabourReport
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labourReport == null)
            {
                return NotFound();
            }

            return View(labourReport);
        }

        // GET: LabourReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabourReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Department,Hours,Cost,Submitter,SubmissionDate")] LabourReport labourReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labourReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labourReport);
        }

        // GET: LabourReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourReport = await _context.LabourReport.FindAsync(id);
            if (labourReport == null)
            {
                return NotFound();
            }
            return View(labourReport);
        }

        // POST: LabourReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Department,Hours,Cost,Submitter,SubmissionDate")] LabourReport labourReport)
        {
            if (id != labourReport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labourReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabourReportExists(labourReport.ID))
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
            return View(labourReport);
        }

        // GET: LabourReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourReport = await _context.LabourReport
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labourReport == null)
            {
                return NotFound();
            }

            return View(labourReport);
        }

        // POST: LabourReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labourReport = await _context.LabourReport.FindAsync(id);
            _context.LabourReport.Remove(labourReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabourReportExists(int id)
        {
            return _context.LabourReport.Any(e => e.ID == id);
        }
    }
}
