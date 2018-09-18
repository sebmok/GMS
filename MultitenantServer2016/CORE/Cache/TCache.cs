using System;

namespace MultitenantServer2016.CORE.Cache
{

    public class TCache<T>
    {
        public T Get(string cacheKeyName, int cacheTimeOutSeconds, Func<T> func)
        {
            return new TCacheInternal<T>().Get(
                cacheKeyName, cacheTimeOutSeconds, func);
        }
    }
}