using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestAppTP.Models.DB
{
    public partial class EstudiantePromedio
    {
        [Key]
        public long Id { get; set; }
        public long? IdEstudiante { get; set; }
        [StringLength(50)]
        public string PromedioNotas { get; set; }
    }
}
