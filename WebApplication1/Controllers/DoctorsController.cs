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
    public class DoctorsController : Controller
    {
        private readonly ApplicationContext _context;

        public DoctorsController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Speciallity")] Doctors doc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doc);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var doc = await _context.Doctors.FindAsync(id);
            if (doc == null) return NotFound();
            return View(doc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Speciallity")] Doctors doc)
        {
            if (id != doc.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doc);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var doc = await _context.Doctors.FindAsync(id);
            if (doc == null) return NotFound();
            return View(doc);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var doc = await _context.Doctors.FindAsync(id);
            if (doc == null) return NotFound();
            _context.Doctors.Remove(doc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
