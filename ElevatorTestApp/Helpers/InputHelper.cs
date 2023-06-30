using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTestApp.Helpers
{
	public static class InputHelper
	{
		/// <summary>
		/// Gets the floor.
		/// </summary>
		/// <returns></returns>
		public static int GetFloor()
		{
			int floor = 0;
			Console.Write("Call Elevator to floor: ");
			string? destinationFloor = Console.ReadLine();
			floor  = int.Parse(destinationFloor);
			return floor;
		}

		/// <summary>
		/// Gets the passengers.
		/// </summary>
		/// <returns></returns>
		public static int GetPassengers()
		{
			int passengers = 0;
			Console.Write("Number of passengers: ");
			string? passengersCount = Console.ReadLine();
			passengers = int.Parse(passengersCount);
			return passengers;
		}

		/// <summary>
		/// Gets the stops.
		/// </summary>
		/// <param name="passengers">The passengers.</param>
		/// <returns></returns>
		public static List<int> GetStops(int passengers)
		{
			List<int> stops = new List<int>();

			for (int i = 0; i < passengers; i++)
			{
				Console.Write($"Enter stop {i + 1}: ");
				string? stopInput = Console.ReadLine();
				int stop = int.Parse(stopInput);
				stops.Add(stop);
			}

			return stops;
		}
	}
}
