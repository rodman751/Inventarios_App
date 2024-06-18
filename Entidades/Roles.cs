using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_rol { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
