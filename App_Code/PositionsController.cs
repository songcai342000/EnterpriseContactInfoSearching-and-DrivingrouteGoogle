using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstrumApplication.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Formatting;
using System.Globalization;
using System.Threading;

namespace InstrumApplication.Controllers
{
    public class PositionsController : ApiController
    {
        private string connectionStr = "Data Source = DESKTOP-V7H8POU\\SQLEXPRESS2017; Initial Catalog = Instrum; Integrated Security=True";
       
        //get clients by postal code, it is a get request with action name "GetByPostal"
        [HttpGet]
        [ActionName("GetByPeriod")]
        public IEnumerable<Position> Post_positions_by_period(string fromTime, string toTime)
        { 
            string commandTex;
            List<Position> positions = new List<Position>();
            //recover the time formats of time information in the query string
            string fromTimeSubStr1 = fromTime.Substring(0, 4) + ".";
            string fromTimeSubStr2 = fromTime.Substring(4, 2) + ".";
            string fromTimeSubStr3 = fromTime.Substring(6, 5) + ":";
            string fromTimeSubStr4 = fromTime.Substring(11, 2);
            fromTime = fromTimeSubStr1 + fromTimeSubStr2 + fromTimeSubStr3 + fromTimeSubStr4;
            string toTimeSubStr1 = toTime.Substring(0, 4) + ".";
            string toTimeSubStr2 = toTime.Substring(4, 2) + ".";
            string toTimeSubStr3 = toTime.Substring(6, 5) + ":";
            string toTimeSubStr4 = toTime.Substring(11, 2);
            toTime = toTimeSubStr1 + toTimeSubStr2 + toTimeSubStr3 + toTimeSubStr4;
            //convert string to time
            DateTime from = Convert.ToDateTime(fromTime);
            DateTime to = Convert.ToDateTime(toTime);
            //change to the database culture
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            using (SqlConnection SqlConn = new SqlConnection(connectionStr))
            {
                //serach the positions from the database
                commandTex = "Select * from GeoLocations where ArrivalTime <= '" + to + "' and ArrivalTime >= '" + from + "'";
               
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = new SqlCommand(commandTex, SqlConn);
                    //load datatable with sqldatareader
                    SqlDataReader reader = SqlComm.ExecuteReader();
                    DataTable db = new DataTable();
                  
                    db.Load(reader);
                    if (db != null && db.Rows.Count > 0)
                    {
                        foreach (DataRow dr in db.Rows)
                        {
                            Position position = new Position(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToDateTime(dr[5].ToString()));
                            positions.Add(position);
                        }
                    }
                    else
                    {
                        positions = null;
                    }
                }
            }
            return positions;
        }


    }
    
}
