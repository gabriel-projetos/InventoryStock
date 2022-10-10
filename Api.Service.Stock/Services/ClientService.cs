using Api.Service.Stock.Context;
using Api.Service.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Services
{
    public class ClientService
    {
        private ApiDbContext Context { get; set; }

        public ClientService(ApiDbContext context)
        {
            Context = context;
        }

        
        public void InsertClient(Cliente client)
        {
            Context.Clientes.Add(client);
            Context.SaveChanges();
        }
    }
}
