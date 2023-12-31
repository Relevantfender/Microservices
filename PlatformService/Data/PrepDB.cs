﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlatformService.Models;

namespace PlatformService;

public static class PrepDB
{
  public static void PrepPopulation(IApplicationBuilder app)
  {
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
      SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }
  }

  private static void SeedData(AppDbContext context)
  {
    if (!context.Platforms.Any())
    {
      Console.WriteLine("Seeding data...");

      context.Platforms.AddRange(
        new Platform() { Name = "Dot net", Publisher = "Microsoft", Cost = "Free" },
        new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
        new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
      );

      context.SaveChanges();
    }
    else
    {
      Console.WriteLine("--> we already have data");
    }
  }
}
