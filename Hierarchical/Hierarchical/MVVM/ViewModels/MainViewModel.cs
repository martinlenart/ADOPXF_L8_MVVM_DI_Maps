using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Hierarchical.MVVM.Services;

namespace Hierarchical.MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command GoToPage1 => new Command(async () => await NavigationService.NavigateTo<Content1ViewModel>());
        public Command GoToPage2 => new Command(async () => await NavigationService.NavigateTo<Content2ViewModel>());
        public Command GoToPage3 => new Command(async () => await NavigationService.NavigateTo<Content3ViewModel>());

        public MainViewModel(INaviService naviService) : base(naviService)
        {
            //Code for creating the ViewModel
        }

        public override void Init()
        {
            //Code for initialize the ViewModel
        }
    }
}
