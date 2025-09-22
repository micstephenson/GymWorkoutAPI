using GymWorkoutAPI.Data;

namespace GymWorkoutAPI.Repositories
{
    public class WorkoutRepository(WorkoutContext workoutContext) : IWorkoutRepository
    {

        public void Add(Workout workout)
        {
            workoutContext.Workouts.Add(workout);
            workoutContext.SaveChanges();
        }

        public void Update(Workout existingWorkout)
        {
            workoutContext.Workouts.Update(existingWorkout);
            workoutContext.SaveChanges();
        }

        public IEnumerable<Workout> GetAll()
        {
            return workoutContext.Workouts.ToList();
        }

        public Workout GetById(int id)
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
}
