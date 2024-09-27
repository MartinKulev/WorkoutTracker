using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Data.Entities
{
    public class DayOfSplit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int WorkoutCount { get; set; }

        [ForeignKey(nameof(Split))]
        public int SplitId { get; set; }

        public List<Workout> Workouts { get; set; }
    }
}
