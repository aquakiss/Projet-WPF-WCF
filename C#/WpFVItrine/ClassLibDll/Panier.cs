using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ClassLibDll
{
    [DataContract]
    public class Panier
    {
        [DataMember]
        public List<Article> listePanier = new List<Article>();
        [DataMember]
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
