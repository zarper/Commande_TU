using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCommande.model;
using GestionCommande.dao;

namespace GestionCommande.controleur
{
    public class SqlServerControleur : ControleurCommande
    {
        private GestionCommandeContext ctx;
        public SqlServerControleur()
        {
            ctx = new GestionCommandeContext();
        }
        public void CreerCommande(Client client, ICollection<LigneCommande> ligneCmd)
        {
            model.Commande cmd = new model.Commande { Id = ctx.Commandes.Count() + 1, Client = client, LignesCommande = ligneCmd };
            foreach (LigneCommande ligne in ligneCmd)
            {
                ligne.Commande = cmd;
            }
            client.Commandes.Add(cmd);
            ctx.Commandes.Add(cmd);
            ctx.Entry(client).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public ICollection<Client> GetClients()
        {
            return ctx.Clients.ToList();
        }

        public ICollection<model.Commande> GetCommandes()
        {
            return ctx.Commandes.ToList();
        }

        public ICollection<Produit> GetProduits()
        {
            return ctx.Produits.ToList();
        }

        public void SetNewClients(string nom, string prenom, string mail)
        {
            throw new NotImplementedException();
        }

        public void SetNewProduct(string designation, int prix)
        {
            throw new NotImplementedException();
        }
    }
}
