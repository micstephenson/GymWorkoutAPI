using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace GymWorkoutAPI.Data;

public class GymSessions
{
    [Key]
    public int SessionID { get; set; }
    public DateTime? SessionDate { get; set; }
    public float OverallDuration { get; set; }        
    public int TrainerID { get; set; }
}

public class SessionContext : DbContext
{
    public SessionContext(DbContextOptions<SessionContext> options)
        : base(options)
    {
    }

    public DbSet<GymSessions> GymSessions { get; set; }
}