using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ajustes
    {
        [Key]
        public int Id { get; set; }

        public string descripcion { get; set; }

        public DateTime fecha { get; set; }

        [Required]
        [StringLength(20)]
        public string numero_ajuste { get; set; }
        [Required]
        public int producto_id { get; set; }
        [ForeignKey("producto_id")]
        public Productos? Productos { get; set; }

    }
}
