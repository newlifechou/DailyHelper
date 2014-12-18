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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DailyHelper.Models;

namespace DailyHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// Load Data
        /// </summary>
        private void LoadData()
        {
            PlanDB plandb = new PlanDB();
            List<Plan> plans = plandb.GetPlans("where isfinished=0");
            lstPlan.ItemsSource = plans;
            if (lstPlan.Items.Count > 0)
            {
                lstPlan.SelectedIndex = 0;
            }
            FeeDB feedb=new FeeDB();
            List<Fee> fees = feedb.GetFeeList();
            lstFee.ItemsSource = fees;
            if (lstFee.Items.Count>0)
            {
                lstFee.SelectedIndex = 0;
            }
        }
        private void menuEditPlan_Click(object sender, RoutedEventArgs e)
        {
            WindowPlanEdit wpe = new WindowPlanEdit();
            wpe.Owner = this;
            wpe.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
