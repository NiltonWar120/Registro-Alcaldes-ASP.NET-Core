using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppPresidentes.Models.Entidades
{
    public class Profesion
    {
        [Key]

        [Display(Name = "ID")]
        public int IdProfesion { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string NombreProfesion { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Debe ingresar el apellido")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string Categoria { get; set; }

        [Display(Name = "Grado")]
        [Required(ErrorMessage = "Cuando")]
        public string Grado { get; set; }

        [Display(Name = "Especialidad")]
        [Required(ErrorMessage = "Cuando")]
        public string Especialidad { get; set; }

        public virtual ICollection<Presidentes> Presidentes { get; set; }
    }
}
