using dast.Models.ViewModels;
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

            this.DataContext = new ButtonTitleModel();
            WebViewPages.Loaded += WebView2_Loaded;
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

        // 假设你的 XAML 中有一个 WebView2 控件
        // <WebView2 x:Name="webView" HorizontalAlignment="Stretch" VerticalAlignment="Stretch"/>

        private async void WebView2_Loaded(object sender, RoutedEventArgs e)
        {
            // 确保 WebView2 控件加载完毕
            await WebViewPages.EnsureCoreWebView2Async();

            // 禁用开发者工具
            WebViewPages.CoreWebView2.Settings.AreDevToolsEnabled = false;

            // 禁用浏览器控制台信息
            WebViewPages.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
        }

        private void InitWebPage(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            WebViewPages.DefaultBackgroundColor = System.Drawing.Color.Transparent;
        }
    }
}
