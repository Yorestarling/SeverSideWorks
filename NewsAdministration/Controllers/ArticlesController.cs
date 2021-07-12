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
    public class ArticlesController : Controller
    {
        private readonly NewsServerSideContext _context;

        public ArticlesController(NewsServerSideContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index(string search = null)
        {
            ViewData[nameof(search)] = search;

            if (string.IsNullOrEmpty(search))
            {
                var newsServerSideContext = _context.Articles.Include(a => a.Category).Include(a => a.Countries).Include(a => a.Sources);
                return View(await newsServerSideContext.ToListAsync());
            }
            else
            {
                var newsServerSideContext = _context.Articles
                    .Include(a => a.Category)
                    .Include(a => a.Countries)
                    .Include(a => a.Sources)
                    .Where(a => a.Author.Contains(search) || a.Sources.SourcesName.Contains(search));
                return View(await newsServerSideContext.ToListAsync());
            }

        }


        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.Countries)
                .Include(a => a.Sources)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["CountriesId"] = new SelectList(_context.Countries, "CountriesId", "ContriesName");
            ViewData["SourcesId"] = new SelectList(_context.Sources, "SourcesId", "SourcesName");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleId,Author,Title,Descriptions,Ulr,UlrToImage,PublishedAt,Content,SourcesId,CategoryId,CountriesId")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", article.CategoryId);
            ViewData["CountriesId"] = new SelectList(_context.Countries, "CountriesId", "ContriesName", article.CountriesId);
            ViewData["SourcesId"] = new SelectList(_context.Sources, "SourcesId", "SourcesName", article.SourcesId);
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", article.CategoryId);
            ViewData["CountriesId"] = new SelectList(_context.Countries, "CountriesId", "ContriesName", article.CountriesId);
            ViewData["SourcesId"] = new SelectList(_context.Sources, "SourcesId", "SourcesName", article.SourcesId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleId,Author,Title,Descriptions,Ulr,UlrToImage,PublishedAt,Content,SourcesId,CategoryId,CountriesId")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", article.CategoryId);
            ViewData["CountriesId"] = new SelectList(_context.Countries, "CountriesId", "ContriesName", article.CountriesId);
            ViewData["SourcesId"] = new SelectList(_context.Sources, "SourcesId", "SourcesName", article.SourcesId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.Countries)
                .Include(a => a.Sources)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
