using GestionCommande.dao;
using GestionCommande.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.controleur
{
    class CommandeControleur:ControleurCommande
    {
        private ClientDao ClientDao { get; }
        private ProduitDao ProduitDao { get; }
        private CommandeDao CommandeDao { get; }

        public CommandeControleur()
        {
            this.ClientDao = new ClientDao();
            this.ProduitDao = new ProduitDao();
            this.CommandeDao = new CommandeDao();
        }

        public void CreerCommande(Client client,ICollection<LigneCommande> ligneCmd)
        {
            model.Commande cmd = new model.Commande { Id = CommandeDao.Commandes.Count + 1, Client = client, LignesCommande = ligneCmd };
            foreach (LigneCommande ligne in ligneCmd)
            {
                ligne.Commande = cmd;
            }
            client.Commandes.Add(cmd);
            CommandeDao.AjouterCommande(cmd);
        }

        public ICollection<Client>  GetClients()
        {
            return ClientDao.Clients;
        }

        public ICollection<Produit> GetProduits()
        {
            return ProduitDao.Produits;
        }

        public ICollection<model.Commande> GetCommandes()
        {
            return CommandeDao.Commandes;
        }

        public void SetNewClients(string nom, string prenom, string mail)
        {
            Client nouveauclient = new Client() { Id = ClientDao.Clients.Count + 1, Nom = nom, Prenom = prenom, Mail = mail, Commandes = new Collection<model.Commande>() };
            ICollection<Client> liste = GetClients();
            liste.Add(nouveauclient);
        }

        public void SetNewProduct(string designation, int prix)
        {
            Produit nouveauproduit = new Produit() { Id = ProduitDao.Produits.Count + 1, Designation = designation, Prix = prix};
            ICollection<Produit> liste = GetProduits();
            liste.Add(nouveauproduit);
        }
    }
}
