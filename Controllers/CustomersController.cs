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
    public class CustomersController : Controller
    {
        private readonly InquiryDbContext _context;

        public CustomersController(InquiryDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public static List<Customers> customersList = new List<Customers>();
        public async Task<IActionResult> Index(int pg = 1)
        {
            customersList.Clear();
            ViewBag.Agent_Id = new SelectList(_context.Agents, "Agent_Name", "Agent_Name");
            ViewBag.data = new string[] { "All", "Male", "Female" };
            List<Customers> customers = await _context.Customers.ToListAsync();

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = customers.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = customers.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            ViewBag.customers = data;

            return View();

           // ViewBag.customers= await _context.Customers.ToListAsync();
            //ViewBag.TempList = customersList.ToList();

           // return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> SubmitFinalRecords()
        {
            foreach(var item in customersList)
            {
                Guid guid = Guid.NewGuid();
                var newrecordkinyasi = new Customers
                {
                    Agent_Id = item.Agent_Id,
                    Customer_Id = guid.ToString(),
                    DOB = item.DOB,
                    FullName = item.FullName,
                    Gender = item.Gender,
                    Height = item.Height,
                    Location = item.Location,
                    Nationality = item.Nationality,
                    National_Id = item.National_Id,
                    Notes = item.Notes,
                    Passport_No = item.Passport_No,
                    RegistrationDate = item.RegistrationDate,
                    Weight = item.Weight

                };
                _context.Add(newrecordkinyasi);
              
                await _context.SaveChangesAsync();
            }
            customersList.Clear();
            TempData["Success"] = "Records Inserted successfully";
           
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
      
        public async Task<IActionResult> PopulateList(string Customer_Id, string Agent_Id, string FullName, string Height, string Gender, string Passport_No, string National_Id, string Nationality, string DOB, string Notes, string Weight, string RegistrationDate, string Location)
        {

           
            var newrecord = new Customers
            {
                Agent_Id = Agent_Id,
                Customer_Id =Customer_Id,
                DOB = DOB,
                FullName = FullName,
                Gender = Gender,
                Height = Height,
                Location = Location,
                Nationality = Nationality,
                National_Id = National_Id,
                Notes = Notes,
                Passport_No = Passport_No,
                RegistrationDate = RegistrationDate,
                Weight = Weight
            };
           customersList.Add(newrecord);

            return Json(customersList);
           
        }
     
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .FirstOrDefaultAsync(m => m.Customer_Id == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewBag.Agent_Id = new SelectList(_context.Agents, "Agent_Name", "Agent_Name");

            ViewBag.data = new string[] { "Male", "Female" };
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Customer_Id,Agent_Id,FullName,Height,Gender,Passport_No,National_Id,Nationality,DOB,Notes,Weight,RegistrationDate,Location")] Customers customers)
        {
            ViewBag.Agent_Id = new SelectList(_context.Agents, "Agent_Name", "Agent_Name");
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Customer_Id,Agent_Id,FullName,Height,Gender,Passport_No,National_Id,Nationality,DOB,Notes,Weight,RegistrationDate,Location")] Customers customers)
        {
            if (id != customers.Customer_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (CustomersExists(customers.Customer_Id + ""))
                    {
                        throw;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .FirstOrDefaultAsync(m => m.Customer_Id == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(string id)
        {
            return _context.Customers.Any(e => e.Customer_Id == id);
        }
    }
}
