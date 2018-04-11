using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Account_BLL
    {
        Account_DAL acc = new Account_DAL(); 
        public bool Login(string userName, string passWord)
        {
            return acc.Login(userName, passWord);
        }
    }
}
