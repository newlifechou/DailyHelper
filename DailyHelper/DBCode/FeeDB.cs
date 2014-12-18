using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using DailyHelper.Models;

namespace DailyHelper
{
    public class FeeDB
    {
        private DBHelper db = new DBHelper();
        public List<Fee> GetFeeList()
        {
            string sqlcmd = "select id,itemtime,itemcontent,cost,haveinvoice,isreimburse,reimbursetime from fee order by itemtime";
            OleDbDataReader dr = db.GetDBReader(sqlcmd, null);
            List<Fee> feelist = new List<Fee>();
            while (dr.Read())
            {
                Fee f = new Fee();
                f.ID = dr.GetInt32(0);
                f.ItemTime = dr.GetDateTime(1);
                f.ItemContent = dr.GetString(2);
                f.Cost = dr.GetDecimal(3);
                f.HaveInvoice = dr.GetBoolean(4);
                f.IsReimburse = dr.GetBoolean(5);
                if (dr.IsDBNull(6))
                {
                    f.ReimburseTime = null;
                }
                else
                {
                    f.ReimburseTime = dr.GetDateTime(6);
                }
                feelist.Add(f);
            }
            dr.Close();
            return feelist;
        }
    }
}
