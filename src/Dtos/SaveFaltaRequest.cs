using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Dtos
{
    public class SaveFaltaRequest
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public long MateriaId { get; set; }
    }
}