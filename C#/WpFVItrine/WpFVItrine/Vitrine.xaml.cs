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
            
            using(Service.Service1Client client = new Service.Service1Client())
            {
                ListeArticle = client.getListArticle();
            }
            Produits.ItemsSource = ListeArticle;
        }
    }
}
