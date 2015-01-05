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
            using (Service.Service1Client client = new Service.Service1Client())
            {
                 client.AdmAddProd(AdtxBnam.Text, AdtxBpri.Text, AdtxBqt.Text, AdtxBresum.Text, AdtxBResu.Text);
            }
        }
        private void Deconnect_Click(object sender, RoutedEventArgs e)
        {
            WpFVItrine.MainWindow window = new WpFVItrine.MainWindow();
            this.Close();
            window.ShowDialog();
        }
        private void SuppProd_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Article article = button.DataContext as Article;
            using (Service.Service1Client client = new Service.Service1Client())
            {
                //client.SuppProdVit(article);
            }
        }

    }
}
