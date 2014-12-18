using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for WindowPlanDetails.xaml
    /// </summary>
    public partial class WindowPlanDetails : Window
    {
        /// <summary>
        /// Plan Interface
        /// </summary>
        public Plan PlanDetails { get; set; }
        public WindowPlanDetails()
        {
            InitializeComponent();
            //this.gridplandetails.DataContext = PlanDetails;
        }
    }
}
