﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DialyHelper.Models;

namespace DialyHelper
{
    /// <summary>
    /// Account Stuff
    /// </summary>
    public class AccountDB
    {
        private DBHelper db = new DBHelper();
        public bool LogIn(Account account)
        {
            string sqlcmd = "select count(*) from account where password=@password";
            OleDbParameter password = new OleDbParameter("@password", account.Password);
            OleDbParameter[] paras ={password};
            bool result = (bool)db.GetDBSchalar(sqlcmd, paras);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}