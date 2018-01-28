using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching;
using Microsoft.Extensions.Caching.Memory;
using ReadFromCache.Model;

namespace ReadFromCache.api
{
    [Produces("application/json")]
    [Route("api/Storage")]
    public class StorageController : Controller
    {
        IMemoryCache _cache;
        public StorageController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        [HttpPost]
        //[Route("api/Storage/PutInStore")]
        public IActionResult PutInStore([FromBody]MessageModel messageModel)
        {
            try
            {
                var cacheEntry = _cache.GetOrCreate<string>("msgDump", entry =>
                {
                    return (entry.Value as string);
                });
                StringBuilder messageDump = new StringBuilder();
                if (!string.IsNullOrEmpty(cacheEntry))
                    messageDump.AppendLine(cacheEntry);
                messageDump.AppendLine(messageModel.Message);
                _cache.Set<string>("msgDump", messageDump.ToString());
                return new ContentResult()
                {
                    Content = "Stored in cache successfully " ,
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }
            catch(Exception ex)
            {
                return new ContentResult()
                {
                    Content = "Failed to store in cache " + ex.Message,
                    ContentType="application/json",
                    StatusCode = 500
                };
            }
        }
    }
}