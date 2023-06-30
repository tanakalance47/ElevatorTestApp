using ElevatorTestApp.Enums;
using ElevatorTestApp.Models;
using ElevatorTestApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTestApp.Services.Implementation
{
	public class ElevatorService : IElevatorService
	{
		public int NumFloors { get; set; }
		private List<Elevator> elevators;

		public ElevatorService(int numFloors, int numElevators)
		{
			NumFloors = numFloors;
			elevators = new List<Elevator>();
			for (int i = 0; i < numElevators; i++)
			{
				elevators.Add(new Elevator() { Id = i + 1, MaxOccupancy = 8});
			}
		}

		/// <summary>
		/// Calls the elevator.
		/// </summary>
		/// <param name="floor">The floor.</param>
		/// <param name="passengers">The passengers.</param>
		/// <param name="stops">The stops.</param>
		public void CallElevator(int floor, int passengers, List<int> stops)
		{
			try
			{
				if (floor < NumFloors)
				{
					Elevator closestElevator = null;

					closestElevator = GetAvailableElevator(floor, passengers);

					if (closestElevator != null)
					{
						closestElevator.MoveToFloor(floor);
						closestElevator.AddPassengers(passengers);

						stops = stops.OrderBy(x => x).ToList();

						int currentFloor = closestElevator.CurrentFloor;

						if (currentFloor < stops.Min())
						{
							stops = stops.OrderByDescending(x => x).ToList();
						}

						foreach (int stop in stops)
						{
							closestElevator.MoveToFloor(stop);
							closestElevator.RemovePassenger(1);
						}
					}
					else
					{
						Console.WriteLine("All elevators are unavailable. Please wait.");
					}
				}
				else
				{
					Console.WriteLine($"The elevators only go up to floor: {NumFloors}.");
				}	
			}
			catch (Exception)
			{
				throw;
			}		
		}

		/// <summary>
		/// Displays the elevator status.
		/// </summary>
		public void DisplayElevatorStatus()
		{
			try
			{
				Console.WriteLine("Current elevator Status:");
				Console.WriteLine("------------------------");

				foreach (Elevator elevator in elevators)
				{
					Console.WriteLine($"Elevator No: {elevator.Id}");
					Console.WriteLine($"Current floor: {elevator.CurrentFloor}");
					Console.WriteLine($"Occupancy: {elevator.PassengerCount}");
					Console.WriteLine($"Direction: {elevator.CurrentDirection}");
					Console.WriteLine($"Moving: {elevator.IsMoving}" + "\n");
				}
			}
			catch (Exception)
			{
				throw;
			}			
		}

		/// <summary>
		/// Gets the available elevator.
		/// </summary>
		/// <param name="floor">The floor.</param>
		/// <param name="people">The people.</param>
		/// <returns></returns>
		private Elevator GetAvailableElevator(int floor, int people) 
		{
			Elevator closestElevator = new Elevator();

			try
			{
				int closestDistance = int.MaxValue;

				foreach (Elevator elevator in elevators)
				{
					int distance = Math.Abs(elevator.CurrentFloor - floor);
					if (!elevator.IsMoving && distance < closestDistance)
					{
						closestElevator = elevator;
						closestDistance = distance;
					}
				}

				int availableSpace = closestElevator.MaxOccupancy - closestElevator.PassengerCount;

				if (people > availableSpace) 
				{ 
				    closestElevator = elevators.Where(X => X.PassengerCount < people).First();
				}			
			}
			catch (Exception)
			{

				throw;
			}

			return closestElevator;
		}
	}
}