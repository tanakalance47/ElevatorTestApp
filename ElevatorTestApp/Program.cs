using ElevatorTestApp.Helpers;
using ElevatorTestApp.Services.Implementation;
using ElevatorTestApp.Services.Interface;

Console.WriteLine("Running Elevator Simulation" + "\n");

// Creating a building with 16 floors and 4 elevators
IElevatorService service = new ElevatorService(16, 4);

try
{
	// Calling an elevator to floor 6 with 1 passenger
	service.CallElevator(6, 1, new List<int>() { 4 });

	// Calling an elevator to floor 3 with 2 passengers
	service.CallElevator(3, 2, new List<int>() { 2, 1 });

	// Calling an elevator to floor 1 with 8 passengers
	service.CallElevator(1, 8, new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2 });

	// Calling an elevator to floor 12 with 8 passengers
	service.CallElevator(12, 8, new List<int>() { 8, 11, 10, 9, 8, 7, 6, 5 });

	// Calling an elevator to floor 4 with 8 passengers
	service.CallElevator(3, 4, new List<int>() { 8, 11, 9, 6 });

	// Displaying the elevator status
	service.DisplayElevatorStatus();


    int floor = InputHelper.GetFloor();
	int passengers = InputHelper.GetPassengers();
	List<int> stops = InputHelper.GetStops(passengers);

	Console.WriteLine("\n Calling elevator");
	service.CallElevator(floor, passengers, stops);

	// Displaying the elevator status
	service.DisplayElevatorStatus();

}
catch (Exception ex)
{
	Console.WriteLine(ex.Message.ToString());
}

Console.ReadLine();