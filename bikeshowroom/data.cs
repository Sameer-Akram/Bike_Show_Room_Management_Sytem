using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bikeshowroom
{
    public class data
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=desktop-nq51ar7\sqlexpress;Initial Catalog=Bike_showroom_MS;Integrated Security=True");


        public struct empInfo
        {
            public string id, pin, name, contact, address, email, status;
            public empInfo(string s)
            {
                id = pin = name = contact = address = email = status = s;
            }
        }
    }
}
