using GymWorkoutAPI.Controllers;
using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace GymWorkoutAPI.Tests.Controllers;

public class PersonalTrainerControllerTests
{
    [Fact]
    public void GetAllTrainers_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ITrainerService>();
        mockRepo.GetAllTrainers().Returns(new List<TrainerDto> { new TrainerDto() });
        var controller = new PersonalTrainerController(mockRepo);

        // Act
        var result = controller.GetAllTrainers();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var trainers = Assert.IsAssignableFrom<IEnumerable<TrainerDto>>(okResult.Value);
    }

    [Fact]
    public void GetAllTrainers_NegativeResponse() 
    {
        // Arrange
        var mockRepo = Substitute.For<ITrainerService>();
        mockRepo.GetAllTrainers().Returns((IEnumerable<TrainerDto>)null);
        var controller = new PersonalTrainerController(mockRepo);

        // Act
        var result = controller.GetAllTrainers();

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No Personal Trainers found", notFoundResult.Value);
    }

    public void AddNewTrainer_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ITrainerService>();
        var controller = new PersonalTrainerController(mockRepo);
        var newTrainer = new TrainerDto {FirstName = "Test", LastName = "Trainer", Email = "testtrainer@gymplace.com"};
        // Act
        var result = controller.AddTrainer(newTrainer);
        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(newTrainer, createdAtActionResult.Value);
    }

    public void AddNewTrainer_NegativeResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ITrainerService>();
        var controller = new PersonalTrainerController(mockRepo);
        TrainerDto newTrainer = null;

        // Act
        var result = controller.AddTrainer(newTrainer);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Trainer data is null.", badRequestResult.Value);
    }

    public void RemoveTrainer_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ITrainerService>();
        var controller = new PersonalTrainerController(mockRepo);
        var existingTrainer = new TrainerDto {FirstName = "Test", LastName = "Trainer" };
        mockRepo.GetTrainerById(1).Returns(existingTrainer);
        // Act
        var result = controller.RemoveTrainer(1);
        // Assert
        Assert.IsType<NoContentResult>(result);
        mockRepo.Received(1).RemoveTrainer(1);
    }

    public void RemoveTrainer_NegativeResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ITrainerService>();
        var controller = new PersonalTrainerController(mockRepo);
        mockRepo.GetTrainerById(1).Returns((TrainerDto)null);
        // Act
        var result = controller.RemoveTrainer(1);
        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Trainer with id 1 not found", notFoundResult.Value);
    }
}
