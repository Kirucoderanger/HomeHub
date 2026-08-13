# HomeHub QA Test Plan

## Authentication

| Test | Expected Result | Status |
|---|---|---|
| Register with valid information | Account is created | Pass |
| Register with invalid email | Validation message appears | Pass |
| Register with weak password | Identity validation message appears | Pass |
| Register with mismatched passwords | Validation message appears | Pass |
| Login with valid credentials | User reaches dashboard | Pass |
| Login with invalid credentials | Error message appears | Pass |
| Logout | User is redirected to login | Pass |
| Access dashboard while logged out | User is redirected to login | Pass |

## Property CRUD

| Test | Expected Result | Status |
|---|---|---|
| Create property | Property is stored | Pass |
| View property | Property information appears | Pass |
| Edit own property | Changes are saved | Pass |
| Delete own property | Property is removed | Pass |
| Edit another user's property | Operation is denied | Pass |
| Delete another user's property | Operation is denied | Pass |

## Images

| Test | Expected Result | Status |
|---|---|---|
| Add image | Image appears with property | Pass |
| Replace image | Previous image is replaced | Pass |
| Remove image | Image is removed | Pass |

## Search and Filtering

| Test | Expected Result | Status |
|---|---|---|
| Search by property information | Matching properties appear | Pass |
| Apply filters | Results are filtered | Pass |
| Combine filters | Matching results appear | Pass |
| Clear filters | Default results return | Pass |

## Favorites

| Test | Expected Result | Status |
|---|---|---|
| Add favorite | Property appears in favorites | Pass |
| Remove favorite | Property disappears from favorites | Pass |
| Duplicate favorite | Duplicate is prevented | Pass |

## Authorization

| Test | Expected Result | Status |
|---|---|---|
| Anonymous dashboard access | Redirect to login | Pass |
| Property owner edits own property | Allowed | Pass |
| Property owner deletes own property | Allowed | Pass |
| User edits another user's property | Denied | Pass |
| User deletes another user's property | Denied | Pass |
| PropertyOwner role assigned during creation | Role is available | Pass |

## Responsive Design

Test the application on:

- Desktop
- Tablet
- Smartphone

Verify:

- Navigation
- Forms
- Property cards
- Images
- Buttons
- Dashboard
- Search/filter controls

## Accessibility

Verify:

- Keyboard navigation.
- Form labels.
- Validation messages.
- Button accessibility.
- Image alternative text.
- Heading hierarchy.
- Color contrast.
- Responsive layout.
