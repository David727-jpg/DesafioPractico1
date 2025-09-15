using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPractico1
{
    internal class Libro
    {
        private string anio;

        public Libro()
        {
        }

        public Libro(string titulo, string autor, string anio)
        {
            Titulo = titulo;
            Autor = autor;
            this.anio = anio;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public int VecesPrestado { get; set; } = 0;
        public override string ToString()
        {
            return Titulo;  // así muestra el título
        }

    }
}
