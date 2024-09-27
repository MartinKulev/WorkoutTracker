using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Data.Entities
{
    public class Workout
    {
        public int Id { get; set; }

        public DateTime DateWorkout { get; set; }

        [ForeignKey(nameof(DayOfSplitId))]
        public int DayOfSplitId { get; set; }

        public List<Exercise> Exercises { get; set; }
    } 
}
