using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS
{
    class ConnectionDB
    {
        public string GetConnection()
        {//sınıf
            string con = "Data Source=.;Initial Catalog=ObsDb;Integrated Security=True";
            return con;
        }
    }
}
