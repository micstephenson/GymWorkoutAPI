using Microsoft.EntityFrameworkCore;

namespace GymWorkoutAPI.Data
{
    public class Session
    {
        public int SessionID { get; set; }
        public DateTime SessionDate { get; set; }
        public float OverallDuration { get; set; }        
        public int TrainerID { get; set; }
    }

    public class SessionContext : DbContext
    {
        public SessionContext(DbContextOptions<SessionContext> options)
            : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }
    }
}