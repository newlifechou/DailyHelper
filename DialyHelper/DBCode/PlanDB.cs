using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using DialyHelper.Models;

namespace DialyHelper
{
    public class PlanDB
    {
        private DBHelper db = new DBHelper();
        public List<Plan> GetPlans()
        {
            string sqlcmd = "select id,title,content,starttime,endtime,priority,isfinished,remark,needremind,remindtime from plan order by priority desc";
            OleDbDataReader dr = db.GetDBReader(sqlcmd, null);

            List<Plan> plans = new List<Plan>();
            while (dr.Read())
            {
                Plan p = new Plan();
                p.ID = dr.GetInt32(0);
                p.Title = dr.GetString(1);
                p.Content = dr.GetString(2);
                p.StartTime = dr.GetDateTime(3);
                p.EndTime = dr.GetDateTime(4);
                p.Priority = dr.GetInt32(5);
                p.IsFinished = dr.GetBoolean(6);
                p.Remark =dr.IsDBNull(7)? null: dr.GetString(7);
                p.NeedRemind = dr.GetBoolean(8);

                if (dr.IsDBNull(9))
                {
                    p.RemindTime = null;
                }
                else
                {
                    p.RemindTime = dr.GetDateTime(9);
                }

                plans.Add(p);
            }
            dr.Close();
            return plans;
        }
    }
}
