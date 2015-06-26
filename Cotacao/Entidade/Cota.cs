using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cotacao.Entidade
{
    [Table(Name = "Cotacoes")]
    public class Cota
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(CanBeNull = false)]
        public string data_consulta { get; set; }

        [Column(CanBeNull = false)]
        public double indice { get; set; }
    }
}
