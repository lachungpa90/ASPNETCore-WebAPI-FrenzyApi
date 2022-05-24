**ASP.NET Core Web API using Entity Framework Core**

**Pre requirements**
•	Visual Studio 2019/ VS code
•	.Net Core SDK 5 
•	C# extension for VS Code

**How to Run**
•	Open solution in Visual Studio 2019/ VS Code
•	Set API project as start-up project and build the project 
•	Run the project using command dotnet run

**Tools used**
•	.Net Core 5
•	Sqlite for RDBMS
•	C# 
•	Entity Framework Core (ORM)
•	MSTest Framework for unit Testing
•	AutoMapper

This repository contains controllers which are dealing with Restaurants and Users data to create Food Delivery System. You can GET/POST them as required in the questions.

**Versions**
https://localhost:44382/swagger/index.html








**API Interfaces **

**Get All Restaurants those are open on certain time of the day**
https://localhost:5001/api/Restaurants?day=Sun&Time=15:45











**Get top restaurants that have more or less than x number of dishes within a price range, ranked alphabetically. **
https://localhost:5001/TopRestaurants?query=%3E&startPrice=40&endPrice=100&noOfDishes=5











	
**Get restaurant by name**
https://localhost:5001/api/Restaurants/Mark's American Cuisine











**Search dishes by name**
https://localhost:5001/RestaurantMenu?dishName=coffee











	

**Purchase request by user for particular dish from particular restaurant (POST)**
https://localhost:5001/api/Purchase
{
"userid":2,
"restaurantName":"024 Grille",
"DishName":"Sweetbreads"
}







# ASP.NET Core WebApi Sample with HATEOAS, Versioning & Swagger

In this repository I want to give a plain starting point at how to build a WebAPI with ASP.NET Core.

This repository contains a controller which is dealing with FoodItems. You can GET/POST/PUT/PATCH and DELETE them.

Hope this helps.

See the examples here: 

## Versions

``` http://localhost:29435/swagger ```

![ASPNETCOREWebAPIVersions](./.github/versions.jpg)

## GET all Foods

``` http://localhost:29435/api/v1/foods ```

![ASPNETCOREWebAPIGET](./.github/get.jpg)

## GET single food

``` http://localhost:29435/api/v1/foods/2 ```

![ASPNETCOREWebAPIGET](./.github/getSingle.jpg)

## POST a foodItem

``` http://localhost:29435/api/v1/foods ```

```javascript
  {
      "name": "Lasagne",
      "type": "Main",
      "calories": 3000,
      "created": "2017-09-16T17:50:08.1510899+02:00"
  }
```

![ASPNETCOREWebAPIGET](./.github/post.jpg)

## PUT a foodItem

``` http://localhost:29435/api/v1/foods/5 ```

``` javascript
{
    "name": "Lasagne2",
    "type": "Main",
    "calories": 3000,
    "created": "2017-09-16T17:50:08.1510899+02:00"
}
```

![ASPNETCOREWebAPIGET](./.github/put.jpg)


## PATCH a foodItem

``` http://localhost:29435/api/v1/foods/5 ```

``` javascript
[
  { "op": "replace", "path": "/name", "value": "mynewname" }
]
```

![ASPNETCOREWebAPIGET](./.github/patch.jpg)

## DELETE a foodItem

``` http://localhost:29435/api/v1/foods/5 ```


![ASPNETCOREWebAPIGET](./.github/delete.jpg)



