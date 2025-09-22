using GymWorkoutAPI.Data;
using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Mappers
{
    public static class TrainerMapper
    {
        public static TrainerEntity ToEntity(this TrainerDTO dto)
        {
            return new TrainerEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };
        }

        public static TrainerDTO ToDTO(this TrainerEntity entity)
        {
            return new TrainerDTO
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email
            };
        }   
    }
}
