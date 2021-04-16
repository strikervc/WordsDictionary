using System;
using System.Collections.Generic;
using System.Text;

namespace WordsDictionary
{
    public static class Config
    {
        private static string apiKey;

        public static string ApiKey
        {
            get { return apiKey = "704ca8d251mshe6218a98dd2f799p114d43jsn0dae0dca77d3"; }
           
        }

        public const string HomePage = "HomePage";  
        public const string NavigationPage = "NavigationPage";  
        public const string MasterDetail = "Home";  
        public const string SearchPage = "Search";  
        public const string SynonymsPage = "Search";  
        public const string CategoryPage = "Search";  

    }
}
