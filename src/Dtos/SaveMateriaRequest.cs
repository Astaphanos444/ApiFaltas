using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Dtos
{
    public class SaveMateriaRequest
    {
        public string Nome { get; set; } = "";

        public long MaxFaltas { get; set; }

        public long UserId { get; set; }
    }
}