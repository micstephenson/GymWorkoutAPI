using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Services
{
    public interface IWorkoutService
    {
        public void CreateWorkout(WorkoutDto workoutDTO);
        public IEnumerable<WorkoutDto> GetAllWorkouts();
        public WorkoutDto? GetWorkoutById(int id);
        public void RemoveWorkout(int id);
        public void UpdateWorkout(int id, WorkoutDto existingWorkout);
    }
}