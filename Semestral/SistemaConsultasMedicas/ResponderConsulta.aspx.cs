using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SistemaConsultasMedicas
{
    public partial class ResponderConsulta : System.Web.UI.Page
    {
        private int consultaId;
        private int pacienteId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["consultaId"], out consultaId))
            {
                Response.Redirect("ConsultasPendientes.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarMedicos();
                CargarConsulta();
            }
        }

        private void CargarMedicos()
        {
            DataTable dt = Medico.ObtenerTodos();

            ddlMedico.DataSource = dt;
            ddlMedico.DataTextField = "Nombre";
            ddlMedico.DataValueField = "Id";
            ddlMedico.DataBind();

            // Agregar el texto combinado después del databind
            foreach (ListItem item in ddlMedico.Items)
            {
                DataRow[] rows = dt.Select($"Id = {item.Value}");
                if (rows.Length > 0)
                {
                    item.Text = $"Dr. {rows[0]["Nombre"]} {rows[0]["Apellido"]} - {rows[0]["Especialidad"]}";
                }
            }

            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione un médico --", ""));
        }

        private void CargarConsulta()
        {
            string query = @"SELECT c.*, p.Nombre, p.Apellido, p.Cedula, p.Email, p.Telefono, p.FechaNacimiento, p.Id as PacienteId
                           FROM Consultas c
                           INNER JOIN Pacientes p ON c.PacienteId = p.Id
                           WHERE c.Id = @Id";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new[] { new System.Data.SqlClient.SqlParameter("@Id", consultaId) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                pacienteId = Convert.ToInt32(row["PacienteId"]);

                lblConsultaId.Text = row["Id"].ToString();
                lblFecha.Text = Convert.ToDateTime(row["FechaCreacion"]).ToString("dd/MM/yyyy HH:mm");
                lblMotivo.Text = row["Motivo"].ToString();
                lblDescripcion.Text = row["Descripcion"].ToString();

                int edad = DateTime.Now.Year - Convert.ToDateTime(row["FechaNacimiento"]).Year;

                lblPacienteInfo.Text = $@"
                    <div class='info-row'><strong>Nombre:</strong> {row["Nombre"]} {row["Apellido"]}</div>
                    <div class='info-row'><strong>Cédula:</strong> {row["Cedula"]}</div>
                    <div class='info-row'><strong>Edad:</strong> {edad} años</div>
                    <div class='info-row'><strong>Email:</strong> {row["Email"]}</div>
                    <div class='info-row'><strong>Teléfono:</strong> {row["Telefono"]}</div>
                ";

                hlExpediente.NavigateUrl = $"VerExpediente.aspx?pacienteId={pacienteId}";
            }
            else
            {
                Response.Redirect("ConsultasPendientes.aspx");
            }
        }

        protected void btnEnviarRespuesta_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int medicoId = int.Parse(ddlMedico.SelectedValue);
                    string respuesta = txtRespuesta.Text.Trim();

                    Consulta.Responder(consultaId, medicoId, respuesta);

                    Response.Redirect("ConsultasPendientes.aspx");
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al enviar la respuesta: " + ex.Message, false);
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultasPendientes.aspx");
        }

        private void MostrarMensaje(string mensaje, bool esExito)
        {
            pnlMessage.Visible = true;
            pnlMessage.CssClass = esExito ? "message success" : "message error";
            pnlMessage.Controls.Clear();
            pnlMessage.Controls.Add(new System.Web.UI.LiteralControl(mensaje));
        }
    }
}