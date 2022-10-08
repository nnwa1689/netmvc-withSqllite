using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreTest.Data;
using NetCoreTest.Models;

namespace NetCoreTest.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly NetCoreTest.Data.Context _context;

        public IndexModel(NetCoreTest.Data.Context context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var articles = from a in _context.Article select a;
            if (!string.IsNullOrEmpty(SearchString))
            {
                articles = articles.Where(s => s.Title.Contains(SearchString));
            }
            if (_context.Article != null)
            {
                Article = await articles.ToListAsync();
            }
        }
    }
}
