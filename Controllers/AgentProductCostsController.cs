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
    public class AgentProductCostsController : Controller
    {
        private readonly InquiryDbContext _context;

        public AgentProductCostsController(InquiryDbContext context)
        {
            _context = context;
        }

        // GET: AgentProductCosts
        public async Task<IActionResult> Index(int pg = 1)
        {


            ViewBag.Agent_Id = new SelectList(_context.Agents, "Agent_Name", "Agent_Name");
            ViewBag.Product_Id = new SelectList(_context.Products, "Product_Name", "Product_Name");

            List<AgentProductCost> agentProductCosts = await _context.AgentProductCosts.ToListAsync();

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = agentProductCosts.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = agentProductCosts.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            ViewBag.agentProductCosts = data;

            return View();

            //return View(await _context.AgentProductCosts.ToListAsync());
        }

        // GET: AgentProductCosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentProductCost = await _context.AgentProductCosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agentProductCost == null)
            {
                return NotFound();
            }

            return View(agentProductCost);
        }

        // GET: AgentProductCosts/Create
        public IActionResult Create()
        {
            
            ViewBag.Agent_Id = new SelectList(_context.Agents, "Agent_Name", "Agent_Name");
            ViewBag.Product_Id = new SelectList(_context.Products, "Product_Name", "Product_Name");

           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> populateCost(string Product_Name)
        {
            var coast = "0.00";
            var product = await _context.Products.FirstOrDefaultAsync(k => (k.Product_Name) +"" == Product_Name);
            if (product != null)
            {
                coast = product.Cost.ToString("#,##0.00");
            }
            return Content(coast);
        }

        // POST: AgentProductCosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Agent_Id,Product_Id,Cost")] AgentProductCost agentProductCost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agentProductCost);
                  ModelState.Clear();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agentProductCost);
        }

        // GET: AgentProductCosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentProductCost = await _context.AgentProductCosts.FindAsync(id);
            if (agentProductCost == null)
            {
                return NotFound();
            }
            return View(agentProductCost);
        }

        // POST: AgentProductCosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Agent_Id,Product_Id,Cost")] AgentProductCost agentProductCost)
        {
            if (id != agentProductCost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agentProductCost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentProductCostExists(agentProductCost.Id))
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
            return View(agentProductCost);
        }

        // GET: AgentProductCosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentProductCost = await _context.AgentProductCosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agentProductCost == null)
            {
                return NotFound();
            }

            return View(agentProductCost);
        }

        // POST: AgentProductCosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agentProductCost = await _context.AgentProductCosts.FindAsync(id);
            _context.AgentProductCosts.Remove(agentProductCost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentProductCostExists(int id)
        {
            return _context.AgentProductCosts.Any(e => e.Id == id);
        }
    }
}
