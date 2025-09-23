using Microsoft.EntityFrameworkCore;

namespace GymWorkoutAPI.Data
{
    public class SessionWorkout
    {
        public int SessionID { get; set; }
        public int WorkoutID { get; set; }
    }

    public class SessionWorkoutContext : DbContext
    {
        public SessionWorkoutContext(DbContextOptions<SessionWorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<SessionWorkout> SessionWorkout { get; set; }
    }
}