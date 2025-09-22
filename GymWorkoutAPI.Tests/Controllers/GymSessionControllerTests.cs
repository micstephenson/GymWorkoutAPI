using GymWorkoutAPI.Controllers;
using GymWorkoutAPI.Data;
using GymWorkoutAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace GymWorkoutAPI.Tests.Controllers;
public class GymSessionControllerTests
{
    [Fact]
    public void GetAllSessions_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ITrainerRepository>();
        mockRepo.GetAll().Returns(new List<TrainerEntity> { new TrainerEntity() });
        var controller = new PersonalTrainerController(mockRepo);

        // Act
        var result = controller.GetAllTrainers();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var trainers = Assert.IsAssignableFrom<IEnumerable<TrainerEntity>>(okResult.Value);
    }

    [Fact]
    public void GetAllSessions_NegativeResponse()
    { 
        // Arrange
        var mockRepo = Substitute.For<ITrainerRepository>();
        mockRepo.GetAll().Returns((IEnumerable<TrainerEntity>)null);
        var controller = new PersonalTrainerController(mockRepo);

        // Act
        var result = controller.GetAllTrainers();

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No Personal Trainers found", notFoundResult.Value);
    }

}
