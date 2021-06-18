using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek5.Entities;

namespace TestWeek5.Repositories
{
    public class RepositoryStudente : IRepositoryStudente
    {
        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
                Integrated Security = true; Initial Catalog = Scuola;";

        public IList<Studente> GetAll()
        {
            IList<Studente> studenti = new List<Studente>();

            using (SqlConnection connectio = new SqlConnection(connectionString))
            {
                connectio.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connectio;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Scuola";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    studenti.Add(new Entities.Studente()
                     {
                        ID = Int32.Parse(reader["ID"].ToString()),
                        Nome= reader["Nome"].ToString(),
                        Cognome = reader["Cognome"].ToString(),
                        AnnoNascita = Int32.Parse(reader["AnnoNascita"].ToString())
                    });
                }
                return studenti;

            }

        }
        public Studente GetByID(int value)
        {
            return GetAll().FirstOrDefault(s => s.ID == value);
        }

        public bool Add(Studente item)
        {
            IList<Studente> studente = new List<Studente>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand selectCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT * FROM Studente"
                };

                adapter.SelectCommand = selectCommand;
                DataSet dataSet = new DataSet();

                connection.Open();
                adapter.Fill(dataSet, "Studente");
               

            }
           
        }

        
        
    }
}
