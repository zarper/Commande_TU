using GestionCommande.model;
using GestionCommande.dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande
{
    public class GestionClientContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}
