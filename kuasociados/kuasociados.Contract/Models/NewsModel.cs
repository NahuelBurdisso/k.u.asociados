using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{ 
    public class NewsModel
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Título:")]
        public virtual string Title { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Cuerpo:")]
        public virtual string Body { get; set; }

        [Display(Name = "Subtítulo:")]
        public virtual string Subtitle { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Imagen principal para su noticia:")]
        public virtual string Img { get; set; } //TODO analizar que tipo es

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de publicación:")]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Autor:")]
        public virtual string Author { get; set; }
    }
}