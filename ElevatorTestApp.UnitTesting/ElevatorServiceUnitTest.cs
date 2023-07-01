using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTestApp.UnitTesting
{
	public class ElevatorServiceUnitTest
	{
		[Theory]
		[InlineData(3, 1, null)]
		public void CallElevator(int floor, int passengers, List<int> stops)
		{
			//Arrange
			stops = new List<int>() { 1 };
			IElevatorService elevatorService = new ElevatorService(5, 2);

			//Act
			elevatorService.CallElevator(floor, passengers, stops);

			//Assert (One elevator should be at floor 1)
			var elevators = elevatorService.GetCurrentElevators();
			var testElevator = elevators.Where(e => e.CurrentFloor == 1).FirstOrDefault();
			Assert.NotNull(testElevator);
		}
	}
}
