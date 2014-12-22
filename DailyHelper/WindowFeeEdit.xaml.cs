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
    /// Interaction logic for WindowFeeEdit.xaml
    /// </summary>
    public partial class WindowFeeEdit : Window
    {
        public WindowFeeEdit()
        {
            InitializeComponent();
            LoadData();
        }
        private FeeDB fdb = new FeeDB();
        private void LoadData()
        {
            List<Fee> fees = fdb.GetFeeList();
            lstFee.ItemsSource = fees;
            if (lstFee.Items.Count > 0)
            {
                lstFee.SelectedIndex = 0;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Fee fee = new Fee();
            fee.ItemTime = DateTime.Now;
            fee.ReimburseTime = DateTime.Now;
            WindowFeeDetails wfd = new WindowFeeDetails();
            wfd.LoadData(fee);
            wfd.opType = CrudOP.Create;
            wfd.Owner = this;
            wfd.UpdateData += wfd_UpdateData;
            wfd.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Fee fee = lstFee.SelectedItem as Fee;
            WindowFeeDetails wfd = new WindowFeeDetails();
            wfd.LoadData(fee);
            wfd.opType = CrudOP.Update;
            wfd.Owner = this;
            wfd.UpdateData+=wfd_UpdateData;
            wfd.ShowDialog();
        }

        private void wfd_UpdateData(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstFee.SelectedItems.Count > 0)
            {
                int id = (lstFee.SelectedItem as Fee).ID;
                if (MessageBox.Show("Are you sure to delete this record?", "Deleting?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    fdb.Delete(id);
                    LoadData();
                }
            }
        }
    }
}
