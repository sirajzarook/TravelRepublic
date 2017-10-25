using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic
{
	public interface IFlightAnalyzer
	{
		IList<Flight> FlightsDepartBeforeToday(DateTime today);
		IList<Flight> FlightsWithErrorSegments();
		IList<Flight> FlightsWaitLonger(int hours);

	}
}
