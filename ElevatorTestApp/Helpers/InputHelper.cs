using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTestApp.Helpers
{
	public static class InputHelper
	{
		public static int GetFloor()
		{
			int floor = 0;
			Console.Write("Call Elevator to floor: ");
			string? destinationFloor = Console.ReadLine();

			if (!int.TryParse(destinationFloor, out floor);
			{
				GetFloor();
			}

			return floor;
		}

		public static int GetPassengers()
		{
			int passengers = 0;
			Console.Write("Number of passengers: ");
			string? passengersCount = Console.ReadLine();

			if (!int.TryParse(passengersCount, out passengers);
			{
				GetPassengers();
			}

			return passengers;
		}

		public static List<int> GetStops(int passengers)
		{
			List<int> stops = new List<int>();

			for (int i = 0; i < passengers; i++)
			{
				Console.Write($"Enter stop: {i + 1}");
				string? stopInput = Console.ReadLine();
				int stop = 0;

				if (!int.TryParse(stopInput, out stop))
				{
					GetStops(passengers);
				}
			}

			return stops;
		}
	}
}
