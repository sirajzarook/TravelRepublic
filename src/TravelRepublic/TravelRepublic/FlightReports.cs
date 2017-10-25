using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Config;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic
{
	public class FlightReports
	{
		private readonly FlightReportSettings _reportSettings;
		private readonly IFlightAnalyzer _flightAnalyzer;
		public FlightReports(IFlightAnalyzer flightAnalyzer, FlightReportSettings reportSettings)
		{
			_flightAnalyzer = flightAnalyzer;
			_reportSettings = reportSettings;
		}

		public IList<Flight> GetFlightsDepartBeforeToday()
		{
			return _flightAnalyzer.FlightsDepartBeforeCurrentTime(_reportSettings.currenttime);
		}
		public IList<Flight> GetFlightsWithErrorSegments()
		{
			return _flightAnalyzer.FlightsWithErrorSegments();
		}
		public IList<Flight> GetFlightsWaitLonger()
		{
			return _flightAnalyzer.FlightsWaitLonger(_reportSettings.TransitInHours);
		}

	}
}
