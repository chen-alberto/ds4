using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaConsultasMedicas
{
    public partial class ConsultasPendientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarConsultas();
                CargarEstadisticas();
            }
        }

        private void CargarConsultas(string filtro = "")
        {
            try
            {
                string query = @"
                    SELECT 
                        c.Id,
                        c.FechaCreacion,
                        c.Motivo,
                        c.Descripcion,
                        c.Estado,
                        p.Nombre + ' ' + p.Apellido AS NombrePaciente,
                        p.Cedula,
                        m.Nombre + ' ' + m.Apellido AS NombreMedico
                    FROM Consultas c
                    INNER JOIN Pacientes p ON c.PacienteId = p.Id
                    LEFT JOIN Medicos m ON c.MedicoId = m.Id";

                if (!string.IsNullOrEmpty(filtro))
                {
                    query += @" WHERE 
                        p.Nombre LIKE @Filtro OR 
                        p.Apellido LIKE @Filtro OR 
                        p.Cedula LIKE @Filtro OR 
                        c.Motivo LIKE @Filtro";
                }

                query += " ORDER BY c.FechaCreacion DESC";

                DataTable dt;
                if (!string.IsNullOrEmpty(filtro))
                {
                    dt = DatabaseHelper.ExecuteQuery(query,
                        new[] { new System.Data.SqlClient.SqlParameter("@Filtro", "%" + filtro + "%") });
                }
                else
                {
                    dt = DatabaseHelper.ExecuteQuery(query);
                }

                gvConsultas.DataSource = dt;
                gvConsultas.DataBind();

                if (dt.Rows.Count == 0 && !string.IsNullOrEmpty(filtro))
                {
                    MostrarMensaje("No se encontraron consultas con los criterios de búsqueda especificados.", true);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar las consultas: " + ex.Message, false);
            }
        }

        private void CargarEstadisticas()
        {
            try
            {
                // Total de consultas
                string queryTotal = "SELECT COUNT(*) FROM Consultas";
                DataTable dtTotal = DatabaseHelper.ExecuteQuery(queryTotal);
                lblTotalConsultas.Text = dtTotal.Rows[0][0].ToString();

                // Consultas pendientes
                string queryPendientes = "SELECT COUNT(*) FROM Consultas WHERE Estado = 'Pendiente'";
                DataTable dtPendientes = DatabaseHelper.ExecuteQuery(queryPendientes);
                lblPendientes.Text = dtPendientes.Rows[0][0].ToString();

                // Consultas respondidas
                string queryRespondidas = "SELECT COUNT(*) FROM Consultas WHERE Estado = 'Respondida'";
                DataTable dtRespondidas = DatabaseHelper.ExecuteQuery(queryRespondidas);
                lblRespondidas.Text = dtRespondidas.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar las estadísticas: " + ex.Message, false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            CargarConsultas(filtro);
            CargarEstadisticas();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            CargarConsultas();
            pnlMessage.Visible = false;
        }

        protected void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearConsulta.aspx");
        }

        protected void gvConsultas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int consultaId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"VerConsulta.aspx?consultaId={consultaId}");
            }
            else if (e.CommandName == "Responder")
            {
                int consultaId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"ResponderConsulta.aspx?consultaId={consultaId}");
            }
        }

        private void MostrarMensaje(string mensaje, bool esInfo)
        {
            pnlMessage.Visible = true;
            pnlMessage.CssClass = esInfo ? "message info" : "message success";
            pnlMessage.Controls.Clear();
            pnlMessage.Controls.Add(new LiteralControl(mensaje));
        }
    }
}