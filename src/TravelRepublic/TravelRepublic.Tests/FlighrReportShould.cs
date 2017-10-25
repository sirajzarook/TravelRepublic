using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TravelRepublic.FlightCodingTest;
using System.Linq;

namespace TravelRepublic.Tests
{
	[TestClass]
	public class FlighrReportShould : TestBase
	{
		[TestMethod]
		public void ReturnFlightDepartBeforeCurrentTime()
		{
			//Arrange
			FlightReports flightReports = new FlightReports(flightAnalizer, reportSettings);

			//Act
			var flights = flightReports.GetFlightsDepartBeforeToday();

			//Assert
			Assert.AreEqual(typeof(List<Flight>), flights.GetType());
			Assert.IsNotNull(flights);
			foreach (var flight in flights)
			{
				//at least onesegment of the flight leave before today
				Assert.IsTrue(flight.Segments.Where(t => t.DepartureDate < reportSettings.currenttime).Count() > 0);
			}


		}

		[TestMethod]
		public void ReturnFlightWithErrorSegments()
		{
			FlightReports flightReports = new FlightReports(flightAnalizer, reportSettings);

			var flights = flightReports.GetFlightsWithErrorSegments();
			Assert.AreEqual(typeof(List<Flight>), flights.GetType());
			Assert.IsNotNull(flights);
			foreach (var flight in flights)
			{
				//at least one segment of the flight has an error
				Assert.IsTrue(flight.Segments.Where(t => t.ArrivalDate < t.DepartureDate).Count() > 0);
			}

		}

		[TestMethod]
		public void ReturnFlightWaitingLongerThanSpecificTIme()
		{
			//TODO 
			reportSettings.TransitInHours = 2;
			FlightReports flightReports = new FlightReports(flightAnalizer, reportSettings);

			var flights = flightReports.GetFlightsWaitLonger();
			Assert.AreEqual(typeof(List<Flight>), flights.GetType());
			Assert.IsNotNull(flights);
			Assert.AreEqual(3, flights.Count());

		}
	}
}
