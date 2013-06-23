using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace ZG.Common.Concrete
{
    public class ZGCache
    {
        public static T Cache<T>(string key, Func<T> fetchData, bool fetchIfNull = false)
        {
            return Cache(key, fetchData, TimeSpan.FromMinutes(15), fetchIfNull);
        }

        public static T Cache<T>(string key, Func<T> fetchData, TimeSpan cacheDuration, bool fetchIfNull = false)
        {
            try
            {
                var cache = HttpRuntime.Cache;

                var item = cache[key];

                if (item != null)
                {
                    if (item is NullInCache)
                    {
                        if (!fetchIfNull)
                        {
                            return default(T);
                        }

                        var nullResult = fetchData.Invoke();
                        if (nullResult != null)
                        {

                            InsertInCache(cache, key, nullResult, cacheDuration);
                        }
                        return nullResult;
                    }

                    if (item is T)
                    {
                        return (T)item;
                    }

                    throw new InvalidCastException();
                }

                var result = fetchData.Invoke();
                InsertInCache(cache, key, result, cacheDuration);

                return result;
            }
            catch (Exception)
            {
                return fetchData.Invoke();
            }
        }

        private static void InsertInCache<T>(Cache cache, string key, T result, TimeSpan cacheDuration)
        {
            object itemToAdd = result;
            if (result == null)
            {
                itemToAdd = new NullInCache();
            }

            //cache.Add(key, itemToAdd, CacheItemPriority.Normal, null, new AbsoluteTime(cacheDuration));
            cache.Add(key, itemToAdd, null, DateTime.Now.AddMinutes(cacheDuration.TotalMinutes), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        [Serializable]
        //[DataContract]
        private class NullInCache { }
    }
}
