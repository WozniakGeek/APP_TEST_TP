using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestAppTP.Models.DB
{
    public partial class NotasEstudiante
    {
        [Key]
        public long Id { get; set; }
        [StringLength(10)]
        public string Documento { get; set; }
        [StringLength(100)]
        public string Nombres { get; set; }
        [StringLength(100)]
        public string Apellidos { get; set; }
        [StringLength(4)]
        public string Nota1 { get; set; }
        [StringLength(4)]
        public string Nota2 { get; set; }
        [Required]
        [StringLength(4)]
        public string Nota3 { get; set; }
    }
}
