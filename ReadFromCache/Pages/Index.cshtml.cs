using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
namespace ReadFromCache.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; private set; }
        private IMemoryCache _cache;
        public IndexModel(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public void OnGet()
        {
            string cacheEntry = _cache.Get<string>("msgDump");
            if (!string.IsNullOrWhiteSpace(cacheEntry))
            {
                Message = cacheEntry;
            }
        }
    }
}
