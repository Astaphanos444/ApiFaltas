

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.model
{
    public class Materia
    {
        public long Id { get; set; }
        public string Nome { get; set; } = "";

        public long MaxFaltas { get; set; }

        public long UserId { get; set; }
        public User User{ get; set; } = new User();

    }
}