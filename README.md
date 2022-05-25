# Buying Frenzy Backend API using .NET Core

## Pre requirements
Visual Studio 2019/ VS code

.Net Core SDK 5 

C# extension for VS Code

## How to Run
Open solution in Visual Studio 2019/ VS Code

Set API project as start-up project and build the project 

Run the project using this command:  
```sh 
dotnet run
```

## Tools used

.Net Core 5

Sqlite for RDBMS

C# 

Entity Framework Core (ORM)

MSTest Framework for unit Testing

AutoMapper

This repository contains controllers which are dealing with Restaurants and Users data to create Food Delivery System. You can GET/POST them as required in the questions.

## Versions
``` https://localhost:44382/swagger/index.html ```


## API Interfaces

## Get All Restaurants those are open on certain time of the day
``` https://localhost:5001/api/Restaurants?day=Sun&Time=15:45 ```
``` javascript
    [
    {
	"type": GET
	"url": "/Restaurants",
	"params" : 
	      {		
		  "day": "Sun", 
		  "time": "15:45" // It's in 24 hours time i.e 3:45 pm		
	      }
     }
   ]
   ```


## Get top restaurants that have more or less than x number of dishes within a price range, ranked alphabetically.
``` https://localhost:5001/TopRestaurants?query=>&startPrice=40&endPrice=100&noOfDishes=5 ```


``` javascript
    [
    {
	"type": GET
	"url": "/TopRestaurants",
	"params":
	      {
		  "query": ">", 
		  "startPrice": 40, 
		  "endPrice": 100,	
		  "noOfDishes": 5,	
	      }
    }
   ]
   ```

	
## Get restaurant by name
``` https://localhost:5001/api/Restaurants/Mark's American Cuisine ```


## Search dishes by name
``` https://localhost:5001/RestaurantMenu?dishName=coffee ```
``` javascript 
   {
	"type": GET
	"url": "/RestaurantMenu",
	"params": 
		{		
			"dishName": "coffee" //pass any search term for dishes
		}
   }
```


## Purchase request by user for particular dish from particular restaurant (POST)
``` https://localhost:5001/api/Purchase ```
``` javascript
   {
       "userid": 2,
       "restaurantName": "024 Grille", //Exact name of a restaurant should be passed
       "DishName": "Sweetbreads" //Exact dish name should be passed
   }
```




