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
        /// updatedate event
        /// </summary>
        public event EventHandler UpdateData;
        public void OnUpdateData(object sender, EventArgs e)
        {
            if (UpdateData != null)
            {
                UpdateData(this, e);
            }
        }
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
            //遍历grid，查找validationerror
            WindowValid wv = new WindowValid();
            if (!wv.IsValid(this))
            {
                MessageBox.Show("The validation is not pass");
                return;
            }


            Plan p = gridplandetails.DataContext as Plan;
            PlanDB db = new PlanDB();
            int result=0;
            try
            {
                result = db.SavePlan(p, this.OpType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (result > 0)
            {
                MessageBox.Show("Successful");
                OnUpdateData(this, null);
                this.Close();
            }
        }

    }
}
