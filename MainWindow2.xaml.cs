using Microsoft.Web.WebView2.Core;
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

namespace dast
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
        }
        
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void RadioHome_Checked(object sender, RoutedEventArgs e)
        {
            WebViewPages.CoreWebView2?.ExecuteScriptAsync($"jumpTo('index')");
        }

        private void RadioGame_Checked(object sender, RoutedEventArgs e)
        {
            WebViewPages.CoreWebView2?.ExecuteScriptAsync($"jumpTo('game')");
        }

        private void RadioEssay_Checked(object sender, RoutedEventArgs e)
        {
            WebViewPages.CoreWebView2?.ExecuteScriptAsync($"jumpTo('essay')");
        }

        private void RadioAdmin_Checked(object sender, RoutedEventArgs e)
        {
            WebViewPages.CoreWebView2?.ExecuteScriptAsync($"jumpTo('admin')");
        }

        private void RadioCompetition_Checked(object sender, RoutedEventArgs e)
        {
            WebViewPages.CoreWebView2?.ExecuteScriptAsync($"jumpTo('competition')");
        }

        private void RadioStore_Checked(object sender, RoutedEventArgs e)
        {
            WebViewPages.CoreWebView2?.ExecuteScriptAsync($"jumpTo('store')");
        }

        private void RadioSetting_Checked(object sender, RoutedEventArgs e)
        {
            WebViewPages.CoreWebView2?.ExecuteScriptAsync($"jumpTo('setting')");
        }

        private async void InitWebView(object sender, RoutedEventArgs e)
        {
            //WebViewPages.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            var env = await CoreWebView2Environment.CreateAsync(null, null, new CoreWebView2EnvironmentOptions("--allow-file-access-from-files"));
            await WebViewPages.EnsureCoreWebView2Async(env);
            // 禁用状态栏（状态提示框）
            WebViewPages.CoreWebView2.Settings.IsStatusBarEnabled = false;
            WebViewPages.CoreWebView2.Navigate(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages/Content/index.html")).AbsoluteUri);
            WebViewPages.CoreWebView2.WebMessageReceived += GetMessage;
        }

        private void GetMessage(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string msg = e.TryGetWebMessageAsString();
            Console.WriteLine($"收到前端消息：{msg}");
            if (msg == "home")
            {
                Dispatcher.Invoke(() => rdHome.IsChecked = true);
            }else if (msg == "game")
            {
                Dispatcher.Invoke(() => rdGame.IsChecked = true);
            }
            else if (msg == "essay")
            {
                Dispatcher.Invoke(() => rdEssay.IsChecked = true);
            }
            else if (msg == "competition")
            {
                Dispatcher.Invoke(() => rdCompetition.IsChecked = true);
            }
            else if (msg == "store")
            {
                Dispatcher.Invoke(() => rdStore.IsChecked = true);
            }
            else if (msg == "admin")
            {
                Dispatcher.Invoke(() => rdAdmin.IsChecked = true);
            }
            else if (msg == "setting")
            {
                Dispatcher.Invoke(() => rdSetting.IsChecked = true);
            }
        }

        
    }
}
