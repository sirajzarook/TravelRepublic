using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic
{
	public class FlightAnalyzer : IFlightAnalyzer
	{
		private readonly IList<Flight> _flights;
		private readonly FlightBuilder _flighBuilder;
		public FlightAnalyzer(FlightBuilder flightBuilder)
		{
			_flighBuilder = flightBuilder;
			_flights = _flighBuilder.GetFlights();
		}

		/// <summary>
		/// Flights departs before today
		/// </summary>
		/// <param name="today"></param>
		/// <returns></returns>
		public IList<Flight> FlightsDepartBeforeToday(DateTime today)
		{
			return _flights.Where(t => t.Segments.All(d => d.DepartureDate < today)).ToList();
		}


		/// <summary>
		/// Flights wait longer than x hours
		/// </summary>
		/// <param name="hours"></param>
		/// <returns></returns>
		public IList<Flight> FlightsWaitLonger(int hours)
		{
			List<Flight> flightList = new List<Flight>();

			foreach (var flight in _flights)
			{
				if (flight.Segments.Count() < 2) //Only multiple flight segments should be targetted
					continue;
				// TODO: this linq statement need another visit later
				var longWaitingSeg = from seg1 in flight.Segments.Take(flight.Segments.Count() - 1)
									 from seg2 in flight.Segments.Skip(1)
									 where seg1.ArrivalDate.AddHours(hours) > seg1.DepartureDate
									 //select new Segment{ DepartureDate = seg1.DepartureDate , ArrivalDate = seg1.ArrivalDate };
									 select new Flight { Segments = flight.Segments };
				if (longWaitingSeg.Count() > 0)
					flightList.Add(flight);
			}

			return flightList;

		}

		/// <summary>
		/// Flights with error segments
		/// </summary>
		/// <returns></returns>
		public IList<Flight> FlightsWithErrorSegments()
		{
			return _flights.Where(t => t.Segments.All(d => d.DepartureDate > d.ArrivalDate)).ToList();
		}
	}
}
