using System;
using System.Collections.Generic;

namespace FlightScheduleApp.Models
{
    public class ScheduledDateTimeUTC
    {
        public DateTime @out { get; set; }
        public DateTime @in { get; set; }
    }

    public class EstimatedDateTimeUTC
    {
        public DateTime @out { get; set; }
        public DateTime @in { get; set; }
        public object delayInformation { get; set; }
    }

    public class Gate
    {
        public string podium { get; set; }
        public string parkingSpot { get; set; }
        public object carousel { get; set; }
    }

    public class ActualDepartureStation
    {
        public string airportCode { get; set; }
        public int zuluOffset { get; set; }
        public Gate gate { get; set; }
        public string countryCode2Letters { get; set; }
        public string countryCode3Letters { get; set; }
    }

    public class ActualArrivalStation
    {
        public string airportCode { get; set; }
        public int zuluOffset { get; set; }
        public Gate gate { get; set; }
        public string countryCode2Letters { get; set; }
        public string countryCode3Letters { get; set; }
    }

    public class ScheduledArrivalStation
    {
        public string airportCode { get; set; }
    }

    public class ScheduledDepartureStation
    {
        public string airportCode { get; set; }
    }

    public class CodeShare
    {
        public string marketingFlightNumber { get; set; }
        public string marketingAirlineCode { get; set; }
    }

    public class Aircraft
    {
        public string aircraftRegistration { get; set; }
        public string fleetType { get; set; }
        public string fleetSeries { get; set; }
        public string iataAircraftCode { get; set; }
        public string oagFleetCode { get; set; }
        public string manufacturer { get; set; }
        public object reservationSystemEquipmentTypeCode { get; set; }
    }

    public class FlightLeg
    {
        public int legNumber { get; set; }
        public ScheduledDateTimeUTC scheduledDateTimeUTC { get; set; }
        public EstimatedDateTimeUTC estimatedDateTimeUTC { get; set; }
        public ActualDepartureStation actualDepartureStation { get; set; }
        public ActualArrivalStation actualArrivalStation { get; set; }
        public object actualdatetimeutc { get; set; }
        public object irropsType { get; set; }
        public object opsReason { get; set; }
        public ScheduledArrivalStation scheduledArrivalStation { get; set; }
        public ScheduledDepartureStation scheduledDepartureStation { get; set; }
        public List<CodeShare> codeShares { get; set; }
        public Aircraft aircraft { get; set; }
        public string iataFlightServiceType { get; set; }
        public bool isETOPSFlight { get; set; }
        public object flightRangeCode { get; set; }
        public string operatingAirlineCode { get; set; }
        public string operatingAirlineName { get; set; }
        public string sourceInternalId { get; set; }
        public string scheduledDepartureDateStnLocal { get; set; }
        public object onwardOperatingAirlineCode { get; set; }
        public object onwardOperatingFlightNumber { get; set; }
    }

    public class FlightDetails
    {
        public string sourceSystemName { get; set; }
        public DateTime sourceSystemLastModifiedDateTimeUtc { get; set; }
        public string schemaVersion { get; set; }
        public string lastEventType { get; set; }
        public string operatingFlightNumber { get; set; }
        public string scheduledFlightOriginationDateUTC { get; set; }
        public string scheduledFlightOriginationDateLocal { get; set; }
        public List<FlightLeg> flightLegs { get; set; }
    }

    public class Flight
    {
        public FlightDetails flightDetails { get; set; }
        public string flightLookupKey { get; set; }
        public int updateCount { get; set; }
    }

    public class ActionResult
    {
        public int code { get; set; }
        public List<string> messages { get; set; }
    }

    public class APIResponse
    {
        public List<Flight> flights { get; set; }
        public ActionResult actionResult { get; set; }
    }
}
