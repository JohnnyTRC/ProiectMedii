using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectMobile.Data;
using System.IO;

namespace ProiectMobile
{
    public partial class App : Application
    {
        static OrderListDatabase database;
        public static OrderListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   OrderListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "OrderList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            MainPage = new NavigationPage(new Cake());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
