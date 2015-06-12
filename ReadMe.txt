Tiers - .NET Application Template
---------------------------------
The Tiers project is a quick start template for creating new .NET projects with different tiers/layers.
When testing the UIs, you should run the WebApi project first and not close that Visual Studio instance.
---------------------------------

The following is a description of each project in the solution:

Tiers.Core:
  - Contains shared core classes and functionality, including:
	- DTOs for transferring between layers / UIs
    - Models for common objects - MVVM User model shared between UIs, logging, etc
	- Constants and helper extension methods

Tiers.Data:
  - Abstracts the data persistence layer (e.g., ADO.NET, Entity Framework, etc), for simplicity only one basic POCO repository is used

  * OPTIONAL DYNAMIC DATABASE CONFIGURATION EXAMPLE:
  - You can dynamically determine which underlying data persistence layer is used by the data and domain by adding data projects, such as:

		Tiers.Data.Oracle (Optional): 
		- Use an assembly name and namespace that is different from the project name, but same as other data projects, e.g.: Tiers.Data.Persistance
		- Contains an EF Model.edmx and POCO objects that maps to an Oracle database

		Tiers.Data.SqlServer (Optional):
		- Use an assembly name and namespace that is different from the project name, but same as other data projects, e.g.: Tiers.Data.Persistance
	    - Contains an EF Model.edmx and POCO objects that maps to a SQL database
		
		- Use a local SQL server for faster development, and create an After Build event to copy the .mdf and .ldf from 
		  Tiers.Data.SqlServer to each App_Data or TargetDir bin directory and make all database changes in Tiers.Data.SqlServer

		To switch between data persistence layers types:
		- Ensure that Tiers.Data is referencing only Tiers.Data.Oracle or Tiers.Data.SqlServer, depending on which you want to use
		- Ensure the Entities config entry in all web.config and app.config projects you plan to use are set to the same Model.edmx

Tiers.Domain:
  - Domain specific objects, logic, business rules, etc, but not meant to be a full DDD design

Tiers.Service (Optional layer):
  - Routes requests from consumers (UI, API, Tests) to/from the domain layer utilizing DTOs, facilitating SOA if desired
  - Logs events, e.g. search requests via a logging mechanism, such as log4net (this has been omitted for simplicity)

Tiers.Tests:
  - Unit tests focused on exercising the Service, Domain, and Data layers

Tiers.WebApi
  - Provides RESTful access to the service layer, useful for native apps or client-side (AJAX) calls and frameworks like AngularJS

Tiers.WebApi.Tests
  - Unit tests focused on the WebApi layer

Tiers.Web*(UIs):
  - Examples of different types of consumers - WebAngular, WebConsole, WebForms, WebMvc, WinForms, WPF

---------------------------------

6/11/2015: Initial Release - v1.0
