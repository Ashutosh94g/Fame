using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
	public interface IPlatformRepo
	{
		bool SaveChanges();

		IEnumerable<Platform> getAllPlatforms();
		Platform getPlatformById(int id);
		void createPlatform(Platform platform);
	}
}