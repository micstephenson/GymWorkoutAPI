using Microsoft.EntityFrameworkCore;

namespace GymWorkoutAPI.Data
{
    public class Trainer
    {
        public int TrainerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
    }

    public class TrainerContext : DbContext
    {
        public TrainerContext(DbContextOptions<TrainerContext> options)
            : base(options)
        {
        }

        public DbSet<Trainer> Trainers { get; set; }
    }
}