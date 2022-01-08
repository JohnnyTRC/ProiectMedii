using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectMobile.Models;

namespace ProiectMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var olist = (OrderList)BindingContext;
            await App.Database.SaveOrderListAsync(olist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var olist = (OrderList)BindingContext;
            await App.Database.DeleteOrderListAsync(olist);
            await Navigation.PopAsync();
        }

        async void listView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Cake
                {
                    BindingContext = e.SelectedItem as Meniu
                });
            }
        }
    }
}