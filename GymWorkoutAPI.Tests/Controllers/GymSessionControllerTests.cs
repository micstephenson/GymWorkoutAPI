using GymWorkoutAPI.Controllers;
using GymWorkoutAPI.Data;
using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Repositories;
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
        var mockRepo = Substitute.For<ISessionRepository>();
        mockRepo.GetAll().Returns(new List<GymSessions> { new GymSessions() });
        var controller = new GymSessionController(mockRepo);

        // Act
        var result = controller.GetAllSessions();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var sessions = Assert.IsAssignableFrom<IEnumerable<GymSessions>>(okResult.Value);
    }

    [Fact]
    public void GetAllSessions_NegativeResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ISessionRepository>();
        mockRepo.GetAll().Returns((IEnumerable<GymSessions>)null);
        var controller = new GymSessionController(mockRepo);

        // Act
        var result = controller.GetAllSessions();

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No Sessions found", notFoundResult.Value);
    }

    [Fact]
    public void AddSession_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ISessionRepository>();
        var controller = new GymSessionController(mockRepo);
        var newSession = new GymSessions { SessionID = 1, SessionDate = DateTime.Now, TrainerID = 1, OverallDuration = 60 };

        // Act
        var result = controller.AddSession(newSession);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(newSession, createdAtActionResult.Value);
    }

    [Fact]
    public void AddSession_NegativeResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ISessionRepository>();
        var controller = new GymSessionController(mockRepo);
        // Act
        var result = controller.AddSession(null);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Session data is null.", badRequestResult.Value);
    }

    [Fact]
    public void GetSessionWorkouts_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ISessionRepository>();
        mockRepo.GetSessionWorkoutDetails(1).Returns(new List<SessionWorkoutDetailDto> { new SessionWorkoutDetailDto() });
        var controller = new GymSessionController(mockRepo);
        // Act
        var result = controller.GetSessionWorkouts(1);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var sessionWorkouts = Assert.IsAssignableFrom<IEnumerable<SessionWorkoutDetailDto>>(okResult.Value);
    }

    [Fact]
    public void GetSessionWorkouts_NegativeResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ISessionRepository>();
        mockRepo.GetSessionWorkoutDetails(1).Returns((IEnumerable<SessionWorkoutDetailDto>)null);
        var controller = new GymSessionController(mockRepo);
        // Act
        var result = controller.GetSessionWorkouts(1);
        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Session with id 1 not found", notFoundResult.Value);
    }

    [Fact]
    public void AddWorkoutsToSession_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ISessionRepository>();
        mockRepo.GetById(1).Returns(new GymSessions { SessionID = 1, SessionDate = DateTime.Now, TrainerID = 1, OverallDuration = 60 });
        var controller = new GymSessionController(mockRepo);
        var sessionWorkout = new SessionWorkout { SessionID = 1, WorkoutID = new List<int> { 1, 2 } };
        // Act
        var result = controller.AddWorkoutsToSession(sessionWorkout);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Workouts added to session successfully.", okResult.Value);
    }

    [Fact]
    public void AddWorkoutsToSession_NegativeResponse_InvalidData()
    {
        // Arrange
        var mockRepo = Substitute.For<ISessionRepository>();
        var controller = new GymSessionController(mockRepo);
        // Act
        var result = controller.AddWorkoutsToSession(null);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Invalid data.", badRequestResult.Value);
    }

    [Fact]
    public void DeleteSession_PositiveResponse()
    {
        // Arrange
        var mockRepo = Substitute.For<ISessionRepository>();
        mockRepo.GetById(1).Returns(new GymSessions { SessionID = 1, SessionDate = DateTime.Now, TrainerID = 1, OverallDuration = 60 });
        var controller = new GymSessionController(mockRepo);
        // Act
        var result = controller.RemoveSession(1);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Session deleted successfully.", okResult.Value);
    }
}
