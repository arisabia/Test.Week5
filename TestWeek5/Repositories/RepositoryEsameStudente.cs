using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek5.Entities;

namespace TestWeek5.Repositories
{
    public class RepositoryEsameStudente : IRepositoryEsameStudente
    {
        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
                Integrated Security = true; Initial Catalog = Scuola;";

        public bool Add(EsameStudente item)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    SqlCommand insertCommand = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "INSERT INTO StudenteEsame " +
                        "VALUES (@StudenteID, @EsameID)"
                    };
                    insertCommand.Parameters.AddWithValue("@StudenteID", item.StudenteID);
                    insertCommand.Parameters.AddWithValue("@EsameID", item.EsameID);

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

        public IList<EsameStudente> GetAll()
        {
            throw new NotImplementedException();
        }

        public EsameStudente GetByID(int value)
        {
            throw new NotImplementedException();
        }
    }
}
