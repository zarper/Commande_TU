//using GestionClient.controleur;
using GestionCommande.controleur;
using GestionCommande.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommande.vue
{
    class MainVue
    {
        private ControleurCommande controleurcommande;
        //private ControleurClient controleurclient;
        public MainVue(ControleurCommande controleur)
        {
            this.controleurcommande = controleur;
        }

        public void start()
        {
            string input = "";
            do
            {
                Console.WriteLine("Quelle actions souhaitez vous faire : ");
                Console.WriteLine("1 : Afficher la liste des clients");
                Console.WriteLine("2 : Afficher la liste des produits");
                Console.WriteLine("3 : Afficher la liste des commandes");
                Console.WriteLine("4 : Afficher les commandes d'un client");
                Console.WriteLine("5 : Ajouter une commande");
                Console.WriteLine("6 : Créé un nouveau client");
                Console.WriteLine("7 : Créé un nouveau produit");
                Console.WriteLine("q : quitter");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AfficherClients();
                        break;
                    case "2":
                        AfficherProduits();
                        break;
                    case "3":
                        AfficherCommandes();
                        break;
                    case "4":
                        AfficherCommandeParClient();
                        break;
                    case "5":
                        AjouterCommande();
                        break;
                    case "6":
                        NouveauClient();
                        break;
                    case "7":
                        NouveauProduit();
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            } while (!"q".Equals(input));
        }

        private void AfficherCommandeParClient()
        {
            Client client = this.ChoisirClient();
            this.AfficherCommandes(client.Commandes);
        }

        private void AfficherCommandes()
        {
            this.AfficherCommandes(controleurcommande.GetCommandes());
        }

        private void AfficherCommandes(ICollection<model.Commande> commandes)
        {
            foreach (model.Commande commande in commandes)
            {
                Console.WriteLine("Client : " + commande.Client.Prenom + " " + commande.Client.Nom);
                Console.WriteLine("Produits : ");
                foreach (LigneCommande ligneCommande in commande.LignesCommande)
                {
                    Console.WriteLine("Désignation : " + ligneCommande.Produit.Designation);
                    Console.WriteLine("Quantité : " + ligneCommande.Quantite);
                }
                Console.WriteLine();
            }
        }

        private void AfficherProduits()
        {
           foreach(Produit produit in controleurcommande.GetProduits())
            {
                Console.WriteLine("Désignation : " + produit.Designation);
                Console.WriteLine("Prix : "+produit.Prix);
            }
        }

        private void AjouterCommande()
        {
            Console.WriteLine("Création d'une nouvelle commande");

            Client cli = this.ChoisirClient();
            ICollection<LigneCommande> lignesCommande = this.AjouterLignes();

            controleurcommande.CreerCommande(cli, lignesCommande);
        }

        private Client ChoisirClient()
        {
            Console.WriteLine("Entrez l'ID du client pour la commande : ");
            ICollection<Client> clients = controleurcommande.GetClients();
            this.AfficherClients();
            string input = Console.ReadLine();
            return  clients.Where(c => c.Id == int.Parse(input)).First();
        }

        private ICollection<LigneCommande> AjouterLignes()
        {
            ICollection<LigneCommande> lignesCommande = new Collection<LigneCommande>();
            string input = "";
            do
            {

                Produit prod = this.AjouterProduit();
                Console.WriteLine("Veuillez entrer une quantité");
                int qte = int.Parse(Console.ReadLine());

                LigneCommande ligneCmd = new LigneCommande() { Produit = prod, Quantite = qte };
                lignesCommande.Add(ligneCmd);
                Console.WriteLine("Appuyer sur 'q' si vous souhaitez arrêter d'ajouter des produits, sinon, appuyez sur n'importe quelle touche");
                input = Console.ReadLine();
            } while (!"q".Equals(input));

            return lignesCommande;
        }

        private Produit AjouterProduit()
        {
            Console.WriteLine("Entrez l'ID d'un produit à ajouter à la commande : ");
            ICollection<Produit> produits = controleurcommande.GetProduits();
            foreach (Produit produit in produits)
            {
                Console.WriteLine(produit.Id + " : " + produit.Designation);
            }
            string input = Console.ReadLine();
            return produits.Where(p => p.Id == int.Parse(input)).First();
        }

        private int AjouterQuantité()
        {
            Console.WriteLine("Veuillez entrer une quantité");
            return int.Parse(Console.ReadLine());
        }

        private void AfficherClients()
        {
            foreach (Client client in controleurcommande.GetClients())
            {
                Console.WriteLine(client.Id + " : " + client.Prenom + " " + client.Nom);
            }
        }

        private Client NouveauClient()
        {
            Console.WriteLine("Veillez rentré le nom du client : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Veillez rentré le prénom du client : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Veillez rentré le mail du client : ");
            string mail = Console.ReadLine();
            Client nouveauclient = new Client() { Id = 4, Nom = nom, Prenom = prenom, Mail = mail, Commandes = new Collection<model.Commande>() };
            controleurcommande.SetNewClients(nom, prenom, mail);
            return nouveauclient;
           
        }

        private Produit NouveauProduit()
        {
            Console.WriteLine("Veillez rentré la designation du produit : ");
            string designation = Console.ReadLine();
            Console.WriteLine("Veillez rentré le prix du produit : ");
            int prix = int.Parse(Console.ReadLine());
            Produit nouveauproduit = new Produit() { Id = 4, Designation = designation, Prix = prix };
            controleurcommande.SetNewProduct(designation, prix);
            return nouveauproduit;
        }
    }
}
