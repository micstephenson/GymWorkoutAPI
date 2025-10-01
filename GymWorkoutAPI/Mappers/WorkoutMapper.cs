using GymWorkoutAPI.Data.Entity;
using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Mappers
{
    public static class WorkoutMapper
    {
        public static Workouts ToEntity(this WorkoutDto dto)
        {
            return new Workouts
            {
                WorkoutName = dto.WorkoutName,
                Reps = dto.Reps,
                WorkoutSets = dto.WorkoutSets,
                Duration = dto.Duration,
                Difficulty = dto.Difficulty
            };
        }
        public static WorkoutDto ToDTO(this Workouts entity)
        {
            return new WorkoutDto
            {
                WorkoutName = entity.WorkoutName,
                Reps = entity.Reps,
                WorkoutSets = entity.WorkoutSets,
                Duration = entity.Duration,
                Difficulty = entity.Difficulty
            };
        }
    }
}
