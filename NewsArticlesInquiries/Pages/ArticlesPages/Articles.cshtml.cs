using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewsArticlesInquiries;

namespace NewsArticlesInquiries.Pages.ArticlesPages
{
    public class ArticlesModel : PageModel
    {
        private readonly NewsArticlesInquiries.NewsServerSideContext _context;

        public ArticlesModel(NewsArticlesInquiries.NewsServerSideContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync(
            string search = null,
            string searchcat = null,
            string searchcou = null,
            string searchsou = null
            )
        {
            ViewData[nameof(search)] = search;
            ViewData[nameof(searchcat)] = searchcat;
            ViewData[nameof(searchcou)] = searchcou;
            ViewData[nameof(searchsou)] = searchsou;

            if (string.IsNullOrEmpty(search) 
                && string.IsNullOrEmpty(searchcat) 
                && string.IsNullOrEmpty(searchcou) 
                && string.IsNullOrEmpty(searchsou))
            {
                Article = await _context.Articles
                               .Include(a => a.Category)
                               .Include(a => a.Countries)
                               .Include(a => a.Sources)
                               .OrderBy(a => a.PublishedAt).
                               ToListAsync();
            }
            else
            {
                Article = await _context.Articles
               .Include(a => a.Category)
               .Include(a => a.Countries)
               .Include(a => a.Sources)
               .Where(a=> 
               a.Author.Contains(search) || 
               a.Category.CategoryName.Contains(searchcat) || 
               a.Sources.SourcesName.Contains(searchsou) ||
               a.Countries.ContriesName.Contains(searchcou)).
               ToListAsync();
            }       
        }
    }
}
