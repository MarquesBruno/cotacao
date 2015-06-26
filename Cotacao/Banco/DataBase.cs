using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cotacao;
using Cotacao.Entidade;
using System.Data.Linq;

namespace Cotacao.Banco
{
    public class DataBase : DataContext
    {
        public static string DBConnectionString =
            "Data Source = 'isostore:provaDB.sdf'";

        public DataBase()
            : base(DBConnectionString)
        {
        }

        public Table<Cota> Cotacoes
        {
            get { return this.GetTable<Cota>(); }
        }


    }
}
