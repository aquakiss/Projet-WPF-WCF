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
        public string Nom { get; set; }
        [DataMember]
        public int Prix { get; set; }
        [DataMember]
        public int Quantite { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Resume { get; set; }
       
        public Article(string n, int p, int q, string d, string r)
        {
            this.Nom = n;
            this.Prix = p;
            this.Quantite = q;
            this.Description = d;
            this.Resume = r;
        }

        public Article()
        {
            // TODO: Complete member initialization
        }
    }
}
