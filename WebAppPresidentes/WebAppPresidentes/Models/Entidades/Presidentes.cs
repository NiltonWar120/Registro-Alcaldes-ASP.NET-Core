using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebAppPresidentes.Models.Entidades
{
    public class Presidentes
    {
        [Key]

        [Display(Name = "ID")]
        public int IdPresidente { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Debe ingresar el apellido")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string Apellido { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Cuando")]
        public int DNI { get; set; }

        [Display(Name = "Sueldo")]
        public int Sueldo { get; set; }

        [Display(Name = "Partido")]
        [Required(ErrorMessage = "Cuando")]
        public string Partido { get; set; }

        public int IdConyuge { get; set; }
        [ForeignKey("IdConyuge")]
        public virtual Conyuge Conyuge { get; set; }
        public int IdProfesion { get; set; }
        [ForeignKey("IdProfesion")]
        public virtual Profesion Profesion { get; set; }
        public int IdPais { get; set; }
        [ForeignKey("IdPais")]
        public virtual Paises Paises { get; set; }

    }
}

