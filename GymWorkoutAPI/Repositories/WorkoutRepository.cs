using GymWorkoutAPI.Data;
using GymWorkoutAPI.Data.Entity;
using GymWorkoutAPI.Services;

namespace GymWorkoutAPI.Repositories;

public class WorkoutRepository(WorkoutContext workoutContext) : IWorkoutRepository
{

    public void Add(Workouts workout)
    {
        workoutContext.Workouts.Add(workout);
        workoutContext.SaveChanges();
    }

    public void Update(int id, Workouts updatedWorkout)
    {
        var existingWorkout = GetById(id);

        existingWorkout.WorkoutName = updatedWorkout.WorkoutName;
        existingWorkout.Duration = updatedWorkout.Duration;
        existingWorkout.WorkoutSets = updatedWorkout.WorkoutSets;
        existingWorkout.Duration = updatedWorkout.Duration;
        existingWorkout.Difficulty = updatedWorkout.Difficulty;

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
