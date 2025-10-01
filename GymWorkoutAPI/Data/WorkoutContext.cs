using GymWorkoutAPI.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace GymWorkoutAPI.Data;
public class WorkoutContext : DbContext
{
    public WorkoutContext(DbContextOptions<WorkoutContext> options)
        : base(options)
    {
    }

    public DbSet<Workouts> Workouts { get; set; }
    public DbSet<Trainers> Trainers { get; set; }
    public DbSet<SessionWorkout> SessionWorkout { get; set; }
    public DbSet<GymSessions> GymSessions { get; set; }
}