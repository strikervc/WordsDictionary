using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailPage : MasterDetailPage
    {
        public MainMasterDetailPage()
        {
            InitializeComponent();
            navigationDrawerList.ItemsSource = GetMasterPageLists();
        }
        private void OnMenuSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageList)e.SelectedItem;

            if (e.SelectedItem == null) return;

            ((ListView)sender).SelectedItem = null;

            if (item.Title == "About")
            {
                Detail.Navigation.PushAsync(new AboutPage());
                IsPresented = false;
            }
            else
            {
                Application.Current.Properties["MenuName"] = item.Title;
                Detail = new NavigationPage(new HomeTabbedPage());
                IsPresented = false;
            }
            
        }
        List<MasterPageList> GetMasterPageLists()
        {
            return new List<MasterPageList>
            {
                new MasterPageList() { Title = "Definition", Icon = "Definition.png" },
                new MasterPageList() { Title = "Synonym", Icon = "Synonym.png" },
                new MasterPageList() { Title = "About", Icon = "About.png" }
            };
        }
        public class MasterPageList
        {
            public string Title { get; set; }
            public string Icon { get; set; }
        }

       
    }
}

