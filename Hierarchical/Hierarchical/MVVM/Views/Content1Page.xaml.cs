using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Hierarchical.MVVM.Services;
using Hierarchical.MVVM.ViewModels;
using Hierarchical.Services;


namespace Hierarchical.MVVM.Views
{
    public partial class Content1Page : ContentPage
    {
        Content1ViewModel ViewModel => BindingContext as Content1ViewModel;

        public Content1Page()
        {
            InitializeComponent();

            BindingContext = new Content1ViewModel(
                DependencyService.Get<INaviService>(),
                DependencyService.Get<IGeoLocationService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Initialize ViewModel
            ViewModel?.Init();
        }
    }
}