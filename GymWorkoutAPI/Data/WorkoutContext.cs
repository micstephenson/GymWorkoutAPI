using Microsoft.EntityFrameworkCore;

namespace GymWorkoutAPI.Data
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public string? WorkoutName { get; set; }
        public int? Reps { get; set; }
        public int? WorkoutSets { get; set; }
        public double? Duration { get; set; }
        public string Difficulty { get; set; }
    }

    public class WorkoutContext : DbContext
    {
        public WorkoutContext(DbContextOptions<WorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<Workout> Workouts { get; set; }
    }
}