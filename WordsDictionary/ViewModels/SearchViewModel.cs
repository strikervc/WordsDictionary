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
    public class SearchViewModel : BaseViewModel
    {    
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        private IPageDialogService _wordsService;
        public ICommand WordCommand { get; set; }

        public Definition definition = new Definition();

        public Pronunciation pronunciation = new Pronunciation();
        public string Word { get; set; }        
        public string Pronunciation { get; set; }       
        public SearchViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            WordCommand = new Command(OnWord);
            _wordsService = pageDialogService;
            
        }
        private async void OnWord()
        {
            WordsService wordService = new WordsService(Config.ApiKey);

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {

                Items.Clear();
               
                pronunciation = await wordService.GetPronunciationAsync(Word);
                definition = await wordService.GetDefinitionAsync(Word);
                foreach (Item item in definition.Definitions)
                {
                    Items.Add(item);
                }


                await _wordsService.DisplayAlertAsync("Search completed", $"All definitions for {Word} listed bellow on screen", "Ok");
            }
            else
            {
                await _wordsService.DisplayAlertAsync("Error of access", "There is no internet connection", "Ok");            
            }
        }
    }
}
