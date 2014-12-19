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
using DailyHelper.Common;

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

        private ListCollectionView planview;
        private void LoadData()
        {
            PlanDB plandb = new PlanDB();
            List<Plan> plans = plandb.GetPlans(null);
            lstPlan.ItemsSource = plans;
            //get the listcollectionview from the listbox item source;
            planview = CollectionViewSource.GetDefaultView(lstPlan.ItemsSource) as ListCollectionView;
            planview.Filter = (item) =>
            {
                Plan p = item as Plan;
                return p.IsFinished == false;
            };
            if (lstPlan.Items.Count > 0)
            {
                lstPlan.SelectedIndex = 0;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            int filter = cboFilter.SelectedIndex;
            switch (filter)
            {
                case 0:
                    planview.Filter = (item) =>
                    {
                        Plan p = item as Plan;
                        return p.IsFinished == false;
                    };
                    break;
                case 1:
                    planview.Filter = (item) =>
                    {
                        Plan p = item as Plan;
                        return p.IsFinished == true;
                    };
                    break;
                case 2:
                    planview.Filter = null;
                    break;
                default:
                    break;
            }
            if (lstPlan.Items.Count > 0)
            {
                lstPlan.SelectedIndex = 0;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Plan newplan = new Plan();
            WindowPlanDetails wpd = new WindowPlanDetails();
            wpd.LoadData(newplan);
            wpd.OpType = CrudOP.Create;
            wpd.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Plan currentplan = lstPlan.SelectedItem as Plan;
            WindowPlanDetails wpd = new WindowPlanDetails();
            wpd.LoadData(currentplan);
            wpd.OpType = CrudOP.Update;
            wpd.ShowDialog();
        }
    }
}
