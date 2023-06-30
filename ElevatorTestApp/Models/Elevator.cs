using ElevatorTestApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTestApp.Models
{
	public class Elevator
	{
		public int Id { get; set; }
		public int CurrentFloor { get; private set; }
		public bool IsMoving { get; private set; }
		public Movement CurrentDirection { get; private set; }
		public int PassengerCount { get; private set; }
		public int MaxOccupancy { get; set; }

		/// <summary>
		/// Moves the elevator to a specific floor.
		/// </summary>
		/// <param name="floor">The floor.</param>
		public void MoveToFloor(int floor)
		{	
			IsMoving = true;
			CurrentDirection = floor > CurrentFloor ? Movement.Up : Movement.Down;

			Console.WriteLine($"Elevator {Id} is moving {CurrentDirection} from floor: {CurrentFloor} to floor: {floor} \n");

			while (CurrentFloor != floor)
			{
				if (CurrentDirection == Movement.Up)
				{
					CurrentFloor++;
				}		
				else
				{
					CurrentFloor--;
				}
					
				Console.WriteLine($"Elevator {Id} is now on floor {CurrentFloor} \n");
				
				Thread.Sleep(1000);
			}

			IsMoving = false;
		}

		/// <summary>
		/// Adds the passengers to the elevator.
		/// </summary>
		/// <param name="count">The count.</param>
		public void AddPassengers(int count)
		{
			try
			{
				PassengerCount += count;
				Console.WriteLine($"{count} passengers have entered elevator {Id}. \n Occupancy: {PassengerCount} \n");
			}
			catch (Exception)
			{
				throw;
			}		
		}

		/// <summary>
		/// Removes the passenger from the elevator.
		/// </summary>
		/// <param name="count">The count.</param>
		public void RemovePassenger(int count)
		{
			try
			{
				PassengerCount -= count;
				Console.WriteLine($"{count} passengers have exited the elevator {Id}. \n  Occupancy: {PassengerCount} \n");
			}
			catch (Exception)
			{

				throw;
			}			
		}
	}
}