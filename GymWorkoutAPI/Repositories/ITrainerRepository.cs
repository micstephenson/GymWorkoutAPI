using GymWorkoutAPI.Data;

namespace GymWorkoutAPI.Repositories;
public interface ITrainerRepository
{
    TrainerEntity GetById(int id);
    IEnumerable<TrainerEntity> GetAll();
    void Add(TrainerEntity trainer);
    void Remove(int id);
}
