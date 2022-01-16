using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hierarchical
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_Simple(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Hierarchical.Simple.Views.MainPage());
        }
        private async void Button_Clicked_MVVM(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Hierarchical.MVVM.Views.MainPage());
        }
    }
}