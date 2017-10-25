using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Config;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic.Tests
{
	public class TestBase
	{
		internal FlightBuilder flighBuilder;
		internal FlightReportSettings reportSettings;
		internal FlightAnalyzer flightAnalizer;
		public TestBase()
		{
			//All required settings can be stored in appsettings.json for DI and pass it on to report Analyzer
			reportSettings = new FlightReportSettings()
			{
				TransitInHours = 2,
				dateToday = DateTime.Today

			};

			flighBuilder = new FlightBuilder();
			flightAnalizer = new FlightAnalyzer(flighBuilder);
		}
	}
}
