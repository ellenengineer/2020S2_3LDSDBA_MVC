using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidade = new HashSet<Cidade>();
        }

        public int CodEst { get; set; }
        public string SiglaEst { get; set; }
        public string NomeEst { get; set; }
        public int CodPais { get; set; }

        public virtual Pais CodPaisNavigation { get; set; }
        public virtual ICollection<Cidade> Cidade { get; set; }
    }
}
