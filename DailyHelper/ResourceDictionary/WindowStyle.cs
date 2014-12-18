using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class WindowStyle
    {
        private void WindowStyle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window win = ((FrameworkElement)sender).TemplatedParent as Window;
            win.DragMove();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Window win = ((FrameworkElement)sender).TemplatedParent as Window;
            win.Close();
        }
    }
}
