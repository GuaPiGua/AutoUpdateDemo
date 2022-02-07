using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AutoUpdateDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AutoUpdater.Start("https://tmw-1255523279.cos.ap-shanghai.myqcloud.com/test.xml");
            AutoUpdater.ApplicationExitEvent += delegate
            {
                System.Windows.MessageBox.Show("12312313");
                System.Windows.Application.Current.Shutdown();
            };
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            
            //AutoUpdater.CheckForUpdateEvent += Class1.AutoUpdaterOnCheckForUpdateEvent;



        }

       public void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            
            if (AutoUpdater.DownloadUpdate(args))
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

    }
}
