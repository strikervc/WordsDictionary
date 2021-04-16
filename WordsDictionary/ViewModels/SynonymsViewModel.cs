using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WordsDictionary.Models;
using WordsDictionary.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WordsDictionary.ViewModels
{
    public class SynonymsViewModel : BaseViewModel
    {
        public string Word { get; set; }
        public ICommand InstanceCommand { get; set; }

        Synonym synonym = new Synonym();
        ObservableCollection<string> Synonims { get; set; } = new ObservableCollection<string>();

        public SynonymsViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            InstanceCommand = new Command(OnInstanceCommand);

        }

        public async void OnInstanceCommand()
        {
            WordsService instanceApiService = new WordsService(Config.ApiKey);

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                synonym = await instanceApiService.GetInstanceAsync(Word);

                await PageDialogService.DisplayAlertAsync("Synonym", $"{synonym.Synonyms[0]}", "Ok");    

            }
            else 
            {
                await PageDialogService.DisplayAlertAsync("Alert", "No hay una conexión a internet", "Ok");
            }
        }
    }
}
