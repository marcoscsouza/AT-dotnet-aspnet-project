using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class BandaViewModel
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        [Remote(action: "IsNomeValid", controller: "Banda", AdditionalFields = "Id")]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Inicio da Banda")]
        public DateTime InicioBanda { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string GeneroMusical { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Nacionalidade { get; set; }
        public bool FazendoShow { get; set; }

        public List<MusicoViewModel> Musicos { get; set; }
    }
}
