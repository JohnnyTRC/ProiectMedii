using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectMobile.Models;
using ProiectMobile.Data;

namespace ProiectMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEntryPage : ContentPage
    {
        public ListEntryPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetOrderListsAsync();
        }
        async void MeniuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cake
            {
                BindingContext = new OrderList()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new OrderPage
                {
                    BindingContext = e.SelectedItem as OrderList
                });
            }
        }
    }
}