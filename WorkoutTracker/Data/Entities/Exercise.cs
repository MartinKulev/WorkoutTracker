using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Data.Entities
{
    public class Exercise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        [ForeignKey(nameof(Workout))]
        public int WorkoutId { get; set; }
    }
}
