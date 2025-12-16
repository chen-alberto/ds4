using System;
using System.Data;
using System.Web.UI;

namespace SistemaConsultasMedicas
{
    public partial class VerConsulta : System.Web.UI.Page
    {
        private int consultaId;
        private int pacienteId;
        private string estadoConsulta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["consultaId"], out consultaId))
            {
                Response.Redirect("ConsultasPendientes.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarConsulta();
            }
        }

        private void CargarConsulta()
        {
            try
            {
                string query = @"
                    SELECT 
                        c.Id,
                        c.Motivo,
                        c.Descripcion,
                        c.Respuesta,
                        c.Estado,
                        c.FechaCreacion,
                        c.FechaRespuesta,
                        p.Id as PacienteId,
                        p.Nombre as NombrePaciente,
                        p.Apellido as ApellidoPaciente,
                        p.Cedula,
                        p.Email,
                        p.Telefono,
                        p.FechaNacimiento,
                        m.Nombre as NombreMedico,
                        m.Apellido as ApellidoMedico,
                        m.Especialidad
                    FROM Consultas c
                    INNER JOIN Pacientes p ON c.PacienteId = p.Id
                    LEFT JOIN Medicos m ON c.MedicoId = m.Id
                    WHERE c.Id = @Id";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new[] { new System.Data.SqlClient.SqlParameter("@Id", consultaId) });

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Guardar datos importantes
                    pacienteId = Convert.ToInt32(row["PacienteId"]);
                    estadoConsulta = row["Estado"].ToString();

                    // Información de la consulta
                    lblConsultaId.Text = row["Id"].ToString();
                    lblFechaCreacion.Text = Convert.ToDateTime(row["FechaCreacion"]).ToString("dd/MM/yyyy HH:mm");
                    lblMotivo.Text = row["Motivo"].ToString();
                    lblDescripcion.Text = row["Descripcion"].ToString();

                    // Estado
                    lblEstado.Text = estadoConsulta == "Pendiente"
                        ? "⏳ CONSULTA PENDIENTE"
                        : "✓ CONSULTA RESPONDIDA";
                    pnlEstado.CssClass = estadoConsulta == "Pendiente"
                        ? "status-banner status-pendiente"
                        : "status-banner status-respondida";

                    // Fecha de respuesta
                    if (row["FechaRespuesta"] != DBNull.Value)
                    {
                        lblFechaRespuesta.Text = Convert.ToDateTime(row["FechaRespuesta"]).ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        lblFechaRespuesta.Text = "Pendiente";
                        lblFechaRespuesta.CssClass = "metadata-value";
                        lblFechaRespuesta.ForeColor = System.Drawing.Color.Gray;
                    }

                    // Información del paciente
                    lblNombrePaciente.Text = $"{row["NombrePaciente"]} {row["ApellidoPaciente"]}";
                    lblCedula.Text = row["Cedula"].ToString();
                    lblEmail.Text = row["Email"].ToString();
                    lblTelefono.Text = row["Telefono"] != DBNull.Value
                        ? row["Telefono"].ToString()
                        : "No registrado";

                    // Calcular edad
                    if (row["FechaNacimiento"] != DBNull.Value)
                    {
                        DateTime fechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
                        int edad = DateTime.Now.Year - fechaNacimiento.Year;
                        if (DateTime.Now < fechaNacimiento.AddYears(edad))
                            edad--;
                        lblEdad.Text = $"{edad} años";
                    }
                    else
                    {
                        lblEdad.Text = "No registrada";
                    }

                    // Link al expediente
                    hlExpediente.NavigateUrl = $"VerExpediente.aspx?pacienteId={pacienteId}";

                    // Respuesta médica
                    if (estadoConsulta == "Respondida")
                    {
                        pnlMedico.Visible = true;
                        pnlRespuesta.Visible = true;
                        pnlSinRespuesta.Visible = false;

                        if (row["NombreMedico"] != DBNull.Value)
                        {
                            string especialidad = row["Especialidad"] != DBNull.Value
                                ? row["Especialidad"].ToString()
                                : "";
                            lblMedico.Text = $"Dr. {row["NombreMedico"]} {row["ApellidoMedico"]}";
                            if (!string.IsNullOrEmpty(especialidad))
                                lblMedico.Text += $" - {especialidad}";
                        }

                        lblRespuesta.Text = row["Respuesta"] != DBNull.Value
                            ? row["Respuesta"].ToString()
                            : "Sin respuesta registrada";
                    }
                    else
                    {
                        pnlMedico.Visible = false;
                        pnlRespuesta.Visible = false;
                        pnlSinRespuesta.Visible = true;
                        btnResponder.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("ConsultasPendientes.aspx");
                }
            }
            catch (Exception ex)
            {
                // En caso de error, mostrar mensaje y redirigir
                Session["Error"] = "Error al cargar la consulta: " + ex.Message;
                Response.Redirect("ConsultasPendientes.aspx");
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultasPendientes.aspx");
        }

        protected void btnResponder_Click(object sender, EventArgs e)
        {
            Response.Redirect($"ResponderConsulta.aspx?consultaId={consultaId}");
        }
    }
}