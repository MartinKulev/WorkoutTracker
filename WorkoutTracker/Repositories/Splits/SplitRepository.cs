using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Base;

namespace WorkoutTracker.Repositories.Splits
{
    public class SplitRepository : BaseRepository<Split>, ISplitRepository
    {
        private WorkoutTrackerDbContext context;

        public SplitRepository(WorkoutTrackerDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
