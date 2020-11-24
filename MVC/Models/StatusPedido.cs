using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class StatusPedido
    {
        public StatusPedido()
        {
            Pedido = new HashSet<Pedido>();
        }

        public short CodSta { get; set; }
        public string StaPed { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
