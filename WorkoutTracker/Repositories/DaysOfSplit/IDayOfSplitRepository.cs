using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Base;

namespace WorkoutTracker.Repositories.DaysOfSplit
{
    public interface IDayOfSplitRepository : IBaseRepository<DayOfSplit>
    {
        Task<List<DayOfSplit>> GetAllDaysOfSplitFromCurrentSplit();

        Task<List<DayOfSplit>> GetAllDaysOfSplitBySplitId(int splitId);
    }
}
