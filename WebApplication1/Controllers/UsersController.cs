using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using StackExchange.Redis;
using Z.EntityFramework.Plus;
using System.Runtime.Caching;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly DataContext _context;

		public UsersController(DataContext context)
		{
			_context = context;

			//var options = new MemoryCacheEntryOptions() { AbsoluteExpiration = DateTime.Now.AddMinutes(5) };
			var connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:5003");
			
			QueryCacheManager.Cache = new RedisObjectCache(connectionMultiplexer.GetDatabase(), Newtonsoft.Json.JsonConvert.SerializeObject, (type, s) => Newtonsoft.Json.JsonConvert.DeserializeObject(s, type));

			QueryCacheManager.CacheKeyFactory = (context, key) =>
			{
				// Custom cache key generation logic
				var cacheKey = $"{key}_{context}";
				return cacheKey;
			};

			QueryCacheManager.CacheItemPolicyFactory = () =>
			{
				var policy = new CacheItemPolicy
				{
					AbsoluteExpiration = DateTime.Now.AddMinutes(2)
				};
				return policy;
			};
			//QueryCacheManager.DefaultMemoryCacheEntryOptions = options;
			//QueryCacheManager.IsCommandInfoOptionalForCacheKey = true;
			//QueryCacheManager.IncludeConnectionInCacheKey = false;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<List<User>>> GetAll()
		{
			IQueryable<User> users = _context.User;

			var service = _context.User.FromCache(tags: new string[] { "A1" }).ToList();
			//var query = QueryCacheManager.GetCacheKey(users, new string[] { "A1" });

			return Ok(service);
		}

		[HttpGet("GetByName")]
		public async Task<ActionResult<ServiceResponse<List<User>>>> GetByName(string name)
		{
			var service = new ServiceResponse<List<User>>();
			IQueryable<User> query = _context.User.Where(x => x.UserName.Equals(name));
			service.Data = query.FromCache(new string[] { "A1" }).ToList();

			var cacheKey = QueryCacheManager.GetCacheKey(query, new string[] { "A1" });
			service.Query = cacheKey;

			return Ok(service);
		}

		[HttpGet("ExpireTag")]
		public async Task<ActionResult> ExpireTag()
		{
			//var d = CacheH
			QueryCacheManager.ExpireAll();
			return Ok();
		}

		[HttpGet("Put")]
		public async Task<ActionResult<List<User>>> Put(string name)
		{
			var user = new User
			{
				UserName = name
			};
			_context.User.Add(user);
			await _context.SaveChangesAsync();

			return Ok(_context.User.ToList());
		}
	}
}