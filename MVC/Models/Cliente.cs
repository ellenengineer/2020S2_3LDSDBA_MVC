using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Credito = new HashSet<Credito>();
            Email = new HashSet<Email>();
            Endereco = new HashSet<Endereco>();
            Fone = new HashSet<Fone>();
            Login = new HashSet<Login>();
            Pedido = new HashSet<Pedido>();
        }

        public int CodCli { get; set; }
        public int CodTipoCli { get; set; }
        public string NomeCli { get; set; }
        public DateTime DataCadCli { get; set; }
        public decimal RendaCli { get; set; }
        public string SexoCli { get; set; }

        public virtual TipoCli CodTipoCliNavigation { get; set; }
        public virtual Conjuge Conjuge { get; set; }
        public virtual ICollection<Credito> Credito { get; set; }
        public virtual ICollection<Email> Email { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Fone> Fone { get; set; }
        public virtual ICollection<Login> Login { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
