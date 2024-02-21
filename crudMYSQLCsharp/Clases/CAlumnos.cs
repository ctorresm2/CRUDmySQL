using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudMYSQLCsharp.Clases
{
    internal class CAlumnos
    {
        public void mostrarAlumnos(DataGridView tablaAlmunos) 
        {
            try 
            {
                CConexion objetoConexion = new CConexion();

                String query = "select * from alumnos";
                tablaAlmunos.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query,objetoConexion.establecerConexion());

                DataTable dt = new DataTable();

                adapter.Fill(dt);
                tablaAlmunos.DataSource = dt;
                objetoConexion.cerrarConexion();
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show("No se mostraron los datos de la Base de Datos, error:" +ex);
            }    
        }

        public void guardarAlumnos(TextBox nombres, TextBox apellidos)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert in to alumnos(nombres, apellidos)"+"values('"+nombres.Text+"','"+apellidos.Text+"');";

                MySqlCommand myComand = new MySqlCommand(query,objetoConexion.establecerConexion());

                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("Se guardo los registros");

                while (reader.Read())

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la Base de Datos, error:" + ex);
            }
        }

        public void SeleccionarAlumnos(DataGridView tablaAlumnos, TextBox id, TextBox nombres, TextBox apellidos)
        {
            try
            {
                id.Text = tablaAlumnos.CurrentRow.Cells[0].Value.ToString();
                nombres.Text = tablaAlumnos.CurrentRow.Cells[1].Value.ToString();
                apellidos.Text = tablaAlumnos.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar los datos de la Base de Datos, error:" + ex.ToString());
            }
        }

        public void modificarAlumnos(TextBox id,TextBox nombres, TextBox apellidos)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "update alumnos set nombres='" + nombres.Text + "', apellidos='" + apellidos.Text + "' where id='" + id.Text + "';";

                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());

                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("Se modifico los registros");

                while (reader.Read())

                    objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se actualizaron los datos, error:" + ex);
            }
        }

        public void eliminarAlumnos(TextBox id)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "delete from alumnos where id='" + id.Text + "';";

                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());

                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("Se elimino el registro");

                while (reader.Read())

                    objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se actualizaron los datos, error:" + ex);
            }
        }

    }
}
