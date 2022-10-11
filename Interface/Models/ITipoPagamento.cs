using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface ITipoPagamento : IBaseModel
    {
        string Nome { get; set; }
        
        List<IVenda> Vendas { get; }
        
        List<ICompra> Compras { get; }
    }
}
