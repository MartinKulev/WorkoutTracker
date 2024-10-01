using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Base;

namespace WorkoutTracker.Repositories.Splits
{
    public class SplitRepository : BaseRepository<Split>, ISplitRepository
    {
        private WorkoutTrackerDbContext _context;

        public SplitRepository(WorkoutTrackerDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
