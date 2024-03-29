﻿using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection collection)
        {
            collection.AddMemoryCache(); // works like: collection.AddSingleton<IMemoryCache, "some memory cache instance">();
            collection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            collection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}