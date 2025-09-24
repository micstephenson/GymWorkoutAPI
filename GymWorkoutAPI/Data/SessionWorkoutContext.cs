using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GymWorkoutAPI.Data;
public class SessionWorkout
{
    [Key]
    public int SessionID { get; set; }
    public List<int> WorkoutID { get; set; }
}

public class SessionWorkoutContext : DbContext
{
    public SessionWorkoutContext(DbContextOptions<SessionWorkoutContext> options)
        : base(options)
    {
    }

    public DbSet<SessionWorkout> SessionWorkout { get; set; }
}