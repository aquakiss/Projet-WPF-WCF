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
using System.Collections.ObjectModel;

namespace WpFVItrine
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        object[] ListeArticle;
        public ObservableCollection<object> Vitrin = new ObservableCollection<object>();
        DispatcherTimer timer = new DispatcherTimer();
        public Window1(string id)
        {
            InitializeComponent();
            Token.Text = id;

            /*using (Service.Service1Client client = new Service.Service1Client())
            {
                ListeArticle = client.getListArticle();
            }
            ListeProduits.ItemsSource = ListeArticle; ListBox */

            using (Service.Service1Client client = new Service.Service1Client())
            {
                ListeArticle = client.getListArticle();
            }
            for (int i = 0; i < ListeArticle.Length; i++)
            {
                Vitrin.Add(ListeArticle[i]);
            }
            ListeProduits.ItemsSource = Vitrin;

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += ReactOnTime;
            timer.Start();
        }

        void ReactOnTime(object sender, EventArgs e)
        {
            using (Service.Service1Client mainClient = new Service.Service1Client())
            {
                ListeArticle = mainClient.getListArticle();
                Vitrin.Clear();
                for (int i = 0; i < ListeArticle.Length; i++)
                {
                    Vitrin.Add(ListeArticle[i]);
                }
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