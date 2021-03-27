using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WordsDictionary.Models;
using WordsDictionary.Services;
using Xamarin.Forms;

namespace WordsDictionary.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public ICommand GetWordCommand { get; set; }
        
        public string Word { get; set; }

        public string Category { get; set; }

        Category WordCategories = new Category();

        public CategoryViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            GetWordCommand = new Command(async () => await GetCategory());
        }

        public async Task GetCategory()
        {
            WordsService wordCategoryApi = new WordsService(config.APIKey);
            WordCategories = await wordCategoryApi.GetCategory(Word);

            Category = WordCategories.Categories[0];
            await PageDialogService.DisplayAlertAsync("Category", $"This word belongs to the category: {Category}", "Ok");

        }
        
    }
}
