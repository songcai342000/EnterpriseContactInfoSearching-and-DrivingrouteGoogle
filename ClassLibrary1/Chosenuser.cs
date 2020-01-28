using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    [Serializable]
    /// <summary>
    /// Chosenuser 的摘要说明
    /// </summary>
    public class Chosenuser
    {
        public Chosenuser(string Orgno, string Name, string Address, string Postno, string Postdistrict)
        {
            orgno = Orgno;
            name = Name;
            address = Address;
            postno = Postno;
            postdistrict = Postdistrict;
        }

        //property variables
        private string orgno;
        public string Orgno
        {
            get
            {
                return orgno;
            }
            set
            {
                orgno = value;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        private string postno;
        public string Postno
        {
            get
            {
                return postno;
            }
            set
            {
                postno = value;
            }
        }

        private string postdistrict;
        public string Postdistrict
        {
            get
            {
                return postdistrict;
            }
            set
            {
                postdistrict = value;
            }
        }
    }
}