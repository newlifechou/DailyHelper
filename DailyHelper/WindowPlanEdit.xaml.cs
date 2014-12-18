using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DailyHelper.Models;

namespace DailyHelper
{
    /// <summary>
    /// Interaction logic for WindowPlanEdit.xaml
    /// </summary>
    public partial class WindowPlanEdit : Window
    {
        public WindowPlanEdit()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            int filter = cboFilter.SelectedIndex;
            string sqlwhere;
            switch (filter)
            {
                case 0:
                    sqlwhere = "where isfinished=0";
                    break;
                case 1:
                    sqlwhere = "where isfinished=-1";
                    break;
                case 2:
                    sqlwhere = null;
                    break;
                default:
                    sqlwhere = null;
                    break;
            }

            PlanDB plandb = new PlanDB();
            List<Plan> plans = plandb.GetPlans(sqlwhere);
            lstPlan.ItemsSource = plans;
            if (lstPlan.Items.Count>0)
            {
                lstPlan.SelectedIndex = 0;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
