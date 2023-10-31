﻿using PlatformService.Models;

namespace PlatformService.Repositories;

public interface IPlatformRepo
{
  bool SaveChanges();

  IEnumerable<Platform> GetAllPlatforms();
  Platform GetPlatformByID(int id);
  void CreatePlatform(Platform platform);

}
