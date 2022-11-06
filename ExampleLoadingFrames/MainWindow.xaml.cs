using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ExampleLoadingFrames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
           InitializeAsync();
        }

        private async void InitializeAsync()
        {

            await this.Browser.EnsureCoreWebView2Async();

            this.Browser.CoreWebView2.OpenDevToolsWindow();

            string script = ReadProjectFile(@"WebPage\javaSrcriptToLoad.js");
            var res = await this.Browser.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(script);

            this.Browser.CoreWebView2.FrameCreated += CoreWebView2_FrameCreated;

            this.Browser.CoreWebView2.SetVirtualHostNameToFolderMapping(@"testframe.app", System.IO.Directory.GetCurrentDirectory() + @"\", CoreWebView2HostResourceAccessKind.Allow);

            this.Browser.Source = new Uri(@"https://testframe.app/WebPage/MainHTMLPage.html");

        }

        private string ReadProjectFile(string aName)
        {
            return System.IO.File.ReadAllText(System.IO.Path.Combine(AppContext.BaseDirectory, aName));
        }

        private void CoreWebView2_FrameCreated(object? sender, CoreWebView2FrameCreatedEventArgs e)
        {
            Debug.Print($"Load Frame With Name: {e.Frame.Name}");
        }
    }
}
