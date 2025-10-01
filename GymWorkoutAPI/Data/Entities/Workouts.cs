using System.ComponentModel.DataAnnotations;

namespace GymWorkoutAPI.Data.Entity
{
    public class Workouts
    {
        [Key]
        public int WorkoutID { get; set; }
        public string? WorkoutName { get; set; }
        public int? Reps { get; set; }
        public int? WorkoutSets { get; set; }
        public double? Duration { get; set; }
        public string Difficulty { get; set; }
    }
}
