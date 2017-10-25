using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Config;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic
{
	class Program
	{
		static void Main(string[] args)
		{
			//All required settings can be stored in appsettings.json for DI and pass it on to report Analyzer
			FlightReportSettings reportSettings = new FlightReportSettings()
			{
				TransitInHours = 2,
				dateToday = DateTime.Today

			};

			FlightBuilder flighBuilder = new FlightBuilder();
			FlightAnalyzer flightAnalizer = new FlightAnalyzer(flighBuilder);
			FlightReports flightReports = new FlightReports(flightAnalizer, reportSettings);

			Console.WriteLine("Number of flights departs before current date: {0}"
									, flightReports.GetFlightsDepartBeforeToday().Count());
			Console.WriteLine("Number of flights with error segments: {0}"
									, flightReports.GetFlightsWithErrorSegments().Count());
			Console.WriteLine("Number of flights have transit over time {0} hours are: {1} "
									, reportSettings.TransitInHours, flightReports.GetFlightsWaitLonger().Count());
			
			//var flights = flightReports.GetFlightsDepartBeforeToday();
			//var flightsError = flightReports.GetFlightsWithErrorSegments();
			//var flightWaitingLonger = flightReports.GetFlightsWaitLonger();

			Console.ReadKey();
		}
	}
}
