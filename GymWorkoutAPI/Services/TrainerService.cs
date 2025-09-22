using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Mappers;
using GymWorkoutAPI.Repositories;

namespace GymWorkoutAPI.Services;
public class TrainerService(ITrainerRepository trainerRepository)
{
    public void CreateTrainer(TrainerDTO trainerDTO)
    {
        var trainerEntity = trainerDTO.ToEntity();
        trainerRepository.Add(trainerEntity);
    }

    public void GetAllTrainers(TrainerDTO trainerDTO)
    {
        var trainerEntity = trainerDTO.ToEntity();
        trainerRepository.GetAll();
    }

    public void RemoveTrainer(int id)
    {
        trainerRepository.Remove(id);
    }
}
