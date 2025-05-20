using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.model
{
    public class Falta
    {
        public long Id { get; set; }
        public DateTime DataFalta { get; set; }

        public long UserId { get; set; }
        public long MateriaId { get; set; }
        public Materia Materia { get; set; } = new Materia();
        public User User { get; set; } = new User();

    }
}