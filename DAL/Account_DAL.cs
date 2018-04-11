using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Account_DAL
    {
        Thaotac_CSDL ins = new Thaotac_CSDL();

        

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord ";
            DataTable result = ins.ExecuteQuery(query, new object[] { userName, passWord });
            return result.Rows.Count > 0;
        }
    }
}
