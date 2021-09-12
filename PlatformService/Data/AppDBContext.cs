using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace Name.PlatformService.Data
{
	public class AppDBContext : DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{

		}

		public DbSet<Platform> Platforms { get; set; }
	}
}