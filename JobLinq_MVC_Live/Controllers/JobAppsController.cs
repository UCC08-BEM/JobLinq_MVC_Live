using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobLinq_MVC_Live.Models;

namespace JobLinq_MVC_Live.Controllers
{
    public class JobAppsController : Controller
    {
        private readonly DBJobLinqContext _context;

        public JobAppsController(DBJobLinqContext context)
        {
            _context = context;
        }

        // GET: JobApps
        public async Task<IActionResult> Index()
        {
              return _context.JobApps != null ? 
                          View(await _context.JobApps.ToListAsync()) :
                          Problem("Entity set 'DBJobLinqContext.JobApps'  is null.");
        }

        // GET: JobApps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobApps == null)
            {
                return NotFound();
            }

            var jobApp = await _context.JobApps
                .FirstOrDefaultAsync(m => m.JobAppId == id);
            if (jobApp == null)
            {
                return NotFound();
            }

            return View(jobApp);
        }

        // GET: JobApps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobApps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobAppId,UserId,AdvertId")] JobApp jobApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobApp);
        }

        // GET: JobApps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobApps == null)
            {
                return NotFound();
            }

            var jobApp = await _context.JobApps.FindAsync(id);
            if (jobApp == null)
            {
                return NotFound();
            }
            return View(jobApp);
        }

        // POST: JobApps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobAppId,UserId,AdvertId")] JobApp jobApp)
        {
            if (id != jobApp.JobAppId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobAppExists(jobApp.JobAppId))
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
            return View(jobApp);
        }

        // GET: JobApps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobApps == null)
            {
                return NotFound();
            }

            var jobApp = await _context.JobApps
                .FirstOrDefaultAsync(m => m.JobAppId == id);
            if (jobApp == null)
            {
                return NotFound();
            }

            return View(jobApp);
        }

        // POST: JobApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobApps == null)
            {
                return Problem("Entity set 'DBJobLinqContext.JobApps'  is null.");
            }
            var jobApp = await _context.JobApps.FindAsync(id);
            if (jobApp != null)
            {
                _context.JobApps.Remove(jobApp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobAppExists(int id)
        {
          return (_context.JobApps?.Any(e => e.JobAppId == id)).GetValueOrDefault();
        }
    }
}
