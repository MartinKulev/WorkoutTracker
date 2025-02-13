using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Base;

namespace WorkoutTracker.Repositories.DaysOfSplit
{
    public class DayOfSplitRepository : BaseRepository<DayOfSplit>, IDayOfSplitRepository
    {
        private WorkoutTrackerDbContext _context;

        public DayOfSplitRepository(WorkoutTrackerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DayOfSplit>> GetAllDaysOfSplitFromCurrentSplit()
        {
            if(await _context.DaysOfSplits.AnyAsync())
            {
                int currentSplitId = await _context.DaysOfSplits.MaxAsync(p => p.SplitId);
                List<DayOfSplit> daysOfSplit = await _context.DaysOfSplits
                    .Where(p => p.SplitId == currentSplitId)
                    .Include(p => p.Workouts)
                        .ThenInclude(p => p.Exercises).OrderBy(p => p.Id)
                    .ToListAsync();

                foreach (var dayOfSplit in daysOfSplit)
                {
                    foreach (var workout in dayOfSplit.Workouts)
                    {
                        workout.Exercises = workout.Exercises.OrderBy(e => e.Id).ToList();
                    }
                }
                return daysOfSplit;
            }
            else
            {
                return new List<DayOfSplit>();
            }

        }

        public async Task<List<DayOfSplit>> GetAllDaysOfSplitBySplitId(int splitId)
        {
            List<DayOfSplit> daysOfSplit = await _context.DaysOfSplits
                .Where(p => p.SplitId == splitId)
                .Include(p => p.Workouts)
                    .ThenInclude(p => p.Exercises)
                .ToListAsync();

            foreach (var dayOfSplit in daysOfSplit)
            {
                foreach (var workout in dayOfSplit.Workouts)
                {
                    workout.Exercises = workout.Exercises.OrderBy(e => e.Id).ToList();
                }
            }

            return daysOfSplit;
        }

        public async Task<DayOfSplit> GetDayOfSplitById(int dayOfSplitId)
        {
            return _context.DaysOfSplits.First(p => p.Id == dayOfSplitId);
        }
    }
}
