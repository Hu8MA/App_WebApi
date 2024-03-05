# Project Report

## Overview
This project is a web application API developed using the ASP.NET Core API framework with .NET 8.0. It is designed to address specific enterprise needs, implementing the MVVM architecture alongside application architecture concepts and SOLID principles. The application includes global handling middleware, image upload functionality with validation for image size and type, two user roles (User and Admin), and dynamic PDF generation using the DinkToPdf library.

## Deficiencies
Despite the successful implementation of various features, there are some deficiencies that need to be addressed:

1. **Authentication and Authorization**: The project lacks complete implementation for handling authentication and authorization processes.

2. **Testing**: Test files for unit testing and integration testing have not been created, which is crucial for ensuring the reliability and robustness of the application.

3. **Logging Feature**: There is no implementation for logging, which is essential for tracking and debugging purposes.

## Determinants
- **Development Environment**: The project is built to run on the .NET 8 development environment.

## Future Considerations
To enhance the project and address the deficiencies mentioned above, the following steps can be taken:

1. **Authentication and Authorization**: Implement authentication mechanisms such as JWT (JSON Web Tokens) for user authentication and authorization.

2. **Testing**: Develop test files for both unit testing and integration testing to ensure the stability and correctness of the application.

3. **Logging Feature**: Integrate logging functionality using a logging framework such as Serilog or NLog to capture and track application events and errors.

## Installation and Usage
1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Ensure you have the required dependencies installed (e.g., .NET 8 runtime).
4. Configure the application settings as needed (e.g., database connection strings).
5. Build and run the application.
6. Access the API endpoints using a tool like Postman or your preferred REST client.

 
