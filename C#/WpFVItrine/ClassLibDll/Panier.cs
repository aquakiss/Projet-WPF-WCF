using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibDll
{
    public class Panier
    {
        public List<Article> listePanier = new List<Article>();
        private int token {get; set;}

        public void ajouter(Article article)
        {
            listePanier.Add(article);
        }

        public void enlever(Article article)
        {
            listePanier.Remove(article);
        }

        public void payer()
        {
            
        }
    }
}
