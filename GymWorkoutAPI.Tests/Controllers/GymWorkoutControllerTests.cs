using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using GymWorkoutAPI.Repositories;
using GymWorkoutAPI.Data;
using GymWorkoutAPI.Controllers;

namespace GymWorkoutAPI.Tests.Controllers;

public class GymWorkoutControllerTests
{
    [Fact]
    public void GetAllWorkouts_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        mockRepo.GetAll().Returns(new List<Workouts> { new Workouts() });
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.GetAllWorkouts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var workouts = Assert.IsAssignableFrom<IEnumerable<Workouts>>(okResult.Value);
    }

    [Fact]
    public void GetAllWorkouts_NegativeResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        mockRepo.GetAll().Returns((IEnumerable<Workouts>)null);
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
        var mockRepo = Substitute.For<IWorkoutRepository>();
        var controller = new GymWorkoutController(mockRepo);
        var newWorkout = new Workouts { WorkoutID = 1, WorkoutName = "Test Workout" };

        // Act
        var result = controller.AddWorkout(newWorkout);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(newWorkout, createdAtActionResult.Value);
    }

    [Fact]
    public void AddNewWorkout_NegativeResponse_NUllWorkout()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
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
        var mockRepo = Substitute.For<IWorkoutRepository>();
        var existingWorkout = new Workouts { WorkoutID = 1, WorkoutName = "Existing Workout" };
        mockRepo.GetById(1).Returns(existingWorkout);
        var controller = new GymWorkoutController(mockRepo);
        var updatedWorkout = new Workouts { WorkoutID = 1, WorkoutName = "Updated Workout" };

        // Act
        var result = controller.UpdateWorkout(1, updatedWorkout);

        // Assert
        Assert.IsType<NoContentResult>(result);
        mockRepo.Received(1).Update(Arg.Is<Workouts>(w => w.WorkoutName == "Updated Workout"));
    }


    [Fact]
    public void UpdateWorkout_NegativeResponse_InvalidWorkoutData()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        var controller = new GymWorkoutController(mockRepo);
        var updatedWorkout = new Workouts { WorkoutID = 2, WorkoutName = "Updated Workout" };

        // Act
        var result = controller.UpdateWorkout(1, updatedWorkout);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }


    [Fact]
    public void DeleteWorkout_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        var existingWorkout = new Workouts { WorkoutID = 1, WorkoutName = "Existing Workout" };
        mockRepo.GetById(1).Returns(existingWorkout);
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
        var mockRepo = Substitute.For<IWorkoutRepository>();
        mockRepo.GetById(1).Returns((Workouts)null);
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.RemoveWorkout(1);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    }
}
