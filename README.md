# ASP.NET MVC Project

This is an ASP.NET MVC Project built on .NET 8.

## Project Structure

The project follows a structured folder organization, which includes:

- **Controllers**: 
  - `HomeController`: Manages the flow of the application and handles user requests.

- **Services**: 
  - `HttpService`: A service for handling HTTP requests.
  - `TicketMasterService`: A service class specifically for interactions with the TicketMaster API.

- **Models**: 
  - `Attraction`: Represents an attraction entity.
  - `AttractionEvent`: Represents an event related to an attraction.
  - `ExternalLinks`: Contains external link information for attractions.
  - `Image`: Represents images associated with attractions.

- **ResponseDtos**: 
  - Contains Data Transfer Objects (DTOs) for responses related to getting attractions and events.

- **ViewModel**: 
  - Combines models to display attractions and related events together.

- **Views**: 
  - **Home**: 
    - `Index.cshtml`: The main view for displaying attractions.
    - `AttractionDetails.cshtml`: Details view for specific attractions.
  - **Shared**: 
    - `_Card.cshtml`: Partial view for rendering attraction cards.
    - `_EventCard.cshtml`: Partial view for rendering event cards.

- **appSettings.json**: 
  - Contains configuration settings such as `apiKey`, `maxResultSize`, and `baseUrl`.

## Development Notes

Spent approximately **7 hours** on the project in one session.

### Functionality

- The application is fully functional.
- Basic error handling and exception handling have been implemented where necessary.
- Further refactoring may be needed for in-depth error and exception handling.

### Objectives

Given the limited time duration, the primary objectives were:

1. **Make the App Work**: Ensure that the application functions correctly.
2. **Code Structure**: Aim to structure the code to be loosely coupled, manageable, and to separate concerns effectively.

### Additional Information

- **Logging**: Not included in this project.
- **Unit Testing**: Not included in this project.

## Acknowledgements

Thanks for reviewing the project! Any feedback or contributions are welcome.
