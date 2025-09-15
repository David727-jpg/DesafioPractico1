using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DesafioPractico1
{
    public partial class Form1 : Form
    {
        private List<Libro> libros = new List<Libro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private Dictionary<int, Prestamo> prestamos = new Dictionary<int, Prestamo>();
        public Form1()
        {
            InitializeComponent();
        }
        // ----------------- LIBROS -----------------
        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            if (txtTituloLibro.Text == "" || txtAutorLibro.Text == "" || txtAnioLibro.Text == "")
            {
                MessageBox.Show("Por favor completa todos los campos de libro.");
                return;
            }

            Libro nuevo = new Libro()
            {
                Id = libros.Count + 1,
                Titulo = txtTituloLibro.Text,
                Autor = txtAutorLibro.Text,
                Anio = int.Parse(txtAnioLibro.Text)
            };

            libros.Add(nuevo);

            // Actualizar DataGridView
            dgvLibros.DataSource = null;
            dgvLibros.DataSource = libros;

            // Actualizar ComboBox de Libros en Préstamos
            cmbLibros.DataSource = null;
            cmbLibros.DataSource = libros;
            cmbLibros.DisplayMember = "Titulo";

            MessageBox.Show("Libro agregado con éxito.");
            txtTituloLibro.Clear();
            txtAutorLibro.Clear();
            txtAnioLibro.Clear();
        }

        // ================== AGREGAR USUARIO ==================
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "" || txtCorreoUsuario.Text == "")
            {
                MessageBox.Show("Por favor completa todos los campos de usuario.");
                return;
            }

            Usuario nuevo = new Usuario()
            {
                Id = usuarios.Count + 1,
                Nombre = txtNombreUsuario.Text,
                Correo = txtCorreoUsuario.Text
            };

            usuarios.Add(nuevo);

            // Actualizar DataGridView
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarios;

            // Actualizar ComboBox de Usuarios en Préstamos
            cmbUsuarios.DataSource = null;
            cmbUsuarios.DataSource = usuarios;
            cmbUsuarios.DisplayMember = "Nombre";

            MessageBox.Show("Usuario agregado con éxito.");
            txtNombreUsuario.Clear();
            txtCorreoUsuario.Clear();
        }

        // ================== REGISTRAR PRÉSTAMO ==================
        private void btnAgregarPrestamo_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem == null || cmbLibros.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un usuario y un libro.");
                return;
            }

            Usuario usuario = (Usuario)cmbUsuarios.SelectedItem;
            Libro libro = (Libro)cmbLibros.SelectedItem;

            Prestamo nuevo = new Prestamo()
            {
                Id = prestamos.Count + 1,
                Usuario = usuario,
                Libro = libro,
                FechaPrestamo = DateTime.Now,
                FechaDevolucion = DateTime.Now.AddDays(7)
            };

            prestamos.Add(nuevo.Id, nuevo);

            // Mostrar en DataGridView
            dgvPrestamo.DataSource = null;
            dgvPrestamo.DataSource = new List<Prestamo>(prestamos.Values);

            ActualizarGraficos();

            MessageBox.Show("Préstamo registrado con éxito.");
        }

        private void ActualizarGraficos()
        {
            // ----- LIBROS MÁS PRESTADOS -----
            chartLibros.Series.Clear();
            chartLibros.ChartAreas.Clear();
            ChartArea areaLibros = new ChartArea();
            chartLibros.ChartAreas.Add(areaLibros);

            Series serieLibros = new Series("Libros Más Prestados");
            serieLibros.ChartType = SeriesChartType.Column;

            var librosMasPrestados = prestamos.Values
                .GroupBy(p => p.Libro.Titulo)
                .Select(g => new { Titulo = g.Key, Cantidad = g.Count() });

            if (librosMasPrestados.Any())
            {
                foreach (var item in librosMasPrestados)
                {
                    serieLibros.Points.AddXY(item.Titulo, item.Cantidad);
                }
            }
            else
            {
                serieLibros.Points.AddXY("Sin datos", 0);
            }

            chartLibros.Series.Add(serieLibros);

            // ----- USUARIOS MÁS ACTIVOS -----
            chartUsuarios.Series.Clear();
            chartUsuarios.ChartAreas.Clear();
            ChartArea areaUsuarios = new ChartArea();
            chartUsuarios.ChartAreas.Add(areaUsuarios);

            Series serieUsuarios = new Series("Usuarios Más Activos");
            serieUsuarios.ChartType = SeriesChartType.Column;

            var usuariosMasActivos = prestamos.Values
                .GroupBy(p => p.Usuario.Nombre)
                .Select(g => new { Usuario = g.Key, Cantidad = g.Count() });

            if (usuariosMasActivos.Any())
            {
                foreach (var item in usuariosMasActivos)
                {
                    serieUsuarios.Points.AddXY(item.Usuario, item.Cantidad);
                }
            }
            else
            {
                serieUsuarios.Points.AddXY("Sin datos", 0);
            }

            chartUsuarios.Series.Add(serieUsuarios);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarGraficos();
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtAutorLibro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void chartLibros_Click(object sender, EventArgs e)
        {

        }

        private void chartUsuarios_Click(object sender, EventArgs e)
        {

        }
    }
}
