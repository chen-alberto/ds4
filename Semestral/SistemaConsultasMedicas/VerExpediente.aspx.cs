using System;
using System.Data;

namespace SistemaConsultasMedicas
{
    public partial class VerExpediente : System.Web.UI.Page
    {
        private int pacienteId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["pacienteId"], out pacienteId))
            {
                Response.Redirect("Default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarDatosPaciente();
                CargarExpediente();
                CargarConsultas();
                hlEditarExpediente.NavigateUrl = $"EditarExpediente.aspx?pacienteId={pacienteId}";
            }
        }

        private void CargarDatosPaciente()
        {
            string query = "SELECT * FROM Pacientes WHERE Id = @Id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new[] { new System.Data.SqlClient.SqlParameter("@Id", pacienteId) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblPaciente.Text = $"{row["Nombre"]} {row["Apellido"]}";
                lblCedula.Text = row["Cedula"].ToString();

                DateTime fechaNac = Convert.ToDateTime(row["FechaNacimiento"]);
                int edad = DateTime.Now.Year - fechaNac.Year;
                if (DateTime.Now < fechaNac.AddYears(edad)) edad--;

                lblFechaNacimiento.Text = $"{fechaNac:dd/MM/yyyy} ({edad} años)";
                lblEmail.Text = string.IsNullOrEmpty(row["Email"].ToString()) ? "No registrado" : row["Email"].ToString();
                lblTelefono.Text = string.IsNullOrEmpty(row["Telefono"].ToString()) ? "No registrado" : row["Telefono"].ToString();
                lblDireccion.Text = string.IsNullOrEmpty(row["Direccion"].ToString()) ? "No registrada" : row["Direccion"].ToString();
            }
        }

        private void CargarExpediente()
        {
            DataTable dt = ExpedienteMedico.ObtenerPorPaciente(pacienteId);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                decimal peso = Convert.ToDecimal(row["Peso"]);
                decimal altura = Convert.ToDecimal(row["Altura"]);
                decimal imc = peso / ((altura / 100) * (altura / 100));

                lblPeso.Text = $"{peso} kg";
                lblAltura.Text = $"{altura} cm";
                lblIMC.Text = $"{imc:F2}";
                lblTipoSangre.Text = string.IsNullOrEmpty(row["TipoSangre"].ToString()) ? "No registrado" : row["TipoSangre"].ToString();
                lblAlergias.Text = string.IsNullOrEmpty(row["Alergias"].ToString()) ? "Ninguna registrada" : row["Alergias"].ToString();
                lblEnfermedadesCronicas.Text = string.IsNullOrEmpty(row["EnfermedadesCronicas"].ToString()) ? "Ninguna registrada" : row["EnfermedadesCronicas"].ToString();
                lblMedicamentos.Text = string.IsNullOrEmpty(row["Medicamentos"].ToString()) ? "Ninguno registrado" : row["Medicamentos"].ToString();
                lblCirugiasPrevias.Text = string.IsNullOrEmpty(row["CirugiasPrevias"].ToString()) ? "Ninguna registrada" : row["CirugiasPrevias"].ToString();
                lblFechaActualizacion.Text = Convert.ToDateTime(row["FechaActualizacion"]).ToString("dd/MM/yyyy HH:mm");

                pnlExpediente.Visible = true;
                pnlNoExpediente.Visible = false;
            }
            else
            {
                pnlExpediente.Visible = false;
                pnlNoExpediente.Visible = true;
            }
        }

        private void CargarConsultas()
        {
            DataTable dt = Consulta.ObtenerPorPaciente(pacienteId);

            if (dt.Rows.Count > 0)
            {
                rptConsultas.DataSource = dt;
                rptConsultas.DataBind();
                pnlConsultas.Visible = true;
                pnlNoConsultas.Visible = false;
            }
            else
            {
                pnlConsultas.Visible = false;
                pnlNoConsultas.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (Request.UrlReferrer != null)
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}