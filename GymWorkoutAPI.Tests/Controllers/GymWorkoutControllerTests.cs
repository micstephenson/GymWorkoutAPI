using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using GymWorkoutAPI.Repositories;
using GymWorkoutAPI.Data;
using GymWorkoutAPI.Controllers;

namespace GymWorkoutAPI.Tests.Controllers;

public class GymWorkoutControllerTests
{
    // Gets all workouts (positive response)
    [Fact]
    public void Test1()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        mockRepo.GetAll().Returns(new List<Workout> { new Workout() });
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.GetAllWorkouts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var workouts = Assert.IsAssignableFrom<IEnumerable<Workout>>(okResult.Value);
    }

    // Gets all workouts (negative response)
    [Fact]
    public void Test2()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        mockRepo.GetAll().Returns((IEnumerable<Workout>)null);
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.GetAllWorkouts();

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No Workouts found", notFoundResult.Value);
    }


    // Add a new workout (positive response)
    [Fact]
    public void Test3()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        var controller = new GymWorkoutController(mockRepo);
        var newWorkout = new Workout { WorkoutID = 1, WorkoutName = "Test Workout" };

        // Act
        var result = controller.AddWorkout(newWorkout);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(newWorkout, createdAtActionResult.Value);
    }

    // Add a new workout (negative response - null workout)
    [Fact]
    public void Test4()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.AddWorkout(null);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    //Update a workout (positive response)
    [Fact]
    public void Test5()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        var existingWorkout = new Workout { WorkoutID = 1, WorkoutName = "Existing Workout" };
        mockRepo.GetById(1).Returns(existingWorkout);
        var controller = new GymWorkoutController(mockRepo);
        var updatedWorkout = new Workout { WorkoutID = 1, WorkoutName = "Updated Workout" };

        // Act
        var result = controller.UpdateWorkout(1, updatedWorkout);

        // Assert
        Assert.IsType<NoContentResult>(result);
        mockRepo.Received(1).Update(Arg.Is<Workout>(w => w.WorkoutName == "Updated Workout"));
    }



    //Update a workout (negative response - invalid workout data)
    [Fact]
    public void Test6()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        var controller = new GymWorkoutController(mockRepo);
        var updatedWorkout = new Workout { WorkoutID = 2, WorkoutName = "Updated Workout" };

        // Act
        var result = controller.UpdateWorkout(1, updatedWorkout);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }



    //Delete a workout (positive response)
    [Fact]
    public void Test7()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        var existingWorkout = new Workout { WorkoutID = 1, WorkoutName = "Existing Workout" };
        mockRepo.GetById(1).Returns(existingWorkout);
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.RemoveWorkout(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }



    //Delete a workout (negative response - workout not found)
    [Fact]
    public void Test8()
    {
        // Arrange
        var mockRepo = Substitute.For<IWorkoutRepository>();
        mockRepo.GetById(1).Returns((Workout)null); // Simulate workout not found
        var controller = new GymWorkoutController(mockRepo);

        // Act
        var result = controller.RemoveWorkout(1);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    }

}
