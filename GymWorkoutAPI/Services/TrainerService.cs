using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Mappers;
using GymWorkoutAPI.Repositories;

namespace GymWorkoutAPI.Services;
public class TrainerService(ITrainerRepository trainerRepository) : ITrainerService
{
    public void CreateTrainer(TrainerDto trainerDTO)
    {
        var trainerEntity = trainerDTO.ToEntity();
        trainerRepository.Add(trainerEntity);
    }

    public IEnumerable<TrainerDto> GetAllTrainers()
    {
        var trainerEntities = trainerRepository.GetAll();
        return trainerEntities.Select(entity => entity.ToDTO());
    }

    public TrainerDto? GetTrainerById(int id)
    {
        var trainerEntity = trainerRepository.GetById(id);
        return trainerEntity?.ToDTO();
    }

    public void RemoveTrainer(int id)
    {
        trainerRepository.Remove(id);
    }
}
