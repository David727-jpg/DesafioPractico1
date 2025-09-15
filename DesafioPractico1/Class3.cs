using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPractico1
{
    internal class Prestamo
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Libro Libro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}
