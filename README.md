## Rectangle Assignment
Overview
This task is a web application that allows users to draw and resize a rectangle in an SVG format. The application fetches initial dimensions from a backend API and saves the dimensions and perimeter whenever the rectangle is resized. The project is built using React for the frontend and .NET for the backend.

# Features
- Fetch initial rectangle dimensions from a backend API.
- Resize the rectangle using mouse drag.
- Calculate and display the perimeter of the rectangle.
- Save rectangle dimensions and perimeter in the backend on resize completion.
- Handle edge cases, including validation for dimension values.

# Technologies Used
- Frontend: ReactJS.
- Backend: .NET 8 Web API
- Database: SQL Server
- Libraries used for Frontend: React-Query, react-resizable.

# Getting Started
### Prerequisites
Node.js (for the frontend)
.NET 8 SDK (for the backend)
SQL Server (if applicable)

# Installation
### 1. Clone repository
- git clone https://github.com/GentiSe/RectangleAssignment.git
- cd RectangleAssignment
### 2. Navigate to the ClientApp Directory
- cd clientapp
- npm install
### 3. Set Up the Backend
- Open the backend project in Visual Studio or your preferred IDE.
- Ensure that the database is set up correctly.
- Update connection strings as necessary.
### 4. Database Setup
1. Open SQL Server Management Studio (SSMS).
2. Connect to your SQL Server instance.
3. Open the `dbScript` file, inside the project.
4. Execute the script in sql server to create the necessary tables and structures.
5. Change connection string in appsettings.json.

### Note: Please update the base URL for the APIs used in App.js. 
### 5. Run the Application
- Start the backend server.
- dotnet run
- In a separate terminal, navigate to the clientapp folder and start the frontend.
- npm start

# Usage
- Click the "Fetch Initial Dimensions" button to load the rectangle's dimensions.
- Resize the rectangle by dragging the corners.
- The perimeter will update automatically and be posted to the backend.
- The first item in the backend will be fetched always.

# API Endpoints
- GET /api/v1/rectangle-dimensions: Fetch initial rectangle dimensions.
- POST /api/v1/rectangle-dimensions: Save rectangle dimensions and perimeter.
