using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppPresidentes.Models.Entidades
{
    public class Paises
    {
        [Key]

        [Display(Name = "ID")]
        public int IdPais { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string NombrePais { get; set; }

        [Display(Name = "Capital")]
        [Required(ErrorMessage = "Debe ingresar la Capital")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string Capital { get; set; }

        [Display(Name = "Idioma")]
        [Required(ErrorMessage = "Cuando")]
        public string Idioma { get; set; }

        [Display(Name = "Moneda")]
        [Required(ErrorMessage = "Cuando")]
        public string Moneda { get; set; }

        public virtual ICollection<Presidentes> Presidentes { get; set; }

    }
}
