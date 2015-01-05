using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WpFVItrine.Service;
using ClassLibDll;
using System.Windows.Threading;

namespace WpFVItrine
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DispatcherTimer timer;
        object[] ListeArticle;
        public Window1(string id)
        {
            InitializeComponent();
            Token.Text = id;

            using (Service.Service1Client client = new Service.Service1Client())
            {
                ListeArticle = client.getListArticle();
            }
            /*foreach (Article produit in ListeArticle)
            {
                ListeProduits.Items.Add(produit.Nom + " " + produit.Prix + "€" + " " + produit.Quantite + " " + produit.Description);
            }*/
            ListeProduits.ItemsSource = ListeArticle;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += ReactOnTime;
            timer.Start();
        }

        void ReactOnTime(object sender, EventArgs e)
        {
            using (Service.Service1Client mainClient = new Service.Service1Client())
            {
                /*productTempTab = mainClient.getItems();
                products.Clear();
                for (int i = 0; i < productTempTab.Length; i++)
                {
                    products.Add(productTempTab[i]);
                }
                productTempTab = mainClient.getCart(token);
                cart.Clear();
                for (int i = 0; i < productTempTab.Length; i++)
                {
                    cart.Add(productTempTab[i]);
                }*/
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Service.Service1Client client = new Service.Service1Client())
            {
                ListeArticle = client.getListArticle();
            }

        }
        private void AddToPanier_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Article article = button.DataContext as Article;
            using (Service.Service1Client client = new Service.Service1Client())
            {
                client.ElemAddInPani(article, Token.Text);
            }
        }

        private void GoToPanier_Click(object sender, RoutedEventArgs e)
        {
            WpFVItrine.Panier window = new WpFVItrine.Panier(Token.Text);
            this.Close();
            window.ShowDialog();
        }

        private void Deconnect_Click(object sender, RoutedEventArgs e)
        {
            WpFVItrine.MainWindow window = new WpFVItrine.MainWindow();
            this.Close();
            window.ShowDialog();
        }
    }
}