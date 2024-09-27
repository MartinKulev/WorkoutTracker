using WorkoutTracker.Repositories.Exercises;

namespace WorkoutTracker.Services.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
    }
}
