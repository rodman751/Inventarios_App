using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auditoria
    {
        [Key]
        public int Id { get; set; }

        public int usuario_id { get; set; }
        [ForeignKey("usuario_id")]
        public Usuarios? Usuarios { get; set; }

        [StringLength(100)]
        public string accion { get; set; }

        public DateTime fecha { get; set; } = DateTime.Now;

        public int ajuste_id { get; set; }
        [ForeignKey("ajuste_id")]
        public Ajustes Ajustes { get; set; }


    }
}
