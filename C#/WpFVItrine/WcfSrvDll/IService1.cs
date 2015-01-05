using ClassLibDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfSrvDll
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string login(string Nom, string Prenom);

        [OperationContract]
        string GetiDAdm();

        [OperationContract]
        void AdmAddProd(string AdtxBname, string AdtxBprix, string AdtxBquant, string AdtxBdescrip, string AdtxBResu);

        [OperationContract]
        List<Article> getListArticle();

        [OperationContract]
        List<Article> getPanier(string token);

        [OperationContract]
        void ElemAddInPani(Article produit, string id);

        [OperationContract]
        void SuppProdVit(Article article);

        [OperationContract]
        void rajouter(string token);

        [OperationContract]
        void enlever(string token);

        [OperationContract]
        void retirer(string token);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
