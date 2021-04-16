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
    public partial class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("MenuName"))
            {
                var menuName = Application.Current.Properties["MenuName"].ToString();
                if (menuName == "Synonym")
                {
                    this.CurrentPage = Children[1];
                }
            }
        }
    }
}