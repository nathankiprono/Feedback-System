using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inquiry__Management__System.InquiryContext;
using Inquiry__Management__System.Models;

namespace Inquiry__Management__System.Controllers
{
    public class Company_InformationController : Controller
    {
        private readonly InquiryDbContext _context;

        public Company_InformationController(InquiryDbContext context)
        {
            _context = context;
        }

        // GET: Company_Information
        public async Task<IActionResult> Index(int pg = 1)
        {

            List<Company_Information> company_Information = await _context.Company_Information.ToListAsync();

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = company_Information.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = company_Information.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            ViewBag.company_Information = data;

            return View();
            //ViewBag.company_info = await _context.Company_Information.ToListAsync();
            // return View();
        }

        // GET: Company_Information/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company_Information = await _context.Company_Information
                .FirstOrDefaultAsync(m => m.Company_Id == id);
            if (company_Information == null)
            {
                return NotFound();
            }

            return View(company_Information);
        }

        // GET: Company_Information/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company_Information/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Company_Id,Company_Name,Conctacts,Address,Location,Description")] Company_Information company_Information)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company_Information);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company_Information);
        }

        // GET: Company_Information/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company_Information = await _context.Company_Information.FindAsync(id);
            if (company_Information == null)
            {
                return NotFound();
            }
            return View(company_Information);
        }

        // POST: Company_Information/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Company_Id,Company_Name,Conctacts,Address,Location,Description")] Company_Information company_Information)
        {
            if (id != company_Information.Company_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company_Information);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Company_InformationExists(company_Information.Company_Id))
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
            return View(company_Information);
        }

        // GET: Company_Information/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company_Information = await _context.Company_Information
                .FirstOrDefaultAsync(m => m.Company_Id == id);
            if (company_Information == null)
            {
                return NotFound();
            }

            return View(company_Information);
        }

        // POST: Company_Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company_Information = await _context.Company_Information.FindAsync(id);
            _context.Company_Information.Remove(company_Information);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Company_InformationExists(int id)
        {
            return _context.Company_Information.Any(e => e.Company_Id == id);
        }
    }
}
