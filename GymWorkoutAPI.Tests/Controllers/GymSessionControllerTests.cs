using GymWorkoutAPI.Controllers;
using GymWorkoutAPI.Data;
using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace GymWorkoutAPI.Tests.Controllers;
public class GymSessionControllerTests
{
    [Fact]
    public void GetAllSessions_PositiveResponse()
    {
        // Arrange
        var mockService = Substitute.For<ITrainerService>();
        mockService.GetAllTrainers().Returns(new List<TrainerDTO> { new TrainerDTO() });
        var controller = new PersonalTrainerController(mockService);

        // Act
        var result = controller.GetAllTrainers();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var trainers = Assert.IsAssignableFrom<IEnumerable<TrainerDTO>>(okResult.Value);
    }

    [Fact]
    public void GetAllSessions_NegativeResponse()
    {
        // Arrange
        var mockService = Substitute.For<ITrainerService>();
        mockService.GetAllTrainers().Returns((IEnumerable<TrainerDTO>)null);
        var controller = new PersonalTrainerController(mockService);

        // Act
        var result = controller.GetAllTrainers();

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No Personal Trainers found", notFoundResult.Value);
    }
}
