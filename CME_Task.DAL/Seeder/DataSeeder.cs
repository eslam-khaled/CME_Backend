using CME_Task.DAL.DBContext;
using CME_Task.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.DAL.Seeder
{

    public static class DataSeeder
    {
        public static void SeedRoomTypes(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbContext.RoomTypes.AnyAsync().GetAwaiter().GetResult())
            {
                return; // Room types are already seeded
            }

            var roomTypes = new List<RoomType>
    {
        new RoomType { Type = "Standard" },
        new RoomType { Type = "Suite" },
        new RoomType { Type = "Deluxe" }
    };

            dbContext.RoomTypes.AddRange(roomTypes);
            dbContext.SaveChanges();
        }

    }
}
