# AleksandarTerter-PharmaLex.ParkingLot

## Task: Build a parking management system
	1.	Implement a RESTful API service for calculating charges for vehicles that are using a parking lot. The service must be able to calculate the overall time the vehicle was parked, and the final price for the parking upon exiting the parking lot.
	2.	Implement a UI portal that allows users to find a vehicle by the vehicle registration number or to display all vehicles that are currently using the parking lot. The results should include: the vehicle registration number, time of entry, current accumulated charge, calculated discount.

## Additional information
	1.	There are 3 categories of vehicles:
		a.	Category A - cars/motorcycles
		b.	Category B - vans
		c.	Category C - bus/trucks
	2.	Daily charges apply between 08:00 and 18:00. 
	3.	Overnight charges apply between 18:00 and 08:00.
	4.	Charges according to the vehicle category:
		a.	Category A - daily charge 3 leva per hour, overnight charge 2 leva per hour
		b.	Category B - daily charge 6 leva per hour, overnight charge 4 leva per hour
		c.	Category C - daily charge 12 leva per hour, overnight charge 8 leva per hour
	5.	Discounts
		d.	Silver - 10% discount
		e.	Gold - 15% discount
		f.	Platinum - 20% discount
	6.	The parking capacity is 200 parking spaces. A vehicle may take up more than 1 space depending on the category:
		a.	Category A - 1 space
		b.	Category B - 2 spaces
		c.	Category C - 4 spaces

## Implementation
	1. The backend must use C# (.NET)
	2. The architecture, additional features and the UI of the app are entirely up to the developer
	3. The API service must expose the following endpoints:
		-	Check number of available spaces in the parking lot
		-	Check current accumulated charge for a vehicle in the parking lot by its registration number
		-	Parking entry
			o	Register the vehicle 
			o	Check for discounts
		-	Parking exit
			o	Unregister the vehicle
			o	Calculate charges for the parking
