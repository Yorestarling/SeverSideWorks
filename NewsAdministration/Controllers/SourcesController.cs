using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsAdministration;

namespace NewsAdministration.Controllers
{
    public class SourcesController : Controller
    {
        private readonly NewsServerSideContext _context;

        public SourcesController(NewsServerSideContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search = null)
        {
            ViewData[nameof(search)] = search;

            if (string.IsNullOrEmpty(search))
            {
                return View(await _context.Sources.ToListAsync());
            }
            else
            {
                return View(await _context.Sources
                    .Where(a=> a.SourcesName.Contains(search)).
                    ToListAsync());
            }
            
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var source = await _context.Sources
                .FirstOrDefaultAsync(m => m.SourcesId == id);
            if (source == null)
            {
                return NotFound();
            }

            return View(source);
        }

  
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SourcesId,SourcesName")] Source source)
        {
            if (ModelState.IsValid)
            {
                _context.Add(source);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(source);
        }

 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var source = await _context.Sources.FindAsync(id);
            if (source == null)
            {
                return NotFound();
            }
            return View(source);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SourcesId,SourcesName")] Source source)
        {
            if (id != source.SourcesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(source);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SourceExists(source.SourcesId))
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
            return View(source);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var source = await _context.Sources
                .FirstOrDefaultAsync(m => m.SourcesId == id);
            if (source == null)
            {
                return NotFound();
            }

            return View(source);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var source = await _context.Sources.FindAsync(id);
            _context.Sources.Remove(source);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SourceExists(int id)
        {
            return _context.Sources.Any(e => e.SourcesId == id);
        }
    }
}
