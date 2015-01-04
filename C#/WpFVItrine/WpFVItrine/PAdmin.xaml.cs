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

namespace WpFVItrine
{
    /// <summary>
    /// Logique d'interaction pour PAdmin.xaml
    /// </summary>
    public partial class PAdmin : Window
    {
        object[] ListeArticle;
        public PAdmin(string id)
        {
            InitializeComponent();
            Token.Text = id;
            using (Service.Service1Client client = new Service.Service1Client())
            {
                ListeArticle = client.getListArticle();
            }
            ListeProduits.ItemsSource = ListeArticle;
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Service.Service1Client client = new Service.Service1Client())
            {
                ListeArticle = client.getListArticle();
            }

        }

        private void AddArticl_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Deconnect_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SuppProd_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
