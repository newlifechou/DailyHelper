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
    /// Interaction logic for WindowFeeDetails.xaml
    /// </summary>
    public partial class WindowFeeDetails : Window
    {
        public WindowFeeDetails()
        {
            InitializeComponent();
        }
        public CrudOP opType { get; set; }
        public void LoadData(Fee fee)
        {
            gridFee.DataContext = fee;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isvalid = (new WindowValid()).IsValid(this);
            if (!isvalid)
            {
                MessageBox.Show("Sorry,The Validation is not pass");
                return;
            }
            FeeDB fdb = new FeeDB();
            Fee fee = gridFee.DataContext as Fee;
            try
            {
                int result = fdb.Save(fee, opType);
                if (result > 0)
                {
                    MessageBox.Show("Success!");
                }
                else
                {
                    MessageBox.Show("Not Success!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
