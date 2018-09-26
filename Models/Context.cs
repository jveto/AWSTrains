using Microsoft.EntityFrameworkCore;

namespace TrainTracker.Models{
    public class Context : DbContext{
        public Context(DbContextOptions<Context> options) : base(options){}
        
        public DbSet<TrainStation> TrainStations{get; set;}
    }
}