using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Mappers;
using GymWorkoutAPI.Repositories;

namespace GymWorkoutAPI.Services;
public class TrainerService(ITrainerRepository trainerRepository) : ITrainerService
{
    public void CreateTrainer(TrainerDTO trainerDTO)
    {
        var trainerEntity = trainerDTO.ToEntity();
        trainerRepository.Add(trainerEntity);
    }

    // Fix: Implement the correct GetAllTrainers method as per ITrainerService interface
    public IEnumerable<TrainerDTO> GetAllTrainers()
    {
        var trainerEntities = trainerRepository.GetAll();
        return trainerEntities.Select(entity => entity.ToDTO());
    }

    public TrainerDTO? GetTrainerById(int id)
    {
        var trainerEntity = trainerRepository.GetById(id);
        return trainerEntity?.ToDTO();
    }

    public void RemoveTrainer(int id)
    {
        trainerRepository.Remove(id);
    }
}
