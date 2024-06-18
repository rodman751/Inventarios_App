using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre_producto { get; set; }

        public string descripcion { get; set; }

        public bool graba_iva { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal costo { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal pvp { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        public int cantidad { get; set; }

        public int stock_disponible { get; set; }

        
    }
}
