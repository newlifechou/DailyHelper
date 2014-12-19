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
using DailyHelper.Common;

namespace DailyHelper
{
    /// <summary>
    /// Interaction logic for WindowPlanDetails.xaml
    /// </summary>
    public partial class WindowPlanDetails : Window
    {

        public WindowPlanDetails()
        {
            InitializeComponent();
        }
        public CrudOP OpType { get; set; }
        /// <summary>
        /// Public LoadData
        /// </summary>
        /// <param name="plandetails"></param>
        public void LoadData(Plan plandetails)
        {
            this.gridplandetails.DataContext = plandetails;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Plan p = gridplandetails.DataContext as Plan;
            //TODO:will add validation code here later  
            if (OpType==CrudOP.Create)
            {
                
            }
            else
            {

            }




        }

    }
}
