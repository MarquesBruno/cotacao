using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cotacao.Banco;
using Cotacao.Entidade;

namespace Cotacao.Repositorio
{
    public class CotaRepositorio
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }

        public static List<Cota> Get(int pCota)
        {            
            DataBase db = GetDataBase();
            var query = from cot in db.Cotacoes orderby cot.data_consulta descending select cot;

            List<Cota> lista = new List<Cota>(query.AsEnumerable());
            return lista;
        }

        public static void Create(Cota pFavoritos)
        {

            DataBase db = GetDataBase();
            db.Cotacoes.InsertOnSubmit(pFavoritos);
            db.SubmitChanges();

        }

        public static void Delete(Cota pFavoritos)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Cotacoes
                        where c.id == pFavoritos.id
                        select c;

            db.Cotacoes.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

    }
}
