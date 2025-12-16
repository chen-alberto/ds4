using System;
using System.Data;

namespace SistemaConsultasMedicas
{
    public partial class Expedientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes();
            }
        }

        private void CargarPacientes(string filtro = "")
        {
            DataTable dt;

            if (string.IsNullOrEmpty(filtro))
            {
                dt = Paciente.ObtenerTodos();
            }
            else
            {
                string query = @"SELECT * FROM Pacientes 
                               WHERE Nombre LIKE @Filtro 
                               OR Apellido LIKE @Filtro 
                               OR Cedula LIKE @Filtro
                               ORDER BY Apellido, Nombre";

                dt = DatabaseHelper.ExecuteQuery(query,
                    new[] { new System.Data.SqlClient.SqlParameter("@Filtro", $"%{filtro}%") });
            }

            if (dt.Rows.Count > 0)
            {
                gvPacientes.DataSource = dt;
                gvPacientes.DataBind();
                pnlTabla.Visible = true;
                pnlNoData.Visible = false;
            }
            else
            {
                pnlTabla.Visible = false;
                pnlNoData.Visible = true;
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarPacientes(txtBuscar.Text.Trim());
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected string CalcularEdad(object fechaNacimiento)
        {
            if (fechaNacimiento == null || fechaNacimiento == DBNull.Value)
                return "N/A";

            DateTime fechaNac = Convert.ToDateTime(fechaNacimiento);
            int edad = DateTime.Now.Year - fechaNac.Year;
            if (DateTime.Now < fechaNac.AddYears(edad))
                edad--;

            return edad.ToString();
        }
    }
}