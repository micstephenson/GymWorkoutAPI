using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Services;

public interface ITrainerService
{
    public void CreateTrainer(TrainerDto trainerDTO);
    public IEnumerable<TrainerDto> GetAllTrainers();
    public TrainerDto? GetTrainerById(int id);
    public void RemoveTrainer(int id);
}