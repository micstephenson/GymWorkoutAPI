using GymWorkoutAPI.Data.Entity;

namespace GymWorkoutAPI.Repositories;
public interface ITrainerRepository
{
    Trainers GetById(int id);
    IEnumerable<Trainers> GetAll();
    void Add(Trainers trainer);
    void Remove(int id);
}
