using GymWorkoutAPI.Data.Entity;
using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Mappers
{
    public static class GymSessionMapper
    {
        public static GymSessions ToEntity(this GymSessionDto dto)
        {
            return new GymSessions
            {
                SessionDate = dto.SessionDate,
                TrainerID = dto.TrainerID,
                OverallDuration = dto.OverallDuration
            };
        }

        public static GymSessionDto ToDTO(this GymSessions entity)
        {
            return new GymSessionDto
            {
                SessionDate = entity.SessionDate,
                TrainerID = entity.TrainerID,
                OverallDuration = entity.OverallDuration
            };
        }
    }
}
