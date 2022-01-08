using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectMobile.Models;

namespace ProiectMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cake : ContentPage
    {
        public IEnumerable<Meniu> GetPrajituri(string searchText = null)
        {
            var prajituri = new List<Meniu>
            {
                new Meniu{NumeProdus = "Felicia", Pret="8 lei", ImageURL="https://upload.wikimedia.org/wikipedia/commons/b/b2/Savarine.jpg"},
                new Meniu{NumeProdus = "Amandina", Pret="8 lei", ImageURL="https://upload.wikimedia.org/wikipedia/commons/e/eb/French_chocolate_cake.jpg"},
                new Meniu{NumeProdus="Ice cream cake",Pret="16 lei", ImageURL="https://upload.wikimedia.org/wikipedia/commons/6/67/Ice_cream_cake.jpg"},
                new Meniu{NumeProdus="Truffle Cake",Pret="12 lei", ImageURL="https://upload.wikimedia.org/wikipedia/commons/8/85/Chocolate_Truffle_Cake_%285354498813%29.jpg" },
                new Meniu{NumeProdus="Tiramisu",Pret="9 lei", ImageURL="https://upload.wikimedia.org/wikipedia/commons/e/ef/Piece_of_chocolate_cake_on_a_white_plate_decorated_with_chocolate_sauce.jpg"},
                new Meniu{NumeProdus="Pavlova",Pret="15 lei", ImageURL="https://upload.wikimedia.org/wikipedia/commons/a/ab/Pavlova_cake.jpg"}
            };

            if (String.IsNullOrWhiteSpace(searchText))
                return prajituri;
            
            else return prajituri.Where(p => p.NumeProdus.StartsWith(searchText)) ;
        }
        public Cake()
        {
            InitializeComponent();
            listView.ItemsSource = GetPrajituri();

        }

        async void ListaComenzi(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListEntryPage
            {
                BindingContext = new ListEntryPage()
            });
        }

        async void ComandaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderPage
            {
                BindingContext = new OrderList()
            });
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetPrajituri(e.NewTextValue);
        }
    }
}