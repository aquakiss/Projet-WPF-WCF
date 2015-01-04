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
            liste.Add(new Article() { Nom = "Oblivion", Prix = 24, Quantite = 2, Description = "Action SF", Resume = "Aventure futurisque de Jack Harper(Tom Cruise)" });
            liste.Add(new Article() { Nom = "Zombiland", Prix = 16, Quantite = 1, Description = "Action Zombie Humour", Resume = "Bienvenu à Zombiland" });
            liste.Add(new Article() { Nom = "The Watchmen - Les justiciers", Prix = 18, Quantite = 5, Description = "Action Fantastique", Resume = "L'univers de DC" });
            liste.Add(new Article() { Nom = "Sins City - J'ai tué pour elle", Prix = 29, Quantite = 10, Description = "Action Polar", Resume = "Sins" });
            liste.Add(new Article() { Nom = "L'Age de glace", Prix = 10, Quantite = 3, Description = "Humour Anime", Resume = "Suivé les fole aventure de" });
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

        public void ElemAddInPani()
        {
            //userPani.ajouter();
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
