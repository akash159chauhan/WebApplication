//using System.Runtime.Caching;
//using StackExchange.Redis;

//namespace WebApplication1;

//public class RedisInMemoryCache : ObjectCache
//{
//	private static IDatabase _database;
//	public RedisInMemoryCache(IDatabase database)
//	{
//		_database = database;
//	}

//	public override object this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//	public override DefaultCacheCapabilities DefaultCacheCapabilities => throw new NotImplementedException();

//	public override string Name => throw new NotImplementedException();

//	public override CacheItem AddOrGetExisting(CacheItem value, CacheItemPolicy policy)
//	{
//		throw new NotImplementedException();
//	}

//	public override object AddOrGetExisting(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override object AddOrGetExisting(string key, object value, CacheItemPolicy policy, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override bool Contains(string key, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override CacheEntryChangeMonitor CreateCacheEntryChangeMonitor(IEnumerable<string> keys, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override object Get(string key, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override CacheItem GetCacheItem(string key, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override long GetCount(string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override IDictionary<string, object> GetValues(IEnumerable<string> keys, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override object Remove(string key, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override void Set(CacheItem item, CacheItemPolicy policy)
//	{
//		throw new NotImplementedException();
//	}

//	public override void Set(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	public override void Set(string key, object value, CacheItemPolicy policy, string regionName = null)
//	{
//		throw new NotImplementedException();
//	}

//	protected override IEnumerator<KeyValuePair<string, object>> GetEnumerator()
//	{
//		throw new NotImplementedException();
//	}
//}
