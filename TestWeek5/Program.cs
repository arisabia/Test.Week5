using System;
using TestWeek5.Entities;
using TestWeek5.Repositories;

namespace TestWeek5
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositoryStudente repoStudente = new RepositoryStudente();

            Studente studenteDaCercare = repoStudente.GetByID(1);
            if (studenteDaCercare != null)
            {
                Console.WriteLine($"{studenteDaCercare.Nome} - " +
                    $"{studenteDaCercare.Cognome} - {studenteDaCercare.AnnoNascita}");
            }
            else
            {
                Console.WriteLine("Studente non trovato");
            }

            foreach (var studente in repoStudente.GetAll())
            {
                Console.WriteLine($"{studente.ID} - {studente.Nome}" +
                    $" - {studente.Cognome} - {studente.AnnoNascita}  ");
            }

            IRepositoryEsame repoEsame = new RepositoryEsame();

            Esame esame = new Esame()
            {
                //@Nome, @CFU,@Data, @Votazione,@Passato
                Nome = "Pittura",
                CFU = 3,
                Data = DateTime.Parse("2021-02-05".ToString()),
                Votazione = 100,
                Passato = Char.Parse("Y".ToString())
            };

            IRepositoryEsameStudente repoEsameStudente = new RepositoryEsameStudente();
            EsameStudente esameStudente = new EsameStudente()
            {
                StudenteID = 1,
                EsameID = 3
            };


        }
    }
}
