using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudPrueba.Models.ViewModel
{
    public class PersonaVeiwModel
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
    }
}