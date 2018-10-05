using LogWeb.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogWeb.Helpers
{
    public class TokenCache : ITokenCache
    {
        private IMemoryCache _cache;
        public TokenCache(IMemoryCache cache)
        {
            _cache = cache;

            _cache.Set("token", "lindolfo");
            _cache.TryGetValue("token", out string value);

        }
    }
}
