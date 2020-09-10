# Contacts Management

This is an 'Contacts Management' web application developed using MVC 4, Web API 2, DI with Unity Container, Generic Repository Pattern and Entity Framework.

Functionality Covered :

- Listing the contacts.
- Adding contact
- Edit contact 
- Delete a contact

Application is divided into two parts, ContactManagement (MVC application) and WebAPI which works as service for database operations.

Service is using DI with unity container and Generic Repository Pattern. For database related operations Entity Framework is used.

Additional script 'Alertify JS' is used for showing alerts while doing data operations.


List of API calls :
  
- Get all contacts =       [GET]				    [/api/ContactMasters]
- Get a contact by ID =	   [GET]				    [/api/ContactMasters/id]
- Create a new contact =   [POST]				    [/api/ContactMasters]
- Update a contact =       [PUT]				    [/api/ContactMasters/id]
- Delete a contact	=      [DELETE]			    [/api/ContactMasters/id]


Suggested Modifications :
- Please check key "DBModel" in WebAPI/Web.config to change the database connection.
- Inside "ContactManagement/GlobalVariables.cs" change webApiClient.BaseAddress. This will be address of web API application.
