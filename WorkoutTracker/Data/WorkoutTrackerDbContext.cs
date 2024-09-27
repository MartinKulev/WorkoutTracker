using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data.Entities;

namespace WorkoutTracker.Data
{
    public class WorkoutTrackerDbContext : DbContext
    {
        public DbSet<DayOfSplit> DaysOfSplits { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Split> Splits { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        
        public WorkoutTrackerDbContext(DbContextOptions<WorkoutTrackerDbContext> options)
            : base(options)
        {
        }
    }
}