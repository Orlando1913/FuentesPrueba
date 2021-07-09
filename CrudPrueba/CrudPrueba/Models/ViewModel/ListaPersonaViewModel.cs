using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudPrueba.Models.ViewModel
{
    public class ListaPersonaViewModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Edad")]
        public string Edad { get; set; }
    }
}