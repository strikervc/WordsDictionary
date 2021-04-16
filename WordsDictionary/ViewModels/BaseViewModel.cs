using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WordsDictionary.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected INavigationService NavigationService { get;  }
        protected IPageDialogService PageDialogService{ get;  }

        protected BaseViewModel (INavigationService navigationService, IPageDialogService pageDialogService) 
        {
            NavigationService = navigationService;

            PageDialogService = pageDialogService;

        }

    }
}
