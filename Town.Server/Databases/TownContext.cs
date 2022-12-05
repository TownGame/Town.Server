using Microsoft.EntityFrameworkCore;
using Town.Server.Databases.Tables;

namespace Town.Server.Databases;

public class TownContext : DbContext {
    public TownContext(DbContextOptions options) : base(options) { }

    public DbSet<PlayerDataEntry> Players { get; set; }
}
