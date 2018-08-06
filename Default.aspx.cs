using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Data.SQLite;


public partial class _Default : Page
{
    private string commandTex;
    private string connectionStr = "Data Source = DESKTOP-V7H8POU\\SQLEXPRESS2017; Initial Catalog = Instrum; Integrated Security=True";
    //private string connectionStr = "Data Source = .\\thrum.db";

    protected void Page_Load(object sender, EventArgs e)
    {
        //NoCrediteNoteUsers();
        //NoCrediteNoteOrgno();
          //NoCrediteNoteBRREG();
        //AllRegistedAddresses();
        //Downloadbrreg();
        //Downloadparticipants();
    }

    //download participants file from web
    public void Downloadparticipants()
    {
        WebClient Client = new WebClient();
        Client.DownloadFile("http://hotell.difi.no/api/csv/difi/elma/participants?", "D:\\participants.csv");
    }

    //download brreg file from web
    public void Downloadbrreg()
    {
        WebClient Client = new WebClient();
        Client.DownloadFile("http://data.brreg.no/enhetsregisteret/download/enheter", "W:\\Dokreg\\Song\\instrum\\hovedenheter.190220182342.csv.gz");
    }

    //get the users who will not get creditenote from the participants table in the database
    public void NoCrediteNoteUsers()
    {
        commandTex = "Select * into NoCreditNoteELMAUsers from participants where EHF_CREDITNOTE_2_0 = 'NEI'";
        using (SqlConnection SqlConn = new SqlConnection(connectionStr))
        {
                DataTable table = new DataTable();
                SqlCommand SqlComm;
                SqlConn.Open();
                SqlComm = new SqlCommand(commandTex, SqlConn);
                SqlComm.ExecuteNonQuery();
        }
    }

    //a function to try
    public void NoCrediteNoteUsersExcel()
    {
        commandTex = "Select navn, postadresseadresse, postadressepostnummer, postadressepoststed, postadressekommunenummer, postadressekommune, postadresseland into AllRegistedAddresses from openrowset('Microsoft.ACE.OLEDB.4.0', 'Excel 12.0; Database=\\Nedlastinger\\Data\\participants.xls','SELECT * FROM participants')";
        using (SqlConnection SqlConn = new SqlConnection(connectionStr))
        {
            DataTable table = new DataTable();
            SqlCommand SqlComm;
            SqlConn.Open();
            SqlComm = new SqlCommand(commandTex, SqlConn);
            SqlComm.ExecuteNonQuery();
        }
    }

    //get organization numbers of the users who will not get creditenote from the participants table
    public void NoCrediteNoteOrgno()
    {
        commandTex = "Select identifier into NoCrediteNoteOrgno from participants where EHF_CREDITNOTE_2_0 = 'NEI'";
        using (SqlConnection SqlConn = new SqlConnection(connectionStr))
        {
            DataTable table = new DataTable();
            SqlCommand SqlComm;
            SqlConn.Open();
            SqlComm = new SqlCommand(commandTex, SqlConn);
            SqlComm.ExecuteNonQuery();
        }
    }

    //get the organization numbers and post addresses of the users who will not get creditenote from the BRREG table in the database
    public void NoCrediteNoteBRREG()
    {
        commandTex = "Select organisasjonsnummer, navn, postadresseadresse, postadressepostnummer, postadressepoststed, postadressekommunenummer, postadressekommune, postadresseland into NoCrediteNoteBRREG from hovedenheter230220180013 inner join participants on hovedenheter230220180013.navn = participants.name where EHF_CREDITNOTE_2_0 = 'NEI'";
        using (SqlConnection SqlConn = new SqlConnection(connectionStr))
        {
            DataTable table = new DataTable();
            SqlCommand SqlComm;
            SqlConn.Open();
            SqlComm = new SqlCommand(commandTex, SqlConn);
            SqlComm.ExecuteNonQuery();
        }
    }

    //get all the registed post addresses in the BRREG, it is function to try
    public void AllRegistedAddresses()
    {
        commandTex = "Select navn, postadresseadresse, postadressepostnummer, postadressepoststed, postadressekommunenummer, postadressekommune, postadresseland into AllRegistedAddresses from hovedenheter230220180013";
        using (SqlConnection SqlConn = new SqlConnection(connectionStr))
        {
            DataTable table = new DataTable();
            SqlCommand SqlComm;
            SqlConn.Open();
            SqlComm = new SqlCommand(commandTex, SqlConn);
            SqlComm.ExecuteNonQuery();
        }
    }

    //use the button click event to get the data with the related function
    protected void nocrediteUserBtn_Click(object sender, EventArgs e)
    {
        NoCrediteNoteUsers();
    }

    //use the button click event to get the data with the related function

    protected void nocrediteOrgnoBtn_Click(object sender, EventArgs e)
    {
        NoCrediteNoteOrgno();
    }

    //use the button click event to get the data with the related function
    protected void nocrediteAddrs_Click(object sender, EventArgs e)
    {
        NoCrediteNoteBRREG();
    }

    //use the button click event to get the data with the related function
    protected void alladdressesBtn_Click(object sender, EventArgs e)
    {
        AllRegistedAddresses();
    }
}
