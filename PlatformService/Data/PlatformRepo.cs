using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
	public class PlatformRepo : IPlatformRepo
	{
		private readonly AppDbContext _context;

		public PlatformRepo(AppDbContext context)
		{
			_context = context;
		}

		public void createPlatform(Platform platform)
		{
			if (platform == null)
			{
				throw new ArgumentNullException(nameof(platform));
			}

			_context.Platforms.Add(platform);
		}

		public IEnumerable<Platform> getAllPlatforms()
		{
			return _context.Platforms.ToList();
		}

		public Platform getPlatFormById(int id)
		{
			return _context.Platforms.FirstOrDefault(p => p.Id == id);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}
	}
}