using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace ClassLibDll
{

    [DataContract]
    public class Article
    {
        [DataMember]
        private string Nom { get; set; }
        [DataMember]
        private int Prix { get; set; }
        [DataMember]
        private int Quantite { get; set; }
        [DataMember]
        private string Description { get; set; }
        [DataMember]
        private string Resume { get; set; }
       
        public Article(string n, int p, int q, string d, string r)
        {
            this.Nom = n;
            this.Prix = p;
            this.Quantite = q;
            this.Description = d;
            this.Resume = r;
        }
    }
}
