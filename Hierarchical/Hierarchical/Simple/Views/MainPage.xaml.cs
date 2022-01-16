using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hierarchical.Simple.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_Page1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Content1Page());
        }
        private async void Button_Clicked_Page2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Content2Page());
        }
        private async void Button_Clicked_Page3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Content3Page());
        }
    }
}