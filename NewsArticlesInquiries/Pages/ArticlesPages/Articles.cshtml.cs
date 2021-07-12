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

        public async Task OnGetAsync
            (string searchAu= null, 
            string searchcat = null, 
            string searchcoun = null,
            string searchsou = null
            )
        {
            ViewData[nameof(searchAu)] = searchAu;
            ViewData[nameof(searchcat)] = searchcat;
            ViewData[nameof(searchcoun)] = searchcoun;
            ViewData[nameof(searchsou)] = searchsou;

            if (string.IsNullOrEmpty(searchAu) && string.IsNullOrEmpty(searchcat) && string.IsNullOrEmpty(searchcoun) && string.IsNullOrEmpty(searchsou))
            {
                Article = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.Countries)
                .Include(a => a.Sources).ToListAsync();
            }
            else
            {
                Article = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.Countries)
                .Include(a => a.Sources)
                .Where(
                    a=> 
                    a.Author.Contains(searchAu) || 
                    a.Category.CategoryName.Contains(searchcat) || 
                    a.Countries.ContriesName.Contains(searchcoun) ||
                    a.Sources.SourcesName.Contains(searchsou))

                .ToListAsync();
            }
            
        }
    }
}
