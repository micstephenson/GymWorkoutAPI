using GymWorkoutAPI.Data;
using GymWorkoutAPI.Data.Entity;

namespace GymWorkoutAPI.Repositories;

public class WorkoutRepository(WorkoutContext workoutContext) : IWorkoutRepository
{

    public void Add(Workouts workout)
    {
        workoutContext.Workouts.Add(workout);
        workoutContext.SaveChanges();
    }

    public void Update(Workouts existingWorkout)
    {
        workoutContext.Workouts.Update(existingWorkout);
        workoutContext.SaveChanges();
    }

    public IEnumerable<Workouts> GetAll()
    {
        var workouts = workoutContext.Workouts.ToList();
        return workoutContext.Workouts.ToList();
    }

    public Workouts GetById(int id)
    {
        return workoutContext.Workouts.FirstOrDefault(p => p.WorkoutID == id);
    }

    public void Remove(int id)
    {
        var workout = workoutContext.Workouts.FirstOrDefault(p => p.WorkoutID == id);
        if (workout != null)
        {
            workoutContext.Workouts.Remove(workout);
            workoutContext.SaveChanges();
        }
    }
}
