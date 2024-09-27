using WorkoutTracker.Repositories.Workouts;

namespace WorkoutTracker.Services.Workouts
{
    public class WorkoutService : IWorkoutService
    {
        private IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
    }
}
