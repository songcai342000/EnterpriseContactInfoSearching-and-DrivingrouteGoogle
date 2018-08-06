using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using InstrumApplication.Models;

namespace InstrumApplication.Controllers
{
    public class ChosenusersController : ApiController
    {
        //variables
        string connectionStr = "Data Source = DESKTOP-V7H8POU\\SQLEXPRESS2017; Initial Catalog = Instrum; Integrated Security=True";
        string commandTex;
        SqlDataAdapter SqlAd;
        string Orgno;
        string Address;
        string Postno;
        string Postdistrict;
        string Name;
        string Countyno;
        string County;
        string Country;
        Chosenuser theuser;
        DataTable table;
        List<Chosenuser> Chosenusers = new List<Chosenuser>();
        // GET api/<controller>
        //fill the listUsers

        //the function to get address information by Organization number, it is a Get request with actionname "GetByOrgno" 
        [HttpGet]
        [ActionName("GetByOrgno")]
        public Chosenuser Get_client_address_by_orgno(string Orgno)
        {
            using (SqlConnection SqlConn = new SqlConnection(connectionStr))
            {
                //select the user information from the database
                commandTex = "Select * from hovedenheter230220180013 where organisasjonsnummer = '" + Orgno + "'";
               // commandTex = "Select organisasjonsnummer from hovedenheter230220180013 where organisasjonsnummer = '" + Orgno + "'";
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = new SqlCommand(commandTex, SqlConn);
                    table = new DataTable();
                    SqlAd = new SqlDataAdapter();
                    SqlAd.SelectCommand = SqlComm;
                    SqlAd.Fill(table);                  
                    //if the user is found, get the user information from the first row in the table
                    if (table != null && table.Rows.Count > 0)
                    {
                        //grant the values to the variables
                        Orgno = table.Rows[0][0].ToString();
                        Name = table.Rows[0][1].ToString();
                        Address = table.Rows[0][2].ToString();
                        Postno = table.Rows[0][3].ToString();
                        Postdistrict = table.Rows[0][4].ToString();
                        Countyno = table.Rows[0][5].ToString();
                        County = table.Rows[0][6].ToString();
                        Country = table.Rows[0][7].ToString();
                        //create the new user object
                        theuser = new Chosenuser(Orgno, Name, Address, Postno, Postdistrict, Countyno, County, Country);
                    }
                    else
                    {
                        //leave the user as null
                        theuser = null;
                    }
                    
                }
            }
            return theuser;
        }

        //get clients by postal code, it is a get request with action name "GetByPostal"
        [HttpGet]
        [ActionName("GetByPostal")]
        public IEnumerable<Chosenuser> Get_clients_by_postal_code(string Postno)
        {
            using (SqlConnection SqlConn = new SqlConnection(connectionStr))
            {
                //serach the users from the database
                commandTex = "Select * from hovedenheter230220180013 where postadressepostnummer = '" + Postno + "'";
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = new SqlCommand(commandTex, SqlConn);
                    SqlDataReader reader = SqlComm.ExecuteReader();
                    DataTable db = new DataTable();
                    db.Load(reader);
                    List<string> theUserData = new List<string>();
                    //if the users are found in the database
                    if (db != null && db.Rows.Count > 0)
                    {
                        foreach (DataRow dr in db.Rows)
                        {
                            //grant property values to the user
                            Orgno = dr[0].ToString();
                            Name = dr[1].ToString();
                            Address = dr[2].ToString();
                            Postno = dr[3].ToString();
                            Postdistrict = dr[4].ToString();
                            Countyno = dr[5].ToString();
                            County = dr[6].ToString();
                            Country = dr[7].ToString();
                            //create a new user object
                            Chosenuser theuser = new Chosenuser(Orgno, Name, Address, Postno, Postdistrict, Countyno, County, Country);
                            //put the new user in the list
                            Chosenusers.Add(theuser);
                        }
                    }
                    else
                    {
                        //define Chosenusers as null
                        Chosenusers = null;
                    }
                }
            }
            return Chosenusers;
        }

    }
}


