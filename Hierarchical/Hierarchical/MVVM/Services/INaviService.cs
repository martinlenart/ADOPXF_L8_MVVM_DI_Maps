using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Hierarchical.MVVM.ViewModels;

namespace Hierarchical.MVVM.Services
{
    public interface INaviService
    {
        bool CanGoBack { get; }

        Task GoBack();

        Task NavigateTo<TVM>()where TVM : BaseViewModel;

        Task NavigateTo<TVM, TParameter>(TParameter parameter) where TVM : BaseViewModel;

        void RemoveLastView();

        void ClearBackStack();

        event PropertyChangedEventHandler CanGoBackChanged;
    }
}