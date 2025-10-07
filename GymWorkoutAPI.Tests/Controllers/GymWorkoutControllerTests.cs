using GymWorkoutAPI.Controllers;
using GymWorkoutAPI.Data.Entity;
using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace GymWorkoutAPI.Tests.Controllers;

public class GymWorkoutControllerTests
{
    [Fact]
    public void GetAllWorkouts_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutService>();
        mockRepo.GetAllWorkouts().Returns(new List<WorkoutDto> { new WorkoutDto() });
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.GetAllWorkouts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var workouts = Assert.IsAssignableFrom<IEnumerable<WorkoutDto>>(okResult.Value);
    }

    [Fact]
    public void GetAllWorkouts_NegativeResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutService>();
        mockRepo.GetAllWorkouts().Returns((IEnumerable<WorkoutDto>)null);
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.GetAllWorkouts();

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No Workouts found", notFoundResult.Value);
    }


    [Fact]
    public void AddNewWorkout_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutService>();
        var controller = new GymWorkoutController(mockRepo);
        var newWorkout = new WorkoutDto {WorkoutName = "Test Workout", Reps = 10, WorkoutSets = 10, Duration = 30.5, Difficulty = "low" };

        // Act
        var result = controller.AddWorkout(newWorkout);

        // Assert
        var createdAtActionResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Workout added successfully.", createdAtActionResult.Value);
    }

    [Fact]
    public void AddNewWorkout_NegativeResponse_NUllWorkout()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutService>();
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.AddWorkout(null);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void UpdateWorkout_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutService>();
        var existingWorkout = new WorkoutDto { WorkoutName = "Existing Workout" };
        mockRepo.GetWorkoutById(1).Returns(existingWorkout);
        var controller = new GymWorkoutController(mockRepo);
        var updatedWorkout = new WorkoutDto { WorkoutName = "Updated Workout" };

        // Act
        var result = controller.UpdateWorkout(1, updatedWorkout);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }


    [Fact]
    public void UpdateWorkout_NegativeResponse_InvalidWorkoutData()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutService>();
        var controller = new GymWorkoutController(mockRepo);
        // Act
        var result = controller.UpdateWorkout(1, null);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Invalid workout data", badRequestResult.Value);
    }


    [Fact]
    public void DeleteWorkout_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutService>();
        var existingWorkout = new WorkoutDto { WorkoutName = "Existing Workout" };
        mockRepo.GetWorkoutById(1).Returns(existingWorkout);
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.RemoveWorkout(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }


    [Fact]
    public void DeleteWorkout_PositiveResponse_WorkoutNotFound()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutService>();
        mockRepo.GetWorkoutById(1).Returns((WorkoutDto)null);
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.RemoveWorkout(1);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    }
}
