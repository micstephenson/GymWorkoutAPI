using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GymWorkoutAPI.Data;
public class TrainerEntity
{
    [Key]
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

    public DbSet<TrainerEntity> Trainers { get; set; }
}