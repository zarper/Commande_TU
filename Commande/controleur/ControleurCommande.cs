using GestionCommande.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.controleur
{
    public interface ControleurCommande
    {

        void CreerCommande(Client client, ICollection<LigneCommande> ligneCmd);

        void SetNewClients(string nom ,string prenom,string mail);

        void SetNewProduct(string designation,int prix);

        ICollection<Client> GetClients();

        ICollection<Produit> GetProduits();

        ICollection<model.Commande> GetCommandes();


    }
}
