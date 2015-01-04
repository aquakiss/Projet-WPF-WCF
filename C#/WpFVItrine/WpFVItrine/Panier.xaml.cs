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
//using ClassLibDll;

namespace WpFVItrine
{
    /// <summary>
    /// Logique d'interaction pour Panier.xaml
    /// </summary>
    public partial class Panier : Window
    {
        object[] ListeArticle;
        public Panier(string tok)
        {
            InitializeComponent();
            Token.Text = tok;

            using (Service.Service1Client clientone = new Service.Service1Client())
            {
                ListeArticle = clientone.getListArticle();
            }
            Paniers.ItemsSource = ListeArticle;
        }
    }
}
