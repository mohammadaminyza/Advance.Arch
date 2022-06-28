# Advance.Arch
Advance Arch Implimentation For Saapp

**Notes:**

 - Keep Domainservice simple and if it's complicated reak it to smaller
    methods
 - Do not foget about application service things that relate to use
    case like insert list or ... use it in application service
 - Kiss: **Always Keep It Simple Stupid**

**Some Of Business Logic Handlation Place:**

 - **Simple business logic that never gonna change:** put it in entity method

 - **Complex business logic or business that might change:** put it in domain model

 - **ViewModels:** which responsible for model for view.

 - **Controllers:** which is thin and responsible for application flow.

 - **Simple business:** logic such as required field can exist as attribute
   within entity framework model or ViewModels.

 - **Complex business:** logic such as place order, booking ticket are promoted to be its own class such as PlaceOrderOperation or
   PlaceOrderCommand.

 - **Simple query:** logic might be inside the Controller or short extension method to DbSet<Entity> type.
 
 - **Complex Query** also promoted to its own class such as GetMostPorpularProductsQuery assuming that the query is complex.

 - **Infrastructure** components may be extension to Entity Framework or MVC components such as ActionFilter, CustomRoute, CustomTemplate or
   its own classes such as EncyptionHelpers etc.
