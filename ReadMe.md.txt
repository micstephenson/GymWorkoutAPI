# GYM WORKOUT API
===================
This API provides endpoints to manage gym workouts, personal trainer details, and session details including creating, retrieving, updating, and deleting records.

## Description
It is built using ASP.NET Core and follows CRUD principles.
The API uses Entity Framework Core for data access and SQL Server as the database.
It also includes Swagger for API documentation and testing.
To run the API, ensure you have .NET 8.0 SDK installed and execute the following commands:


## Getting Started
### How to Run the API Locally
1. Ensure you have .NET 8.0 SDK installed on your machine.
2. Clone the repository to your local machine.
3. Open using Visual Studio.
4. Click the "Run" button or press F5 to start the application.

## FEATURES
* Create Workouts, Trainers
* Assign those Trainers and Workouts to Gym Sessions
* Retrieve Workouts, Trainers, and Sessions
* Update Workouts and Sessions
* Delete Workouts, Trainers, and Sessions



## API Endpoints
**Workouts**
  - `POST /api/workouts`: Create a new workout.
  - `GET /api/workouts`: Retrieve all workouts.
  - `PUT /api/workouts/{id}`: Update a specific workout by ID.
  - `DELETE /api/workouts/{id}`: Delete a specific workout by ID.


**Trainers**
  - `POST /api/trainers`: Create a new trainer.
  - `GET /api/trainers`: Retrieve all trainers.
  - `DELETE /api/trainers/{id}`: Delete a specific trainer by ID.

