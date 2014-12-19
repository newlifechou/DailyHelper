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
    public class PlanDB
    {
        private DBHelper db = new DBHelper();
        /// <summary>
        /// GetPlans
        /// </summary>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public List<Plan> GetPlans(string sqlwhere)
        {
            string sqlcmd = "select id,title,content,starttime,endtime,priority,isfinished,remark,needremind,remindtime from plan";
            if (sqlwhere != null)
            {
                sqlcmd += " " + sqlwhere;
            }
            sqlcmd += "  order by priority desc";
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
                p.Remark = dr.IsDBNull(7) ? null : dr.GetString(7);
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

        public int SavePlan(Plan plan, CrudOP OpType)
        {
            string sqlcmd;
            int result;
            if (OpType == CrudOP.Create)
            {
                sqlcmd = "insert into plan(title,content,starttime,endtime,priority,isfinished,remark,needremind,remindtime)" +
                "values(?,?,?,?,?,?,?,?,?)";
                OleDbParameter[] paras = new OleDbParameter[] { 
                new OleDbParameter("?",plan.Title),
                new OleDbParameter("?",plan.Content),
                new OleDbParameter("?",plan.StartTime),
                new OleDbParameter("?",plan.EndTime),
                new OleDbParameter("?",plan.Priority),
                new OleDbParameter("?",plan.IsFinished),
                new OleDbParameter("?",plan.Remark),
                new OleDbParameter("?",plan.NeedRemind),
                new OleDbParameter("?",plan.NeedRemind)
                };
                result = db.ExecuteSql(sqlcmd, paras);
            }
            else
            {
                sqlcmd = "update plan set title=?,content=?,starttime=?,endtime=?,priority=?,isfinished=?," +
                    "remark=?,needremind=?,remindtime=? where id=?";
                OleDbParameter[] paras = new OleDbParameter[] { 
                new OleDbParameter("?",plan.Title),
                new OleDbParameter("?",plan.Content),
                new OleDbParameter("?",plan.StartTime),
                new OleDbParameter("?",plan.EndTime),
                new OleDbParameter("?",plan.Priority),
                new OleDbParameter("?",plan.IsFinished),
                new OleDbParameter("?",plan.Remark),
                new OleDbParameter("?",plan.NeedRemind),
                new OleDbParameter("?",plan.RemindTime),
                new OleDbParameter("?",plan.ID)
                };
                result = db.ExecuteSql(sqlcmd, paras);
            }
            return result;
        }

        public int DeletePlan(Plan plan)
        {
            string sqlcmd = "delete * from plan where id="+plan.ID;
            int result = db.ExecuteSql(sqlcmd, null);
            return result;
        }
    }
}
