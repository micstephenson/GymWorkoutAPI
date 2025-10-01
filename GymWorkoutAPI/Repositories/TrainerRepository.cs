using GymWorkoutAPI.Data;
using GymWorkoutAPI.Data.Entity;

namespace GymWorkoutAPI.Repositories;

public class TrainerRepository(WorkoutContext workoutContext) : ITrainerRepository
{

    public void Add(Trainers trainer)
    {
        workoutContext.Trainers.Add(trainer);
        workoutContext.SaveChanges();
    }

    public IEnumerable<Trainers> GetAll()
    {
        return workoutContext.Trainers.ToList();
    }

    public Trainers? GetById(int id)
    {
        return workoutContext.Trainers.FirstOrDefault(p => p.TrainerID == id);
    }

    public void Remove(int id)
    {
        var trainer = workoutContext.Trainers.FirstOrDefault(p => p.TrainerID == id);
        if (trainer != null)
        {
            workoutContext.Trainers.Remove(trainer);
            workoutContext.SaveChanges();
        }
    }
}
