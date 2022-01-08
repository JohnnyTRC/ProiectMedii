using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestaurantModel;
using System.Data.Entity;
using System.Data;
using System.Windows.Controls;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {

        ActionState action = ActionState.Nothing;
        RestaurantEntitiesModel ctx = new RestaurantEntitiesModel();
        CollectionViewSource customerVSource;
        CollectionViewSource menuVSource;
        CollectionViewSource customerOrdersVSource;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource customerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("customerViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // customerViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource menuViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("menuViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // menuViewSource.Source = [generic data source]
            customerVSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("customerViewSource")));
            customerVSource.Source = ctx.Customers.Local;
            ctx.Customers.Load();

            menuVSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("menuViewSource")));
            menuVSource.Source = ctx.Menus.Local;
            ctx.Menus.Load();

            customerOrdersVSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("customerOrdersViewSource")));

            //customerOrdersVSource.Source = ctx.Orders.Local;
            ctx.Orders.Load();
            ctx.Menus.Load();
            cmbClienti.ItemsSource = ctx.Customers.Local;
            //cmbClienti.DisplayMemberPath = "NumeClient";
            cmbClienti.SelectedValuePath = "ClientId";
            cmbMeniu.ItemsSource = ctx.Menus.Local;
            //cmbMeniu.DisplayMemberPath = "NumeProdus";
            cmbMeniu.SelectedValuePath = "ProdusId";
            BindDataGrid();
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }
        private void btnNextC_Click(object sender, RoutedEventArgs e)
        {
            customerVSource.View.MoveCurrentToNext();
        }
        private void btnPrevC_Click(object sender, RoutedEventArgs e)
        {
            customerVSource.View.MoveCurrentToPrevious();
        }

        private void btnNextM_Click(object sender, RoutedEventArgs e)
        {
            menuVSource.View.MoveCurrentToNext();
        }
        private void btnPrevM_Click(object sender, RoutedEventArgs e)
        {
            menuVSource.View.MoveCurrentToPrevious();
        }

        private void SaveCustomers()
        {
            Customer customer = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    customer = new Customer()
                    {
                        NumeClient = numeClientTextBox.Text.Trim(),
                        PrenumeClient = prenumeClientTextBox.Text.Trim(),
                        NrTelefon = nrTelefonTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Customers.Add(customer);
                    customerVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    customer = (Customer)customerDataGrid.SelectedItem;
                    customer.NumeClient = numeClientTextBox.Text.Trim();
                    customer.PrenumeClient = prenumeClientTextBox.Text.Trim();
                    customer.NrTelefon = nrTelefonTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    customer = (Customer)customerDataGrid.SelectedItem;
                    ctx.Customers.Remove(customer);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                customerVSource.View.Refresh();
            }

        }

        private void SaveMenu()
        {
            RestaurantModel.Menu menu = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    menu = new RestaurantModel.Menu()
                    {
                        NumeProdus = numeProdusTextBox.Text.Trim(),
                        Pret = float.Parse(pretTextBox.Text.Trim())
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Menus.Add(menu);
                    menuVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    menu = (RestaurantModel.Menu)menuDataGrid.SelectedItem;
                    menu.NumeProdus = numeProdusTextBox.Text.Trim();
                    menu.Pret = float.Parse(pretTextBox.Text.Trim());
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    menu = (RestaurantModel.Menu)menuDataGrid.SelectedItem;
                    ctx.Menus.Remove(menu);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                menuVSource.View.Refresh();
            }

        }

        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }

        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlRestaurant.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Customers":
                    SaveCustomers();
                    break;
                case "Inventory":
                    SaveMenu();
                    break;
                case "Orders":
                    SaveOrders();
                    break;
            }
            ReInitialize();
        }

        private void SaveOrders()
        {
            Order order = null;
            if (action == ActionState.New)
            {
                try
                {
                    Customer customer = (Customer)cmbClienti.SelectedItem;
                    RestaurantModel.Menu menu = (RestaurantModel.Menu)cmbMeniu.SelectedItem;
                    //instantiem Order entity
                    order = new Order()
                    {

                        ClientId = customer.ClientId,
                        ProdusId = menu.ProdusId
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Orders.Add(order);
                    //salvam modificarile
                    ctx.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
           if (action == ActionState.Edit)
            {
                dynamic selectedOrder = ordersDataGrid.SelectedItem;
                try
                {
                    int curr_id = selectedOrder.ComandaId;
                    var editedOrder = ctx.Orders.FirstOrDefault(s => s.ComandaId == curr_id);
                    if (editedOrder != null)
                    {
                        editedOrder.ClientId = Int32.Parse(cmbClienti.SelectedValue.ToString());
                        editedOrder.ProdusId = Convert.ToInt32(cmbMeniu.SelectedValue.ToString());
                        //salvam modificarile
                        ctx.SaveChanges();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                BindDataGrid();
                // pozitionarea pe item-ul curent
                customerOrdersVSource.View.MoveCurrentTo(selectedOrder);
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    dynamic selectedOrder = ordersDataGrid.SelectedItem;
                    int curr_id = selectedOrder.ComandaId;
                    var deletedOrder = ctx.Orders.FirstOrDefault(s => s.ComandaId == curr_id);
                    if (deletedOrder != null)
                    {
                        ctx.Orders.Remove(deletedOrder);
                        ctx.SaveChanges();
                        MessageBox.Show("Comanda a fost stearsa cu succes!", "Message");
                        BindDataGrid();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BindDataGrid()
        {
            var queryOrder = from ord in ctx.Orders
                             join cust in ctx.Customers on ord.ClientId equals
                             cust.ClientId
                             join inv in ctx.Menus on ord.ProdusId
                 equals inv.ProdusId
                             select new
                             {
                                 ord.ComandaId,
                                 ord.ProdusId,
                                 ord.ClientId,
                                 cust.NumeClient,
                                 cust.PrenumeClient,
                                 inv.NumeProdus,
                                 inv.Pret

                             };
            customerOrdersVSource.Source = queryOrder.ToList();
        }
    }
}
