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
<<<<<<< HEAD
//using ClassLibDll;
using System.Windows.Threading;
=======
using ClassLibDll;
>>>>>>> 86fb9b46ad7225069b31efb678109f87bf59262e

namespace WpFVItrine
{
    /// <summary>
    /// Logique d'interaction pour Panier.xaml
    /// </summary>
    public partial class Panier : Window
    {
        public ObservableCollection<object> ElPanier = new ObservableCollection<object>();
        object[] Listelem;
        DispatcherTimer timer;
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
            
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += ReactOnTime;
            timer.Start();
        }

        void ReactOnTime(object sender, EventArgs e)
        {
            using (Service.Service1Client mainClient = new Service.Service1Client())
            {
                Listelem = mainClient.getPanier(Token.Text);
                ElPanier.Clear();
                for (int i = 0; i < Listelem.Length; i++)
                {
                    ElPanier.Add(Listelem[i]);
                }
            }
        }

        private void AjoutPlus_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Article article = button.DataContext as Article;
            using (Service.Service1Client client = new Service.Service1Client())
            {
                client.rajouter(Token.Text, article);
            }           
            //Refresh
        }

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Article article = button.DataContext as Article;
            using (Service.Service1Client client = new Service.Service1Client())
            {
                client.retirer(Token.Text, article);
            }
            //Refresh
        }

        private void MoinsQt_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Article article = button.DataContext as Article;
            using (Service.Service1Client client = new Service.Service1Client())
            {
                client.enlever(Token.Text, article);
            }
            //Refresh
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            WpFVItrine.Window1 window = new WpFVItrine.Window1(Token.Text);
            this.Close();
            window.ShowDialog();
        }

        private void Payer_click(object sender, RoutedEventArgs e)
        {
            using (Service.Service1Client client = new Service.Service1Client())
            {
                client.payer(Token.Text);
            }
        }
    }
}
