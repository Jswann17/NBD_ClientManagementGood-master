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
    public class LabourDepartmentsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public LabourDepartmentsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: LabourDepartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.LabourDepartments.ToListAsync());
        }

        // GET: LabourDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourDepartment = await _context.LabourDepartments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labourDepartment == null)
            {
                return NotFound();
            }

            return View(labourDepartment);
        }

        // GET: LabourDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabourDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DepartmentDescription,DepartmentTotalHours,LabourUnitID")] LabourDepartment labourDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labourDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labourDepartment);
        }

        // GET: LabourDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourDepartment = await _context.LabourDepartments.FindAsync(id);
            if (labourDepartment == null)
            {
                return NotFound();
            }
            return View(labourDepartment);
        }

        // POST: LabourDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DepartmentDescription,DepartmentTotalHours,LabourUnitID")] LabourDepartment labourDepartment)
        {
            if (id != labourDepartment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labourDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabourDepartmentExists(labourDepartment.ID))
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
            return View(labourDepartment);
        }

        // GET: LabourDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourDepartment = await _context.LabourDepartments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labourDepartment == null)
            {
                return NotFound();
            }

            return View(labourDepartment);
        }

        // POST: LabourDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labourDepartment = await _context.LabourDepartments.FindAsync(id);
            _context.LabourDepartments.Remove(labourDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabourDepartmentExists(int id)
        {
            return _context.LabourDepartments.Any(e => e.ID == id);
        }
    }
}
