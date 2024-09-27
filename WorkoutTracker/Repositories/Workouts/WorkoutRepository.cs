using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Base;

namespace WorkoutTracker.Repositories.Workouts
{
    public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
    {
        private WorkoutTrackerDbContext context;

        public WorkoutRepository(WorkoutTrackerDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Workout>> GetAllWorkoutsByDayOfSplitId(int dayOfSplitId)
        {
            return await context.Workouts.Where(p => p.DayOfSplitId == dayOfSplitId).ToListAsync();
        }
    }
}
