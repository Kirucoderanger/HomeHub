# HomeHub

HomeHub is a .NET Blazor web application for discovering, managing, and saving property listings.

The application was developed as a .NET/Blazor course project and demonstrates authentication, authorization, CRUD operations, property images, search and filtering, favorites, role-based functionality, responsive design, and cloud database integration.

---

## 1. Target Audience

HomeHub is designed for users who want to:

- Browse available properties.
- Search and filter property listings.
- View property details and images.
- Save properties as favorites.
- Create and manage their own property listings.
- Replace or remove property images.
- Securely manage their account.

Property owners can create and manage their own listings while users are prevented from modifying properties that belong to other users.

---

## 2. Technologies

HomeHub was developed using:

- .NET 10
- Blazor
- C#
- ASP.NET Core Identity
- Entity Framework Core
- Microsoft SQL Server / Azure SQL
- Bootstrap
- HTML5
- CSS3
- GitHub
- Azure

---

## 3. Main Features

### Authentication

Users can:

- Register an account.
- Log in securely.
- Log out.
- Use a "Remember me" option.
- Receive validation and authentication error messages.
- Access protected pages only after authentication.

### User Dashboard

Authenticated users receive a personalized dashboard containing:

- Welcome message.
- Registration confirmation.
- Property discovery options.
- User property management.
- Favorite property access.

### Property Management

The application implements complete CRUD functionality:

- Create properties.
- Read/view properties.
- Update properties.
- Delete properties.

Property owners can modify only their own properties.

### Property Images

Users can:

- Add property images.
- View property images.
- Replace an existing image.
- Remove an image.

### Search and Filtering

Users can search and filter properties to find relevant listings.

The application also provides a clear/reset filters option.

### Favorites

Authenticated users can save properties as favorites and manage their saved properties.

### Authorization

The application uses ASP.NET Core authorization and Identity roles to protect functionality.

Property ownership is enforced so that users cannot modify another user's property.

The `PropertyOwner` role is connected to property creation.

---

## 4. Security

HomeHub uses ASP.NET Core Identity for authentication and authorization.

Security features include:

- Password hashing through ASP.NET Core Identity.
- Authentication cookies.
- Authorized dashboard access.
- Ownership-based property authorization.
- Role-based authorization.
- Protected CRUD operations.
- Secure logout.
- Anti-forgery protection.

---

## 5. Database

Entity Framework Core is used for database access.

The application uses Azure SQL for cloud database hosting.

Identity data and application data are stored in the database through Entity Framework Core migrations.

---

## 6. User Guide

### Register

1. Open HomeHub.
2. Select **Create an account**.
3. Enter your first name.
4. Enter your last name.
5. Enter your email address.
6. Create a valid password.
7. Confirm the password.
8. Select **Create account**.

After successful registration, the user is authenticated and redirected to the dashboard.

### Login

1. Open the Sign In page.
2. Enter your email address.
3. Enter your password.
4. Optionally select **Remember me**.
5. Select **Sign in**.

After successful authentication, the user is redirected to the dashboard.

### Dashboard

The dashboard provides access to the main HomeHub functionality.

Authenticated users can access:

- Properties
- My Properties
- Favorites
- Other protected functionality

### Managing Properties

Property owners can create a property and provide its information and image.

Owners can subsequently:

- View their property.
- Edit their property.
- Replace its image.
- Remove its image.
- Delete their property.

Users cannot modify properties owned by other users.

### Searching Properties

Users can enter search criteria and apply filters.

Use **Clear/Reset Filters** to return to the default property listing.

### Favorites

Authenticated users can add properties to their favorites and remove them when they are no longer interested.

### Logout

Select **Logout** to securely end the current authentication session.

---

## 7. Accessibility

HomeHub was developed with accessibility in mind.

The application uses:

- Semantic HTML elements.
- Associated form labels.
- Validation messages.
- Keyboard-accessible controls.
- Descriptive button text.
- Accessible form inputs.
- Appropriate ARIA attributes where necessary.
- Responsive layouts.
- Visible user feedback.
- Bootstrap accessibility features.

The application is intended to follow WCAG 2.1 Level AA principles.

---

## 8. Responsive Design

The interface is designed to work across:

- Desktop computers.
- Laptops.
- Tablets.
- Smartphones.

Bootstrap responsive grid classes and responsive CSS are used throughout the application.

---

## 9. Error Handling and User Feedback

The application provides feedback for important operations including:

- Registration errors.
- Invalid login attempts.
- Password validation failures.
- Property validation errors.
- Unauthorized property operations.
- Successful registration.
- Authentication state changes.
- Property CRUD operations.

Protected resources redirect unauthorized users to the login page.

---

## 10. Development Workflow

The project source code is managed using GitHub.

Development tasks are organized using a Trello project board.

The workflow includes:

1. Planning.
2. Task assignment.
3. Development.
4. Testing.
5. Bug fixing.
6. Code review.
7. Deployment.

---

## 11. Quality Assurance

The application is tested during development for:

- Authentication.
- Registration.
- Login.
- Logout.
- Authorization.
- Property creation.
- Property editing.
- Property deletion.
- Property image management.
- Search.
- Filtering.
- Favorites.
- Responsive layouts.
- Validation.
- Error handling.

Browser-based testing is performed on the application's major workflows.

---

## 12. Deployment

HomeHub is designed for cloud deployment using Azure.

The application uses Azure SQL for persistent cloud database storage.

The production deployment should be tested after deployment to verify:

- Authentication.
- Database connectivity.
- CRUD operations.
- Authorization.
- Image functionality.
- Search and filtering.
- Favorites.
- Responsive behavior.

---

## 13. Project Management

The development team uses:

- GitHub for source-code management.
- Trello for project planning and task management.

The Trello board is used to track development work from planning through completion.

---

## 14. Project Goals

The primary goals of HomeHub are to demonstrate:

- Proficient understanding of .NET Blazor.
- Secure user authentication.
- Authorization and role-based access.
- Entity Framework Core database development.
- CRUD functionality.
- Responsive and accessible UI development.
- Cloud database integration.
- Quality assurance.
- Professional project organization.
