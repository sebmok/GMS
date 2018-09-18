using System;

namespace MultitenantServer2016.CORE.Cache
{
    public interface ITCache<T>
    {
        T Get(string cacheKeyName, int chacheTimeOutSeconds, Func<T> func);
    }
}