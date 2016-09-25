using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Models
{
    public class News
    {
        public virtual int idNews { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Título:")]
        public virtual string title { get; set; }

        
        [Display(Name = "Subtítulo:")]
        public virtual string subtitle { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Imagen principal para su noticia:")]
        public virtual string img { get; set; } //TODO analizar que tipo es

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de publicación:")]
        public DateTime publishDate { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Autor:")]
        public virtual string author { get; set; }
    }
}