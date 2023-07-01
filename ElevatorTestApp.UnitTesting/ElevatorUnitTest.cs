using Moq;

namespace ElevatorTestApp.UnitTesting
{
	public class ElevatorUnitTest
	{
		/// <summary>
		/// Moves to floor.
		/// </summary>
		/// <param name="floor">The floor.</param>
		[Theory]
		[InlineData(4)]
		public void MoveToFloor(int floor)
		{
			//arrange
			Elevator elevator = new()
			{
				Id = 1,
				CurrentDirection = Movement.Stationary,
				CurrentFloor = 0,
				PassengerCount = 0,
				IsMoving = false,
				MaxOccupancy = 10,
			};

			//act
			elevator.MoveToFloor(floor);

			//assert
			Assert.True(elevator.CurrentFloor == 4);
		}

		/// <summary>
		/// Adds the passengers.
		/// </summary>
		/// <param name="count">The count.</param>
		[Theory]
		[InlineData(3)]
		public void AddPassengers(int count)
		{
			//arrange
			Elevator elevator = new()
			{
				Id = 2,
				CurrentDirection = Movement.Stationary,
				CurrentFloor = 0,
				PassengerCount = 0,
				IsMoving = false,
				MaxOccupancy = 10,
			};

			//act
			elevator.AddPassengers(count);

			//assert
			Assert.True(elevator.PassengerCount == 3);
		}

		/// <summary>
		/// Removes the passenger.
		/// </summary>
		/// <param name="count">The count.</param>
		[Theory]
		[InlineData(2)]
		public void RemovePassenger(int count)
		{
			//arrange
			Elevator elevator = new()
			{
				Id = 3,
				CurrentDirection = Movement.Stationary,
				CurrentFloor = 0,
				PassengerCount = 3,
				IsMoving = false,
				MaxOccupancy = 10,
			};

			//act
			elevator.RemovePassenger(count);

			//assert
			Assert.True(elevator.PassengerCount == 1);
		}
	}
}