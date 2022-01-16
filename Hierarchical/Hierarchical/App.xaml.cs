using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Hierarchical.MVVM.Services;
using Hierarchical.MVVM.ViewModels;
using Hierarchical.MVVM.Views;

namespace Hierarchical
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Start selection page of what model to demonstrate
            MainPage = new NavigationPage(new MainPage());

            //To Start Simple View directly
            //MainPage = new NavigationPage(new Hierarchical.Simple_Navi.Views.MainPage());

            //To Start MVVM directly
            //MainPage = new NavigationPage(new Hierarchical.MVVM_Navi.Views.MainPage());

            #region setup the MVVM Navigation Service 
            //Use the MainPage Navigation object for Service Navigation
            var navService = DependencyService.Get<INaviService>() as NaviService;
            navService.Navigation = MainPage.Navigation;

            //Register View-ViewModel relationship in the navigation service
            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            navService.RegisterViewMapping(typeof(Content1ViewModel), typeof(Content1Page));
            navService.RegisterViewMapping(typeof(Content2ViewModel), typeof(Content2Page));
            navService.RegisterViewMapping(typeof(Content3ViewModel), typeof(Content3Page));
            #endregion

            #region setup the Location Service

            #endregion
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
