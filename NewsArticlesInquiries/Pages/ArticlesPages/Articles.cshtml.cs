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

        public async Task OnGetAsync()
        {
            Article = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.Countries)
                .Include(a => a.Sources)
                .OrderBy(a=> a.PublishedAt).
                ToListAsync();
        }
    }
}
