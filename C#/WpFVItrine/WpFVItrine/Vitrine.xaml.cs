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
using ClassLibDll;

namespace WpFVItrine
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Article[] ListeArticle;
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
            using (Service.Service1Client client = new Service.Service1Client())
            {
                //client.ElemAddInPani();
            }
        }

        private void GoToPanier_Click(object sender, RoutedEventArgs e)
        {
            WpFVItrine.Panier window = new WpFVItrine.Panier(Token.Text);
            this.Close();
            window.ShowDialog();
        }
    }
}