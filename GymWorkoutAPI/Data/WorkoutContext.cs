using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GymWorkoutAPI.Data;
public class Workouts
{
    [Key]
    public int WorkoutID { get; set; }
    public string? WorkoutName { get; set; }
    public int? Reps { get; set; }
    public int? WorkoutSets { get; set; }
    public float? Duration { get; set; }
    public string Difficulty { get; set; }
}

public class WorkoutContext : DbContext
{
    public WorkoutContext(DbContextOptions<WorkoutContext> options)
        : base(options)
    {
    }

    public DbSet<Workouts> Workouts { get; set; }
}