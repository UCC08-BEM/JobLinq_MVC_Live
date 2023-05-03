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
    public class CandidatesController : Controller
    {
        private readonly DBJobLinqContext _context;

        public CandidatesController(DBJobLinqContext context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            // ?? : Databeseden gelen CityID ye göre ekrandaki tablo içeriğinde CityID olarak görülen yere CityName değerinin gelmesi


            return _context.Candidates != null ? 
                          View(await _context.Candidates.ToListAsync()) :
                          Problem("Entity set 'DBJobLinqContext.Candidates'  is null.");
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            // Database tarafında bulunan City tablosundaki verilerin çekilmesi

            List<SelectListItem> citylist=(from cl in _context.Cities.ToList()
                                           select new SelectListItem
                                           {
                                               Value=cl.CityId.ToString(),
                                               Text=cl.CityName
                                           }
                                           ).OrderBy(i=> i.Text).ToList();

            ViewBag.citylist= citylist;



            // Manuel olarak view sayfasında gözükmesini istediğim City listesi oluşturuluyor.
            //ViewBag.citylist = new SelectList(new List<CityList>()
            //                    {  new() { Data=1,Value="İstanbul" },
            //                       new() { Data=2,Value="Ankara"},
            //                       new() { Data=3,Value="İzmir"},
            //                       new() { Data=4,Value="Bursa"}
            //                    }, "Data", "Value");

            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidateId,UserId,Fname,Lname,BirthDate,CityId,Gsmno")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                //candidate.BirthDate = candidate.BirthDate.ToShortDateTime();
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidateId,UserId,Fname,Lname,BirthDate,CityId,Gsmno")] Candidate candidate)
        {
            if (id != candidate.CandidateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.CandidateId))
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
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidates == null)
            {
                return Problem("Entity set 'DBJobLinqContext.Candidates'  is null.");
            }
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
          return (_context.Candidates?.Any(e => e.CandidateId == id)).GetValueOrDefault();
        }
    }
}
