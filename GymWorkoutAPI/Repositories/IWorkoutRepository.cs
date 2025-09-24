using GymWorkoutAPI.Data;

namespace GymWorkoutAPI.Repositories;
public interface IWorkoutRepository
{
    Workouts GetById(int id);
    IEnumerable<Workouts> GetAll();
    void Add(Workouts workout);
    void Remove(int id);
    void Update(Workouts existingWorkout);
}
