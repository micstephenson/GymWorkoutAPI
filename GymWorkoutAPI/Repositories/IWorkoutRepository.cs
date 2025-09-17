using GymWorkoutAPI.Data;

namespace GymWorkoutAPI.Repositories;
public interface IWorkoutRepository
{
    Workout GetById(int id);
    IEnumerable<Workout> GetAll();
    void Add(Workout workout);
    void Remove(int id);
    void Update(Workout existingWorkout);
}
