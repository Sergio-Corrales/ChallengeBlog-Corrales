using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChallengeBlog_Corrales.Models

    //Clase Post (migra a tabla en la db)
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(50, ErrorMessage = "Minimo {2} caracteres - Maximo {1} caracteres", MinimumLength = 2)]
        [Display(Name ="Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(250, ErrorMessage = "Minimo {2} caracteres - Maximo {1} caracteres", MinimumLength = 2)]
        [Display(Name = "Contenido")]
        public string Contents { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Picture { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(50, ErrorMessage = "Minimo {2} caracteres - Maximo {1} caracteres", MinimumLength = 2)]
        [Display(Name = "Categoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creación")]
        public DateTime Creation_Date { get; set; }

    }
}
