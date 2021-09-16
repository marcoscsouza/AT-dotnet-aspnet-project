using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class BandaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime InicioBanda { get; set; }
        public string GeneroMusical { get; set; }
        public string Nacionalidade { get; set; }
        public bool FazendoShow { get; set; }

        public List<MusicoModel> Musicos { get; set; }
    }
}
