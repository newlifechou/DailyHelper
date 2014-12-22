using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using DailyHelper.Models;
using DailyHelper.Common;

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

        public int Save(Fee fee, CrudOP opType)
        {
            string sqlcmd;
            int result = 0;
            if (opType == CrudOP.Create)
            {
               sqlcmd = "insert into fee(itemtime,itemcontent,cost,haveinvoice,isreimburse,reimbursetime) values(?,?,?,?,?,?)";
                OleDbParameter[] paras = new OleDbParameter[]{
                new OleDbParameter("?",fee.ItemTime),
                new OleDbParameter("?",fee.ItemContent),
                new OleDbParameter("?",fee.Cost),
                new OleDbParameter("?",fee.HaveInvoice),
                new OleDbParameter("?",fee.IsReimburse),
                new OleDbParameter("?",fee.ReimburseTime)
                };
                result = db.ExecuteSql(sqlcmd, paras);
            }
            else
            {
                sqlcmd = "update fee set itemtime=?,itemcontent=?,cost=?,haveinvoice=?,isreimburse=?,reimbursetime=? where id=?";
                OleDbParameter[] paras = new OleDbParameter[]{
                new OleDbParameter("?",fee.ItemTime),
                new OleDbParameter("?",fee.ItemContent),
                new OleDbParameter("?",fee.Cost),
                new OleDbParameter("?",fee.HaveInvoice),
                new OleDbParameter("?",fee.IsReimburse),
                new OleDbParameter("?",fee.ReimburseTime),
                new OleDbParameter("?",fee.ID)
                };
                result = db.ExecuteSql(sqlcmd, paras);
            }
            return result;
        }
        public int Delete(int id)
        {
            string sqlcmd = "delete * from fee where id=" + id;
            int result = db.ExecuteSql(sqlcmd, null);
            return result;
        }
    }
}
