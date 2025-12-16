using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaConsultasMedicas
{
    public partial class CrearConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
            }
        }

        private void InicializarPagina()
        {
            pnlMessage.Visible = false;
            pnlPacienteInfo.Visible = false;
            pnlConsultaForm.Visible = false;
            pnlInstrucciones.Visible = true;
            txtBuscarCedula.Focus();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string cedula = txtBuscarCedula.Text.Trim();

            if (string.IsNullOrEmpty(cedula))
            {
                MostrarMensaje("Por favor ingrese un número de cédula", false);
                return;
            }

            try
            {
                DataTable dt = BuscarPacientePorCedula(cedula);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Guardar el ID del paciente
                    hfPacienteId.Value = row["Id"].ToString();

                    // Calcular edad
                    DateTime fechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
                    int edad = DateTime.Now.Year - fechaNacimiento.Year;
                    if (DateTime.Now < fechaNacimiento.AddYears(edad))
                        edad--;

                    // Mostrar información del paciente
                    lblPacienteInfo.Text = $@"
                        <strong>Nombre:</strong> {row["Nombre"]} {row["Apellido"]}<br/>
                        <strong>Cédula:</strong> {row["Cedula"]}<br/>
                        <strong>Edad:</strong> {edad} años<br/>
                        <strong>Email:</strong> {row["Email"]}<br/>
                        <strong>Teléfono:</strong> {row["Telefono"]}
                    ";

                    // Mostrar el formulario de consulta
                    pnlPacienteInfo.Visible = true;
                    pnlConsultaForm.Visible = true;
                    pnlInstrucciones.Visible = false;
                    pnlMessage.Visible = false;

                    // Limpiar campos del formulario
                    txtMotivo.Text = "";
                    txtDescripcion.Text = "";
                }
                else
                {
                    MostrarMensaje("No se encontró ningún paciente con esa cédula. Por favor verifique e intente nuevamente.", false);
                    OcultarFormulario();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al buscar el paciente: " + ex.Message, false);
                OcultarFormulario();
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            if (string.IsNullOrEmpty(hfPacienteId.Value))
            {
                MostrarMensaje("Por favor busque un paciente antes de enviar la consulta", false);
                return;
            }

            try
            {
                int pacienteId = int.Parse(hfPacienteId.Value);
                string motivo = txtMotivo.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();

                // Crear la consulta
                bool exito = CrearNuevaConsulta(pacienteId, motivo, descripcion);

                if (exito)
                {
                    MostrarMensaje("¡Consulta creada exitosamente! Un médico la revisará pronto.", true);

                    // Limpiar el formulario después de 2 segundos y redirigir
                    string script = @"
                        setTimeout(function() {
                            window.location.href = 'ConsultasPendientes.aspx';
                        }, 2000);
                    ";
                    ScriptManager.RegisterStartupScript(this, GetType(), "RedirectScript", script, true);
                }
                else
                {
                    MostrarMensaje("No se pudo crear la consulta. Por favor intente nuevamente.", false);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al crear la consulta: " + ex.Message, false);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private DataTable BuscarPacientePorCedula(string cedula)
        {
            string query = @"SELECT Id, Nombre, Apellido, Cedula, Email, Telefono, FechaNacimiento 
                           FROM Pacientes 
                           WHERE Cedula = @Cedula";

            return DatabaseHelper.ExecuteQuery(query,
                new[] { new System.Data.SqlClient.SqlParameter("@Cedula", cedula) });
        }

        private bool CrearNuevaConsulta(int pacienteId, string motivo, string descripcion)
        {
            string query = @"INSERT INTO Consultas (PacienteId, Motivo, Descripcion, FechaCreacion, Estado) 
                           VALUES (@PacienteId, @Motivo, @Descripcion, @FechaCreacion, @Estado)";

            var parametros = new[]
            {
                new System.Data.SqlClient.SqlParameter("@PacienteId", pacienteId),
                new System.Data.SqlClient.SqlParameter("@Motivo", motivo),
                new System.Data.SqlClient.SqlParameter("@Descripcion", descripcion),
                new System.Data.SqlClient.SqlParameter("@FechaCreacion", DateTime.Now),
                new System.Data.SqlClient.SqlParameter("@Estado", "Pendiente")
            };

            // Fix: Remove assignment, just call ExecuteNonQuery (returns void)
            DatabaseHelper.ExecuteNonQuery(query, parametros);
            // Since we can't check affected rows, assume success if no exception
            return true;
        }

        private void MostrarMensaje(string mensaje, bool esExito)
        {
            pnlMessage.Visible = true;
            pnlMessage.CssClass = esExito ? "message success" : "message error";
            pnlMessage.Controls.Clear();
            pnlMessage.Controls.Add(new LiteralControl(mensaje));
        }

        private void OcultarFormulario()
        {
            pnlPacienteInfo.Visible = false;
            pnlConsultaForm.Visible = false;
            hfPacienteId.Value = "";
        }
    }
}