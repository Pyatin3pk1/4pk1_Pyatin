using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pz_14_RX_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Item> _items = new ObservableCollection<Item>();
        Item _item;

        public MainWindow()
        {
            InitializeComponent();
            ItemsDataGrid.ItemsSource = _items;
        }

        // Работу выполнили Пятин и Казаков
        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            var itemName = ItemNameTextBox.Text;
            var itemQuantity = int.Parse(ItemQuantityTextBox.Text);
            var itemPrice = decimal.Parse(ItemPriceTextBox.Text);

            _items.Add(new Item { Name = itemName, Quantity = itemQuantity, Price = itemPrice });
            ClearForm();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var totalCost = _items.Sum(item => item.TotalCost);
            var discount = totalCost * 0.1M; //10%
            var finish = totalCost - discount;

            TotalCostTextBox.Text = totalCost.ToString("C");
            DiscountTextBox.Text = discount.ToString("C");
            FinishTextBox.Text = finish.ToString("C");

            var observable = Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => (s, e) => handler(s, e),
                handler => _items.CollectionChanged += handler,
                handler => _items.CollectionChanged -= handler);

            observable.Subscribe(args =>
            {
                totalCost = _items.Sum(item => item.TotalCost);
                discount = totalCost * 0.1M;
                var finish = totalCost - discount;

                TotalCostTextBox.Text = totalCost.ToString("C");
                DiscountTextBox.Text = discount.ToString("C");
                FinishTextBox.Text = finish.ToString("C");
            });
        }
        void ClearForm()
        {
            ItemNameTextBox.Text = ""; ItemQuantityTextBox.Text = ""; ItemPriceTextBox.Text = "";
        }
        private void ItemsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _item = (Item)ItemsDataGrid.SelectedItem;
            ItemNameTextBox.Text = _item.Name;
            ItemQuantityTextBox.Text = _item.Quantity.ToString();
            ItemPriceTextBox.Text = _item.Price.ToString();
        }
        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            _items.Remove(_item);
            ClearForm();
        }
    }

}
