using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Position 的摘要说明
/// </summary>
namespace InstrumApplication.Models
{
    public class Position
    {
         //Position constructor
            public Position(string Mobil, string Lat, string Lng, DateTime ArrivalTime)
            {
                mobil = Mobil;
                lat = Lat;
                lng = Lng;
                arrivaltime = ArrivalTime;
            }

            //properties
            private string mobil;
            public string Mobil
            {
                get
                { return mobil; }
                set
                { mobil = value; }
            }

            private string lat;
            public string Lat
            {
                get
                { return lat; }
                set
                { lat = value; }
            }

            private string lng;
            public string Lng
            {
                get
                { return lng; }
                set
                { lng = value; }
            }

            private DateTime arrivaltime;
            public DateTime ArrivalTime
            {
                get
                { return arrivaltime; }
                set
                { arrivaltime = value; }
            }
        }

}