using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
	public static class PrepDb
	{

		public static void PrePopulation(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
			}
		}

		public static void SeedData(AppDbContext context)
		{
			if (!context.Platforms.Any())
			{
				Console.WriteLine("Seeding Data...");

				context.Platforms.AddRange(
					new Platform() { Name = "Windows", Publisher = "Microsoft", Cost = "100" },
					new Platform() { Name = "Vscode", Publisher = "Microsoft", Cost = "Free" },
					new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" }
				);

				context.SaveChanges();
			}
			else
			{
				Console.WriteLine("--> Data already added");
			}
		}
	}
}