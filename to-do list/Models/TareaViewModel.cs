
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace to_do_list.Models
{
    public class TareaViewModel
    {
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("Descripcion")]
        public string  descripcion { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha Creacion")]
        public DateTime fechaCreacion { get; set; }

        [DisplayName("Completada")]
        public bool completada { get; set; }

        public string estado => completada ? "Completada" : "Pendiente"; 
        
    }
}
