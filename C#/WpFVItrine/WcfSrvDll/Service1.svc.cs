using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ClassLibDll;

namespace WcfSrvDll
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
       public static List<Article> liste = new List<Article>();
        static Service1()
        {
            liste.Add(new Article("nom", 1, 2, "d", "r"));
            liste.Add(new Article("nom", 2, 3, "de", "re"));
            liste.Add(new Article("nom", 3, 4, "des", "res"));
            liste.Add(new Article("nom", 4, 5, "desc", "resu"));
            liste.Add(new Article("nom", 5, 6, "descr", "resum")); 
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string login(string Nom, string Prenom)
        {
            User user = new User();
            user.Nom = Nom;
            user.Prenom = Prenom;
            if(Prenom == "admin" && Nom == "admin")
            {
                user.Admin = true;
            }
            user.ID = Nom + Prenom;
            return user.ID;
        }

        public List<Article> getListArticle()
        {
            return liste;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

    }
}
