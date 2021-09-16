using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class MusicoViewModel
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Nome { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        [Display(Name = "Ultimo nome")]
        public string UltimoNome { get; set; }
        [Display(Name = "Toca mais de um instrumento")]
        public bool MuitosInstrumentos { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        [Display(Name = "Instrumento preferido")]
        public string PrincipalInstrumento { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime Nascimento { get; set; }

        public int BandaId { get; set; }
        public BandaViewModel Banda { get; set; }
    }
}
