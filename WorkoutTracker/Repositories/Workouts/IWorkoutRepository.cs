using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Base;

namespace WorkoutTracker.Repositories.Workouts
{
    public interface IWorkoutRepository : IBaseRepository<Workout>
    {
        Task<List<Workout>> GetAllWorkoutsByDayOfSplitId(int dayOfSplitId);
    }
}
