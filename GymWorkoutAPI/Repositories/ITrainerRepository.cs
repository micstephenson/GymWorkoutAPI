using GymWorkoutAPI.Data;

namespace GymWorkoutAPI.Repositories;
public interface ITrainerRepository
{
    Trainer GetById(int id);
    IEnumerable<Trainer> GetAll();
    void Add(Trainer trainer);
    void Remove(int id);
}
