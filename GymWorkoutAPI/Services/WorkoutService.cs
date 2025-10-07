using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Repositories;
using GymWorkoutAPI.Mappers;

namespace GymWorkoutAPI.Services;

public class WorkoutService(IWorkoutRepository workoutRepository) : IWorkoutService
{
    public IEnumerable<WorkoutDto> GetAllWorkouts()
    {
        var workoutEntity = workoutRepository.GetAll();
        return workoutEntity.Select(entity => entity.ToDTO());
    }

    public WorkoutDto GetWorkoutById(int id)
    {
        var workoutEntity = workoutRepository.GetById(id);
        return workoutEntity.ToDTO();
    }

    public void CreateWorkout(WorkoutDto workout)
    {
        var workoutEntity = workout.ToEntity();
        workoutRepository.Add(workoutEntity);
    }

    public void UpdateWorkout(int id, WorkoutDto existingWorkout)
    {
        var workoutEntity = existingWorkout.ToEntity();
        workoutRepository.Update(id, workoutEntity);
    }

    public void RemoveWorkout(int id)
    {
        workoutRepository.Remove(id);
    }
}
