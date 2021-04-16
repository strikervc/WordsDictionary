using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefinitionPage : ContentPage
    {

        public DefinitionPage()
        {
            InitializeComponent();

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            ((ListView)sender).SelectedItem = null;
        }
    }
}