using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Dtos
{
    public class SaveMateriaRequest
    {

        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public long MaxFaltas { get; set; }
        [Required]
        public long UserId { get; set; }
    }
}