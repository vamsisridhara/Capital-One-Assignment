using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CommuterSystem.Models
{
    public static class StaticData
    {
        public static List<Trips> getSilverTrains()
        {
            return new List<Trips>()
                        {
                            new Trips()
                            {
                                TripId = 1,
                                ServiceId = 11,
                                ServiceName = "Silver",
                                Stoptimes = new StopTimes()
                                {
                                    StopId = 11,
                                    ArrivalTime = DateTime.Now,
                                    DepartureTime = DateTime.Now,
                                    TripId = 1
                                },
                                Stops = new Stops()  {  StopDesc = "Foggy Bottom" , StopId = 11 , StopName = "Foggy Bottom"}
                            },
                            new Trips()
                            {
                                TripId = 2,
                                ServiceId = 12,
                                ServiceName = "Silver",
                                Stoptimes = new StopTimes()
                                {
                                    StopId = 12,
                                    ArrivalTime = DateTime.Now,
                                    DepartureTime = DateTime.Now,
                                    TripId = 2
                                },
                                Stops = new Stops() {  StopDesc = "Farragut West" , StopId = 12 , StopName = "Farragut West"}
                           }
                        };
        }
        public static List<Trips> getOrangeTrains()
        {
            return new List<Trips>()
                        {
                            new Trips()
                            {
                                TripId =32,
                                ServiceId = 21,
                                ServiceName = "Orange",
                                Stoptimes = new StopTimes()
                                {
                                    StopId = 21,
                                    ArrivalTime = DateTime.Now,
                                    DepartureTime = DateTime.Now,
                                    TripId = 1
                                },
                                Stops = new Stops()  {  StopDesc = "Vienna" , StopId = 22 , StopName = "Vienna" , NextArrivingTrain = "Silver" }
                            },
                            new Trips()
                            {
                                TripId = 31,
                                ServiceId = 22,
                                ServiceName = "Orange",
                                Stoptimes = new StopTimes()
                                {
                                    StopId = 22,
                                    ArrivalTime = DateTime.Now,
                                    DepartureTime = DateTime.Now,
                                    TripId = 2
                                },
                                Stops = new Stops() {  StopDesc = "Dunn Loring" , StopId = 22 , StopName = "Dunn Loring" , NextArrivingTrain = "Orange" }
                           }
                        };
        }

        public static List<Routes> getServiceStatus()
        {
            return new List<Routes>()
            {
                new Routes()
                {
                    RouteId = 100,
                    RouteType = LineType.Blue,
                    lineStatus = LineStatus.Alert,
                    cssclass = "info"
                },
                 new Routes()
                {
                    RouteId = 101,
                    RouteType = LineType.Silver,
                    lineStatus = LineStatus.OnTime,
                    cssclass = "success"
                },
                 new Routes()
                {
                    RouteId = 102,
                    RouteType = LineType.Red,
                    lineStatus = LineStatus.Cancelled,
                    cssclass = "warning"
                },
                 new Routes()
                {
                    RouteId = 103,
                    RouteType = LineType.Orange,
                    lineStatus = LineStatus.Delayed,
                    cssclass = "danger"
                }
            };
        }

        public static List<string> getLines()
        {
            return Enum.GetNames(typeof(LineType)).ToList();
        }

        public static string getNextTrain(string stationName)
        {
            var stationId = getStations().Where(x => x.StationName == stationName).Select(x => x.StationId).FirstOrDefault();

            var listofTrips = new List<Trips>()
                {
                    new Trips()
                    {
                        TripId =32,
                        ServiceId = 21,
                        ServiceName = "Orange",
                        Stoptimes = new StopTimes()
                        {
                            StopId = 21,
                            ArrivalTime = DateTime.Now,
                            DepartureTime = DateTime.Now,
                            TripId = 1
                        },
                        Stops = new Stops()  {  StopDesc = "West Falls Church" , StopId = 22 , StopName = "West Falls Church" , NextArrivingTrain = "Silver", StationId = 2 }
                    },
                    new Trips()
                    {
                        TripId = 31,
                        ServiceId = 22,
                        ServiceName = "Orange",
                        Stoptimes = new StopTimes()
                        {
                            StopId = 22,
                            ArrivalTime = DateTime.Now,
                            DepartureTime = DateTime.Now,
                            TripId = 2
                        },
                        Stops = new Stops() {  StopDesc = "Dunn Loring" , StopId = 22 , StopName = "Dunn Loring" , NextArrivingTrain = "Silver" , StationId = 1 }
                    }
                };

            return listofTrips.Where(x => x.Stops.StationId == stationId).Select(x => x.Stops.NextArrivingTrain).FirstOrDefault();
        }

        public static List<Stations> getStations()
        {
            return new List<Stations>()
            {
                new Stations(){ StationId = 1, StationName = "Reston"},
                new Stations(){ StationId = 2, StationName = "Springhill"},
                new Stations(){ StationId = 3, StationName = "McLean"},
                new Stations(){ StationId = 4, StationName = "Tysons Corner"},
                new Stations(){ StationId = 5, StationName = "Vienna"}
            };
        }
    }
    public class Stations
    {
        public string StationName { get; set; }
        public int StationId { get; set; }
    }
    public class Stops
    {
        public int StopId
        {
            get;
            set;
        }
        public string StopName
        {
            get;
            set;
        }
        public string StopDesc
        {
            get;
            set;
        }
        public string NextArrivingTrain
        {
            get;
            set;
        }
        public int StationId { get; set; }
    }
    public class Trips
    {
        public int RouteId
        {
            get;
            set;
        }
        public int ServiceId
        {
            get;
            set;
        }
        public string ServiceName
        {
            get;
            set;
        }
        public StopTimes Stoptimes
        {
            get;
            set;
        }

        public Stops Stops
        {
            get;
            set;
        }
        public int TripId
        {
            get;
            set;
        }

    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LineType
    {
        [EnumMember(Value = "Silver")]
        Silver,
        [EnumMember(Value = "Red")]
        Red,
        [EnumMember(Value = "Blue")]
        Blue,
        [EnumMember(Value = "Orange")]
        Orange
    }
    public class Routes
    {
        public int RouteId
        {
            get;
            set;
        }
        public LineType RouteType
        {
            get;
            set;
        }
        public LineStatus lineStatus;
        public string cssclass;
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LineStatus
    {
        [EnumMember(Value = "Cancelled")]
        Cancelled,
        [EnumMember(Value = "Delayed")]
        Delayed,
        [EnumMember(Value = "OnTime")]
        OnTime,
        [EnumMember(Value = "Alert")]
        Alert
    }
    public class StopTimes
    {
        public int TripId
        {
            get;
            set;
        }
        public DateTime ArrivalTime
        {
            get;
            set;
        }
        public DateTime DepartureTime
        {
            get;
            set;
        }
        public int StopId
        {
            get;
            set;
        }

    }
    public class Frequencies
    {
        public int Tripid
        {
            get;
            set;
        }
        public DateTime Starttime
        {
            get;
            set;
        }
        public DateTime Endtime
        {
            get;
            set;
        }
    }
    public class FareRules
    {
        public int FareId
        {
            get;
            set;
        }
        public int RouteId
        {
            get;
            set;
        }
        public int OrginationId
        {
            get;
            set;
        }
        public int DestinationId
        {
            get;
            set;
        }


    }
}