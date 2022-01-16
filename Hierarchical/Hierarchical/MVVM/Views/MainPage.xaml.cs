using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Hierarchical.MVVM.Services;
using Hierarchical.MVVM.ViewModels;

namespace Hierarchical.MVVM.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(DependencyService.Get<INaviService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Initialize ViewModel
            ViewModel?.Init();
        }
    }
}