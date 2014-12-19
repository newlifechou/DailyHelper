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
        private PlanDB plandb = new PlanDB();
        private void LoadData()
        {
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

        /// <summary>
        /// Refresh will not reload the datafrom the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            wpd.Owner = this;
            wpd.UpdateData += updateData;
            wpd.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Plan currentplan = lstPlan.SelectedItem as Plan;
            WindowPlanDetails wpd = new WindowPlanDetails();
            wpd.LoadData(currentplan);
            wpd.OpType = CrudOP.Update;
            wpd.Owner = this;
            wpd.UpdateData += updateData;
            wpd.ShowDialog();
        }
        private void updateData(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this?","Delete?",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                Plan p = lstPlan.SelectedItem as Plan;
                int result = plandb.DeletePlan(p);
                if (result > 0)
                {
                    MessageBox.Show("Success");
                    updateData(this, null);
                }
            }
        }
    }
}
