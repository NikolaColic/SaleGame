using IgricePS.Domen.Entiteti;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.BazaPodataka
{
    public class BrokerBaze
    {
        private SqlTransaction transaction;
        private SqlConnection connection;

        public BrokerBaze()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IgricePS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        public void Dodaj(IDomObjekat objekat)
        {
            SqlCommand query = new SqlCommand();
            query.Connection = connection;
            query.Transaction = transaction;
            query.CommandText = $"insert into {objekat.VratiNazivTabele()} values ({objekat.Dodaj()})";
            if(query.ExecuteNonQuery() == 0) throw new Exception();
        }
        public void Izmeni(IDomObjekat objekat)
        {
            SqlCommand query = new SqlCommand();
            query.Connection = connection;
            query.Transaction = transaction;
            query.CommandText = $"update {objekat.VratiNazivTabele()} set {objekat.Izmeni()} where {objekat.Where()}";
            if (query.ExecuteNonQuery() == 0) throw new Exception();
        }
        public List<IDomObjekat> Vrati(IDomObjekat objekat)
        {
            SqlCommand query = new SqlCommand();
            query.Transaction = transaction;
            query.Connection = connection;
            query.CommandText = $"select * from {objekat.VratiNazivTabeleAnotacija()} {objekat.Join()}";
            SqlDataReader reader = query.ExecuteReader();

            return objekat.VratiObjekte(reader);
        }
        public void Obrisi(IDomObjekat objekat)
        {
            SqlCommand query = new SqlCommand();
            query.Connection = connection;
            query.Transaction = transaction;
            query.CommandText = $"delete from {objekat.VratiNazivTabele()} where {objekat.Where()}";
            query.ExecuteNonQuery();
        }
        public void Konekcija()
        {
            connection.Open();
        }
        public void KonkecijaZatvaranje()
        {
            connection.Close();
        }
        public void PokretanjeTranskacije()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction.Commit();
        }
        public void RollBack()
        {
            transaction.Rollback();
        }
    }
}
