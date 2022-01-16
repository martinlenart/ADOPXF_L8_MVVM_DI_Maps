using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Hierarchical.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            #region Initialize Xamarin.Forms.Maps
            Xamarin.FormsMaps.Init("INSERT_AUTH_TOKEN_HERE");
            Windows.Services.Maps.MapService.ServiceToken = "INSERT_AUTH_TOKEN_HERE";
            #endregion

            LoadApplication(new Hierarchical.App());
        }
    }
}
