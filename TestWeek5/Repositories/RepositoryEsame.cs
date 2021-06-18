using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek5.Entities;

namespace TestWeek5.Repositories
{
    public class RepositoryEsame : IRepositoryEsame
    {
        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
                Integrated Security = true; Initial Catalog = Scuola;";

        public IList<Esame> GetAll()
        {
            IList<Esame> esami = new List<Esame>();

            using (SqlConnection connectio = new SqlConnection(connectionString))
            {
                connectio.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connectio;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Esame";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    esami.Add(new Entities.Esame() 
                    { 
                        ID = Int32.Parse(reader["ID"].ToString()),
                        Nome = reader["Nome"].ToString(),
                        CFU = Int32.Parse(reader["CFU"].ToString()),
                        Data = DateTime.Parse(reader["Data"].ToString()),
                        Votazione = Int32.Parse(reader["Votazione"].ToString()),
                        Passato = Char.Parse(reader["Passato"].ToString())
                    });
                }
                return esami;
            }


        }
        public bool Add(Esame item)
        {
            int rowAffected = 0;
            if (item == null || GetByID(item.ID) != null)
            {
                return false;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                   
                    SqlCommand insertCommand = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "INSERT INTO Esame " +
                        "VALUES (@Nome, @CFU,@Data, @Votazione,@Passato)"
                    };
                    insertCommand.Parameters.AddWithValue("@Nome", item.Nome);
                    insertCommand.Parameters.AddWithValue("@CFU", item.CFU);
                    insertCommand.Parameters.AddWithValue("@Data", item.Data);
                    insertCommand.Parameters.AddWithValue("@Votazione", item.Votazione);
                    insertCommand.Parameters.AddWithValue("@Passato", item.Passato);

                    rowAffected = insertCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {

                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowAffected > 0;
        }

        public Esame GetByID(int ID)
        {
            Esame esameTrovato = GetAll().FirstOrDefault(esame => esame.ID.Equals(ID));
            return esameTrovato;
        }

        public IList<Esame> GetEsamByVotoEData(string votazione, DateTime data)
        {
            return GetAll().OrderBy(e => e.Votazione).ThenBy(e => e.Data).ToList();
        }
    }
}
