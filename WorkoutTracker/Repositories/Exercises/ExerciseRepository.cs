using WorkoutTracker.Data;
using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Base;

namespace WorkoutTracker.Repositories.Exercises
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        private WorkoutTrackerDbContext context;

        public ExerciseRepository(WorkoutTrackerDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
