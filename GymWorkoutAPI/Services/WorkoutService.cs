using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Repositories;
using GymWorkoutAPI.Mappers;

namespace GymWorkoutAPI.Services;

public class WorkoutService(IWorkoutRepository workoutRepository) : IWorkoutService
{
    public IEnumerable<WorkoutDto> GetAllWorkouts()
    {
        return (IEnumerable<WorkoutDto>)workoutRepository.GetAll();
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

    public void UpdateWorkout(WorkoutDto existingWorkout)
    {
        var workoutEntity = existingWorkout.ToEntity();
        workoutRepository.Update(workoutEntity);
    }

    public void RemoveWorkout(int id)
    {
        workoutRepository.Remove(id);
    }
}
