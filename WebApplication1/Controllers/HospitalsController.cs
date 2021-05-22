using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly ApplicationContext _context;

        public HospitalsController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Hospital.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phone")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital == null) return NotFound();
            return View(hospital);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phone")] Hospital hospital)
        {
            if (id != hospital.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(hospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital == null) return NotFound();
            return View(hospital);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital == null) return NotFound();
            _context.Hospital.Remove(hospital);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
