using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        List<Basket> baskets;

        Basket currentBasket;

        public MainWindow()
        {
            InitializeComponent();

            baskets = new List<Basket>();
            basketlIST.Items(baskets);
        }

        private void addBasketButton_Click(object sender, RoutedEventArgs e)
        {
            Basket bask = new Basket(Name.Text, int.Parse(Price.Text), int.Parse(Price.Text));
            baskets.Add(bask);

            ClearForm();
        }

        void ClearForm()
        {
            Name.Text = ""; Price.Text = ""; Quantity.Text = "";
        }
    }
}
