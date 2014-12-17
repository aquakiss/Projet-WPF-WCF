using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibDll
{
    public class User
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string ID { get; set; }
        public bool Admin { get; set; }
        public int Argent { get; set; }
 
        public void AjouterFond(int Money)
        {
            Argent += Money;
        }

        public void AjouterArticle()
        {

        }

        public void SupprimerArticle()
        {

        }

        public void ModifierArticle()
        {

        }

        public User()
        {
            this.Argent = 5;
        }
    }
}
