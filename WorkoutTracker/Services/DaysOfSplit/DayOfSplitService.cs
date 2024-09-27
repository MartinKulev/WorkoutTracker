using WorkoutTracker.Repositories.DaysOfSplit;

namespace WorkoutTracker.Services.DaysOfSplit
{
    public class DayOfSplitService : IDayOfSplitService
    {
        private IDayOfSplitRepository _dayOfSplitRepository;

        public DayOfSplitService(IDayOfSplitRepository dayOfSplitRepository)
        {
            _dayOfSplitRepository = dayOfSplitRepository;
        }

    }
}
