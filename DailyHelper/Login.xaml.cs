using System;
using System.Collections.Generic;
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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            this.InitializeComponent();

            // 在此点之下插入创建对象所需的代码。
        }

        private void btnunlock_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            account.Password = txtpassword.Password;
            if (!string.IsNullOrEmpty(account.Password))
            {
                AccountDB adb = new AccountDB();
                try
                {
                    if (adb.LogIn(account))
                    {
                        MainWindow mw = new MainWindow();
                        this.Close();
                        mw.Show();
                    }
                    else
                    {
                       txtLogInfo.Text="Unlock Code is Wrong!";
                       txtpassword.Password = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                txtLogInfo.Text = "Unlock code is not allowed to be null!";
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}