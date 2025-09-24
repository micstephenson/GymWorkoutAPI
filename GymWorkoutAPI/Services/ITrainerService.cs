using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Services;

public interface ITrainerService
{
    public void CreateTrainer(TrainerDTO trainerDTO);
    public IEnumerable<TrainerDTO> GetAllTrainers();
    public TrainerDTO? GetTrainerById(int id);
    public void RemoveTrainer(int id);
}
