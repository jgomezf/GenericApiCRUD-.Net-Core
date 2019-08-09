using BLL.Interface;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace BLL.Utility
{
    public class CacheManager<T> : ICacheManager<T>
    {
        private static bool EnableCache = Convert.ToBoolean(ConfigurationManager.AppSettings["CacheEnable"]);
        private static int TimeHourDefault = 1;
        private static IMemoryCache _cache;

        public CacheManager(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        /// <summary>
        /// Obtiene una valor de cache si está habilitado el cache
        /// </summary>
        /// <param name="cacheKey">Llave del valor en cache</param>
        /// <returns></returns>
        public static T TryGetFromCache(string cacheKey)
        {
            T cacheValue = default(T);

            // Look for cache key.
            if (EnableCache && _cache.TryGetValue(cacheKey, out cacheValue))
            {
                return cacheValue;
            }

            return cacheValue;
        }

        public static void RemoveItemFromCache(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        /// <summary>
        /// Agrega un valor al cache si está habilitado
        /// </summary>
        /// <param name="cacheKey">Llave del valor en cache</param>
        /// <param name="cacheValue">Valor a agregar a cache</param>
        /// <param name="hours">Tiempo de permanencia en cache en horas</param>
        /// <param name="minutes">Tiempo de permanencia en cache en minutes</param>
        /// <param name="seconds">Tiempo de permanencia en cache en segundos</param>
        public static void TryAddToCache(string cacheKey, T cacheValue, int hours, int minutes, int seconds)
        {
            var cacheOut = cacheValue;

            if (EnableCache && cacheValue != null)
            {
                if (_cache.TryGetValue(cacheKey, out cacheOut))
                {
                    _cache.Remove(cacheKey);
                }
                TimeSpan timeSpan = new TimeSpan(hours, minutes, seconds);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(timeSpan);

                // Save data in cache.
                _cache.Set(cacheKey, cacheValue, cacheEntryOptions);
            }
        }

        /// <summary>
        /// Agrega un valor al cache si está habilitado
        /// </summary>
        /// <param name="cacheKey">Llave del valor en cache</param>
        /// <param name="cacheValue">Valor a agregar a cache</param>
        /// <param name="hours">Tiempo de permanencia en cache en horas</param>
        /// <param name="minutes">Tiempo de permanencia en cache en minutes</param>
        public static void TryAddToCache(string cacheKey, T cacheValue, int hours, int minutes)
        {
            TryAddToCache(cacheKey, cacheValue, hours, minutes, 0);
        }

        /// <summary>
        /// Agrega un valor al cache si está habilitado
        /// </summary>
        /// <param name="cacheKey">Llave del valor en cache</param>
        /// <param name="cacheValue">Valor a agregar a cache</param>
        /// <param name="hours">Tiempo de permanencia en cache en horas</param>
        public static void TryAddToCache(string cacheKey, T cacheValue, int hours)
        {
            TryAddToCache(cacheKey, cacheValue, hours, 0, 0);
        }

        public static void TryAddToCacheDefaultTime(string cacheKey, T cacheValue)
        {
            TryAddToCache(cacheKey, cacheValue, TimeHourDefault, 0, 0);
        }

        /// <summary>
        /// Agrega un valor al cache si está habilitado
        /// </summary>
        /// <param name="cacheKey">Llave del valor en cache</param>
        /// <param name="cacheValue">Valor a agregar a cache</param>
        /// <param name="hours">Tiempo de permanencia en cache en horas</param>
        /// <param name="minutes">Tiempo de permanencia en cache en minutes</param>
        public static async Task TryAddToCacheAsync(string cacheKey, T cacheValue, int hours, int minutes)
        {
            await TryAddToCacheAsync(cacheKey, cacheValue, hours, minutes, 0);
        }

        /// <summary>
        /// Agrega un valor al cache si está habilitado
        /// </summary>
        /// <param name="cacheKey">Llave del valor en cache</param>
        /// <param name="cacheValue">Valor a agregar a cache</param>
        /// <param name="hours">Tiempo de permanencia en cache en horas</param>
        public static async Task TryAddToCacheAsync(string cacheKey, T cacheValue, int hours)
        {
            await TryAddToCacheAsync(cacheKey, cacheValue, hours, 0, 0);
        }

        public static async Task TryAddToCacheDefaultTimeAsync(string cacheKey, T cacheValue)
        {
            await TryAddToCacheAsync(cacheKey, cacheValue, TimeHourDefault, 0, 0);
        }

        /// <summary>
        /// Agrega un valor al cache si está habilitado
        /// </summary>
        /// <param name="cacheKey">Llave del valor en cache</param>
        /// <param name="cacheValue">Valor a agregar a cache</param>
        /// <param name="hours">Tiempo de permanencia en cache en horas</param>
        /// <param name="minutes">Tiempo de permanencia en cache en minutes</param>
        /// <param name="seconds">Tiempo de permanencia en cache en segundos</param>
        public static async Task TryAddToCacheAsync(string cacheKey, T cacheValue, int hours, int minutes, int seconds)
        {
            TimeSpan timeSpan = new TimeSpan(hours, minutes, seconds);

            if (EnableCache)
            {
                var cacheEntry = await
                _cache.GetOrCreateAsync(cacheKey, entry =>
                {
                    entry.SlidingExpiration = timeSpan;
                    return Task.FromResult(cacheValue);
                });
            }
        }
    }
}
