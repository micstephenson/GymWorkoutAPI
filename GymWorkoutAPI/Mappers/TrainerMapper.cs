using GymWorkoutAPI.Data.Entity;
using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Mappers
{
    public static class TrainerMapper
    {
        public static Trainers ToEntity(this TrainerDto dto)
        {
            return new Trainers
            { 
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };
        }

        public static TrainerDto ToDTO(this Trainers entity)
        {
            return new TrainerDto
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email
            };
        }   
    }
}
