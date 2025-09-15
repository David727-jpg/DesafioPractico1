using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            MessageBox.Show("Préstamo registrado con éxito.");
        }




        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}
