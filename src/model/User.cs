using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.model
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";

        public List<Materia> Materias { get; set; } = new List<Materia>();
        public List<Falta> Faltas { get; set; } = new List<Falta>();
    }
}