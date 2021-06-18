using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek5.Entities
{
    public class EsameStudente
    {
        public int StudenteID { get; set; }
        public int EsameID { get; set; }

        public override string ToString()
        {
            return $"Studente: {StudenteID} -\n" +
                $" Esame sostenuto:{EsameID}";
        }
    }
}
