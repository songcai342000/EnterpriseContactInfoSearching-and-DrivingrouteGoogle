using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace InstrumApplication.Models
{
        /// <summary>
        /// Chosenuser information
        /// </summary>
        public class Chosenuser
        {
            //Chosenuser constructor
            public Chosenuser(string Orgno, string Name, string Address, string Postno, string Postdistrict, string Countyno, string County, string Country)
            {
                orgno = Orgno;
                name = Name;
                address = Address;
                postno = Postno;
                postdistrict = Postdistrict;
                countyno = Countyno;
                county = County;
                country = Country;
            }

        //property variables
        private string orgno;
        public string Orgno
        {
            get
            { return orgno; }
            set
            { orgno = value; }
        }

        private string name;
        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }

        private string address;

        public string Address
        {
            get
            { return address; }
            set
            { name = value; }
        }

        private string postno;

        public string Postno
        {
            get
            { return postno; }
            set
            { postno = value; }
        }

        private string postdistrict;

        public string Postdistrict
        {
            get
            { return postdistrict; }
            set
            { postdistrict = value; }
        }

        private string country;

        public string Country
        {
            get
            { return country; }
            set
            { country = value; }
        }

        private string countyno;

        public string Countyno
        {
            get
            { return countyno; }
            set
            { countyno = value; }
        }

        private string county;

        public string County
        {
            get
            { return county; }
            set
            { county = value; }
        }

    }
}