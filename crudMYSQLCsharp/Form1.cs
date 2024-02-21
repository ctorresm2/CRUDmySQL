using crudMYSQLCsharp.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudMYSQLCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
            objetoAlumnos.mostrarAlumnos(dgvTotalAlumnos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clases.CConexion objetoConexion = new Clases.CConexion();

            objetoConexion.establecerConexion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
            objetoAlumnos.guardarAlumnos(txtNombre, txtApellido);
            objetoAlumnos.mostrarAlumnos(dgvTotalAlumnos);
        }

        private void dgvTotalAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
            objetoAlumnos.SeleccionarAlumnos(dgvTotalAlumnos,txtId,txtNombre,txtApellido);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
            objetoAlumnos.modificarAlumnos(txtId,txtNombre, txtApellido);
            objetoAlumnos.mostrarAlumnos(dgvTotalAlumnos);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
            objetoAlumnos.eliminarAlumnos(txtId);
            objetoAlumnos.mostrarAlumnos(dgvTotalAlumnos);
        }
    }
}
