using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTestApp.Services.Interface
{
	public interface IElevatorService
	{
		void CallElevator(int floor, int passengers, List<int> stops);
		void DisplayElevatorStatus();
	}
}
