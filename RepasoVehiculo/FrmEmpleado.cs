using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepasoEstudiante
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void MtdMostrarEmpleados()
        {
            CD_Empleados cD_Empleados = new CD_Empleados();
            DataTable dtMostrarUniversidad= cD_Empleados.MtMostrarEmpleados();
            dgvEmpleados.DataSource = dtMostrarUniversidad;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MtdMostrarEmpleados();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CD_Empleados cD_Empleados = new CD_Empleados();

            try
            {
                cD_Empleados.CP_mtdAgregarEmpleados(txtNombre.Text, txtApellido.Text, DateTime.Parse(txtFechaNacimiento.Text), DateTime.Parse(txtFechaContratacion.Text),int.Parse(txtDepartamentoID.Text),txtPuesto.Text,decimal.Parse(txtSalario.Text),cboxEstado.Text);
                MessageBox.Show("Empleado agregado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarEmpleados();
                mtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CD_Empleados cD_Empleados = new CD_Empleados();


                int EmpleadoID = int.Parse(txtempleadoID.Text);
                string Nombre = txtNombre.Text;
                string Apellido = txtApellido.Text;
                DateTime FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                DateTime FechaContratacion = DateTime.Parse(txtFechaContratacion.Text);
                int DepartamentoID = int.Parse(txtDepartamentoID.Text);
                string Puesto = txtPuesto.Text;
                decimal Salario = decimal.Parse(txtSalario.Text);
                string Estado = cboxEstado.Text;

                int vCantidadRegistros = cD_Empleados.CP_mtdActualizarEmpleado(EmpleadoID, Nombre, Apellido, FechaNacimiento, FechaContratacion, DepartamentoID, Puesto, Salario, Estado);

                if (vCantidadRegistros > 0)
                {
                    MessageBox.Show("Registro actualizado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró el estudiante", "Error actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MtdMostrarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void mtdLimpiarCampos()
        {
            txtempleadoID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaNacimiento.Text = "";
            txtFechaContratacion.Text = "";
            txtDepartamentoID.Text = "";
            txtPuesto.Text = "";
            txtSalario.Text = "";
            cboxEstado.Text = "";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CD_Empleados cD_Empleados = new CD_Empleados();

            int codigo = int.Parse(txtempleadoID.Text);
            int vCantidadRegistros = cD_Empleados.CP_mtdEliminarEmpleados(codigo);

            if (vCantidadRegistros > 0)
            {
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("No se encontró codigo!!", "Error eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            MtdMostrarEmpleados();
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtempleadoID.Text = dgvEmpleados.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvEmpleados.SelectedCells[1].Value.ToString();
            txtApellido.Text = dgvEmpleados.SelectedCells[2].Value.ToString();
            txtFechaNacimiento.Text = dgvEmpleados.SelectedCells[3].Value.ToString();
            txtFechaContratacion.Text = dgvEmpleados.SelectedCells[4].Value.ToString();
            txtDepartamentoID.Text = dgvEmpleados.SelectedCells[5].Value.ToString();
            txtPuesto.Text = dgvEmpleados.SelectedCells[6].Value.ToString();
            txtSalario.Text = dgvEmpleados.SelectedCells[7].Value.ToString();
            cboxEstado.Text = dgvEmpleados.SelectedCells[8].Value.ToString();
        }

        private void cboxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
