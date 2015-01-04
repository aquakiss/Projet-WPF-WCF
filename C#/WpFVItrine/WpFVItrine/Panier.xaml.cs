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
using System.Windows.Shapes;
//using ClassLibDll;

namespace WpFVItrine
{
    /// <summary>
    /// Logique d'interaction pour Panier.xaml
    /// </summary>
    public partial class Panier : Window
    {
        public ObservableCollection<object> ElPanier = new ObservableCollection<object>();
        object[] Listelem;
        public Panier(string tok)
        {
            InitializeComponent();
            Token.Text = tok;

            using (Service.Service1Client client = new Service.Service1Client())
            {
                Listelem = client.getPanier(Token.Text);
            }
            for (int i = 0; i < Listelem.Length; i++)
            {
                ElPanier.Add(Listelem[i]);
            }
            Paniers.ItemsSource = ElPanier;
        }

        private void AjoutPlus_Click(object sender, RoutedEventArgs e)
        {
            //ElPanier.Quantite
        }

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MoinsQt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            WpFVItrine.Window1 window = new WpFVItrine.Window1(Token.Text);
            this.Close();
            window.ShowDialog();
        }
    }
}
