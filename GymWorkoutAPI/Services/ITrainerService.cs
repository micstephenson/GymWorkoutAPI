using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Services;

public interface ITrainerService
{
    public void CreateTrainer(TrainerDTO trainerDTO);
}
