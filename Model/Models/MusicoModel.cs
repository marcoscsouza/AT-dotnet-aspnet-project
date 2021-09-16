using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class MusicoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public bool MuitosInstrumentos { get; set; }
        public string PrincipalInstrumento { get; set; }
        public DateTime Nascimento { get; set; }

        public int BandaId { get; set; }
        public BandaModel Banda { get; set; }
    }
}
