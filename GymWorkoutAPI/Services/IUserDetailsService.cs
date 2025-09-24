using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Services;
public interface IUserDetailsService
{
    public void CreateUserDetails(UserDetailsDTO userDetailsDTO);
    public IEnumerable<UserDetailsDTO> GetAllUserDetails();
    public UserDetailsDTO? GetUserDetailByUserName(string userName);
    public void RemoveUserDetails(string userName);
}
