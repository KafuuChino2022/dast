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
            InitWebView();
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
            string htmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages/Content/index.html");
            WebViewPages.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }

        private void RadioGame_Checked(object sender, RoutedEventArgs e)
        {
            string htmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages/Content/game.html");
            WebViewPages.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }

        private void RadioEssay_Checked(object sender, RoutedEventArgs e)
        {
            string htmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages/Content/essay.html");
            WebViewPages.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }

        private void RadioAdmin_Checked(object sender, RoutedEventArgs e)
        {
            string htmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages/Content/admin.html");
            WebViewPages.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }

        private void RadioCompetition_Checked(object sender, RoutedEventArgs e)
        {
            string htmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages/Content/competition.html");
            WebViewPages.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }

        private void RadioStore_Checked(object sender, RoutedEventArgs e)
        {
            string htmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages/Content/store.html");
            WebViewPages.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }

        private void RadioSetting_Checked(object sender, RoutedEventArgs e)
        {
            string htmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages/Content/setting.html");
            WebViewPages.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }

        // 假设你的 XAML 中有一个 WebView2 控件
        // <WebView2 x:Name="webView" HorizontalAlignment="Stretch" VerticalAlignment="Stretch"/>

        private async void InitWebView()
        {
            WebViewPages.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            await WebViewPages.EnsureCoreWebView2Async();
            WebViewPages.CoreWebView2.WebMessageReceived += GetMessage;
        }

        private void GetMessage(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string msg = e.TryGetWebMessageAsString();
            if (msg == "1")
            {
                Dispatcher.Invoke(() => rdHome.IsChecked = true);
            }
        }

        
    }
}
