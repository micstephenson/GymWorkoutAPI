using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Services;

public class UserDetailsService : IUserDetailsService
{
    public List<UserDetailsDTO> GetUserDetails()
    {
        return new List<UserDetailsDTO>
        {
            new UserDetailsDTO { UserName = "JohnDoe", Email = "johndoe@email.com", Address =  "12 Doe Street" },
            new UserDetailsDTO { UserName = "JaneDoe", Email = "janedoe@email.com", Address =  "23 Doe Street" },
            new UserDetailsDTO { UserName = "JerryDoe", Email = "jerrydoe@email.com", Address =  "12 Doe Street" }
        };
    }

    public void CreateUserDetails(UserDetailsDTO userDetails)
    {
        Console.WriteLine($"Added user: {userDetails.UserName}, Email: {userDetails.Email}, Address: {userDetails.Address}");
    }

    public IEnumerable<UserDetailsDTO> GetAllUserDetails()
    {
        return GetUserDetails();
    }

    public UserDetailsDTO? GetUserDetailByUserName(string userName)
    {
        return GetUserDetails().FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
    }

    public void RemoveUserDetails(string userName)
    {
        Console.WriteLine($"Removed user with UserName: {userName}");
    }

}
