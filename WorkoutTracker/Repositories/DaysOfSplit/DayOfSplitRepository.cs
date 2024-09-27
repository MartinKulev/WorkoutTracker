using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Base;

namespace WorkoutTracker.Repositories.DaysOfSplit
{
    public class DayOfSplitRepository : BaseRepository<DayOfSplit>, IDayOfSplitRepository
    {
        private WorkoutTrackerDbContext context;

        public DayOfSplitRepository(WorkoutTrackerDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<DayOfSplit>> GetAllDaysOfSplitFromCurrentSplit()
        {
            int currentSplitId = await context.DaysOfSplits.MaxAsync(p => p.SplitId);
            return await context.DaysOfSplits
                .Where(p => p.SplitId == currentSplitId)
                .Include(p => p.Workouts)
                .ThenInclude(p => p.Exercises)
                .ToListAsync();
        }
    }
}
