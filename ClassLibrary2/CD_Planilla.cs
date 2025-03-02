using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Empleados
    {

        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtMostrarEmpleados()
        {
            string QryMostrarEmpleados= "sp_MostrarEmpleados";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarEmpleados, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarEmpleados= new DataTable();
            adapter.Fill(dtMostrarEmpleados);
            db_conexion.MtdCerrarConexion();
            return dtMostrarEmpleados;
        }

//        @EmpleadoID INT,
//@Nombre NVARCHAR(100),
//    @Apellido NVARCHAR(100),
//    @FechaNacimiento DATE,
//    @FechaContratacion DATE,
//    @DepartamentoID INT,
//    @PuestoTrabajo NVARCHAR(255),
//    @Salario DECIMAL(18,2),
//    @Estado NVARCHAR(50)

        // Capa datos
        public void CP_mtdAgregarEmpleados(string Nombre, string Apellido, DateTime FechaNacimiento, DateTime FechaContratacion, int DepartamentoID, string PuestoTrabajo, decimal Salario, string Estado)
        {

            string Usp_crear = "sp_InsertarEmpleado";
            SqlCommand cmd_InsertarEmpleado= new SqlCommand(Usp_crear, db_conexion.MtdAbrirConexion());
            cmd_InsertarEmpleado.CommandType = CommandType.StoredProcedure;

            cmd_InsertarEmpleado.Parameters.AddWithValue("@Nombre", Nombre);
            cmd_InsertarEmpleado.Parameters.AddWithValue("@Apellido", Apellido);
            cmd_InsertarEmpleado.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            cmd_InsertarEmpleado.Parameters.AddWithValue("@FechaContratacion", FechaContratacion);
            cmd_InsertarEmpleado.Parameters.AddWithValue("@DepartamentoID", DepartamentoID);
            cmd_InsertarEmpleado.Parameters.AddWithValue("@PuestoTrabajo", PuestoTrabajo);
            cmd_InsertarEmpleado.Parameters.AddWithValue("@Salario", Salario);
            cmd_InsertarEmpleado.Parameters.AddWithValue("@Estado", Estado);    
            cmd_InsertarEmpleado.ExecuteNonQuery();
        }
        public int CP_mtdActualizarEmpleado(int EmpleadoID, string Nombre, string Apellido, DateTime FechaNacimiento, DateTime FechaContratacion, int DepartamentoID, string PuestoTrabajo, decimal Salario, string Estado)
        {
            int vContarRegistrosAfectados = 0;

            string vUspActualizarEmpleados= "sp_ActualizarEmpleado";
            SqlCommand commActualizarEmpleados = new SqlCommand(vUspActualizarEmpleados, db_conexion.MtdAbrirConexion());
            commActualizarEmpleados.CommandType = CommandType.StoredProcedure;

            commActualizarEmpleados.Parameters.AddWithValue("@EmpleadoID", EmpleadoID);
            commActualizarEmpleados.Parameters.AddWithValue("@Nombre", Nombre);
            commActualizarEmpleados.Parameters.AddWithValue("@Apellido", Apellido);
            commActualizarEmpleados.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            commActualizarEmpleados.Parameters.AddWithValue("@FechaContratacion", FechaContratacion);
            commActualizarEmpleados.Parameters.AddWithValue("@DepartamentoID", DepartamentoID);
            commActualizarEmpleados.Parameters.AddWithValue("@PuestoTrabajo", PuestoTrabajo);
            commActualizarEmpleados.Parameters.AddWithValue("@Salario", Salario);
            commActualizarEmpleados.Parameters.AddWithValue("@Estado", Estado);
            vContarRegistrosAfectados = commActualizarEmpleados.ExecuteNonQuery();
            return vContarRegistrosAfectados;
        }

        public int CP_mtdEliminarEmpleados(int EmpleadoID)
        {
            int vCantidadRegistrosEliminados = 0;

            string vUspEliminarEmpleado= "sp_EliminarEmpleado";
            SqlCommand commEliminarEmpleado = new SqlCommand(vUspEliminarEmpleado, db_conexion.MtdAbrirConexion());
            commEliminarEmpleado.CommandType = CommandType.StoredProcedure;

            commEliminarEmpleado.Parameters.AddWithValue("@EmpleadoID", EmpleadoID);

            vCantidadRegistrosEliminados = commEliminarEmpleado.ExecuteNonQuery();
            return vCantidadRegistrosEliminados;
        }
    }
}
