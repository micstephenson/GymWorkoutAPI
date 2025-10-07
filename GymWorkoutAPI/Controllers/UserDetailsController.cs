//using GymWorkoutAPI.DataTransferObjects;
//using GymWorkoutAPI.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace GymWorkoutAPI.Controllers;
//[Route("api/[controller]")]
//[ApiController]
//public class UserDetailsController(IUserDetailsService userDetailsService) : ControllerBase
//{
//    [HttpGet(Name = "Get All User Details")]
//    public IActionResult GetAllUserDetails()
//    {
//        var userDetails = userDetailsService.GetAllUserDetails();
//        if (userDetails == null || !userDetails.Any())
//        {
//            return NotFound("No User Details found");
//        }
//        return Ok(userDetails);
//    }

//    [HttpPost(Name = "Add User Details")]
//    public IActionResult CreateUserDetails([FromBody] UserDetailsDTO userDetailsDTO)
//    {
//        if (userDetailsDTO == null)
//        {
//            return BadRequest("User details data is null.");
//        }
//        userDetailsService.CreateUserDetails(userDetailsDTO);
//        return Created();
//    }

//    [HttpDelete("{userName}", Name = "Remove User Details")]
//    public IActionResult RemoveUserDetails(string userName)
//    {
//        var userDetails = userDetailsService.GetUserDetailByUserName(userName);
//        if (userDetails == null)
//        {
//            return NotFound($"User with name {userName} not found");
//        }
//        userDetailsService.RemoveUserDetails(userName);
//        return NoContent();
//    }

//    [HttpGet("{userName}", Name = "Get User Details")]
//    public IActionResult GetUserDetails(string userName)
//    {
//        var userDetails = userDetailsService.GetUserDetailByUserName(userName);
//        if (userDetails == null)
//        {
//            return NotFound($"User with name {userName} not found");
//        }
//        return Ok(userDetails);
//    }
//}