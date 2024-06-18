using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_usuario { get; set; }

        [Required]
        [StringLength(255)]
        public string contrasena { get; set; }

        public int? rol_id { get; set; }

        [ForeignKey("rol_id")]
        public Roles? Roles { get; set; }

        //public ICollection<Auditoria> Auditoria { get; set; }
    }
}
