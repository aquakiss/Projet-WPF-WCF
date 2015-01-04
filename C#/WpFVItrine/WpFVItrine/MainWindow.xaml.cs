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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpFVItrine
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connexion_click(object sender, RoutedEventArgs e)
        {
            if (Nom.Text != string.Empty && Prenom.Text != string.Empty) 
            {
                string token;
                using(Service.Service1Client client = new Service.Service1Client())
                {
                    token = client.login(Nom.Text, Prenom.Text);
                }
                if(token == "Admin007")
                {
                    WpFVItrine.PAdmin Pagead = new WpFVItrine.PAdmin(token);
                    this.Close();
                    Pagead.ShowDialog();
                }
                else
                {
                    WpFVItrine.Window1 window = new WpFVItrine.Window1(token);
                    this.Close();
                    window.ShowDialog();
                }
            }
        }
    }
}
