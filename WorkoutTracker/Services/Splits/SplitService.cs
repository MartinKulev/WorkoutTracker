using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Splits;

namespace WorkoutTracker.Services.Splits
{
    public class SplitService : ISplitService
    {
        private ISplitRepository _splitRepository;

        public SplitService(ISplitRepository splitRepository)
        {
            _splitRepository = splitRepository;
        }

        public async Task CreateSplitAsync()
        {
            Split split = new Split();
            split.SplitToString = "Pull • Push • Legs • Pull • Push";
            split.DateStart = new DateTime(2024, 7, 31);
            split.DateEnd = DateTime.UnixEpoch;
            split.WeekStart = 52;
            split.WeekEnd = 0;
            await _splitRepository.CreateAsync(split);
        }
    }
}
