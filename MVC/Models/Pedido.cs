using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Itens = new HashSet<Itens>();
            Parcela = new HashSet<Parcela>();
        }

        public int NumPed { get; set; }
        public int CodCli { get; set; }
        public int CodFunc { get; set; }
        public short CodSta { get; set; }
        public DateTime DataPed { get; set; }
        public decimal ValPed { get; set; }
        public int QtdePed { get; set; }

        public virtual Cliente CodCliNavigation { get; set; }
        public virtual Funcionario CodFuncNavigation { get; set; }
        public virtual StatusPedido CodStaNavigation { get; set; }
        public virtual ICollection<Itens> Itens { get; set; }
        public virtual ICollection<Parcela> Parcela { get; set; }
    }
}
