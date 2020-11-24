using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Bonus = new HashSet<Bonus>();
            Dependente = new HashSet<Dependente>();
            Historico = new HashSet<Historico>();
            Pedido = new HashSet<Pedido>();
            Pontuacao = new HashSet<Pontuacao>();
        }

        public int CodFunc { get; set; }
        public string NomeFunc { get; set; }
        public DateTime DataCadFunc { get; set; }
        public string SexoFunc { get; set; }
        public decimal SalFunc { get; set; }
        public string EndFunc { get; set; }

        public virtual ICollection<Bonus> Bonus { get; set; }
        public virtual ICollection<Dependente> Dependente { get; set; }
        public virtual ICollection<Historico> Historico { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
        public virtual ICollection<Pontuacao> Pontuacao { get; set; }
    }
}
