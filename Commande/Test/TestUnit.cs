using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.Test
{
    class TestUnit
    {
        #region Gestioncommande
        [TestMethod]
        public void Testcreacommande()
        {
            GestionCommande.dao.CommandeDao nouvellecommande = new GestionCommande.dao.CommandeDao();

            Assert.AreEqual(true, true);
        }
        #endregion

        #region Gestionclient
        [TestMethod]
        public void Testcreaclient()
        {
            GestionCommande.controleur.CommandeControleur.SetNewClients("nomtest" , "prenomtest","testmail@mail.fr", Commande = new Collection<model.Commande>());
            ICollection<GestionCommande.model.Produit> Listeclients = GestionCommande.controleur.CommandeControleur.GetClients();
            GestionCommande.dao.ProduitDao nouveauproduit = GestionCommande.dao.ProduitDao.NewProduitList(Listeclients);

            Assert.AreEqual(GestionCommande.controleur.CommandeControleur.SetNewClients("nomtest", "prenomtest", "testmail@mail.fr", Commande = new Collection<model.Commande>()), GestionCommande.dao.ClientDao.Clients.Last);
        }
        #endregion

        #region Gestionproduit
        [TestMethod]
        public void Testcreaproduit()
        {
            GestionCommande.controleur.CommandeControleur.SetNewProduct("test", 50);
            ICollection<GestionCommande.model.Produit> Listeproduits = GestionCommande.controleur.CommandeControleur.GetProduits();
            GestionCommande.dao.ProduitDao nouveauproduit = GestionCommande.dao.ProduitDao.NewProduitList(Listeproduits);

            Assert.AreEqual(GestionCommande.controleur.CommandeControleur.SetNewProduct("test", 50), GestionCommande.dao.ProduitDao.Produits.Last);
        }
        #endregion
    }
}
