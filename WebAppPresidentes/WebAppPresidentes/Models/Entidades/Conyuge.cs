using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppPresidentes.Models.Entidades
{
    public class Conyuge
    {
        [Key]

        [Display(Name = "ID")]
        public int IdConyuge { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string NombreConyuge { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Debe ingresar el apellido")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string ApellidoConyuge { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Cuando")]
        public string DNI { get; set; }

        [Display(Name = "Nacionalidad")]
        [Required(ErrorMessage = "Cuando")]
        public string Nacionalidad { get; set; }

        public virtual ICollection<Presidentes> Presidentes { get; set; }
    }
}
