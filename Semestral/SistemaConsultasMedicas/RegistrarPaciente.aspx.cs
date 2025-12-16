using System;
using System.Data;
using System.Web.UI;

namespace SistemaConsultasMedicas
{
    public partial class RegistrarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configurar fecha máxima (hoy) para el control de fecha
                txtFechaNacimiento.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            try
            {
                // Validar que la cédula no esté duplicada
                if (ExisteCedula(txtCedula.Text.Trim()))
                {
                    MostrarMensaje("Ya existe un paciente registrado con esta cédula.", false);
                    return;
                }

                // Validar edad (no puede ser fecha futura)
                DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                if (fechaNacimiento > DateTime.Today)
                {
                    MostrarMensaje("La fecha de nacimiento no puede ser futura.", false);
                    return;
                }

                // Crear el paciente
                int pacienteId = CrearPaciente();

                if (pacienteId > 0)
                {
                    // Verificar si debe crear expediente
                    if (chkCrearExpediente.Checked)
                    {
                        // Redirigir a crear expediente
                        Response.Redirect($"EditarExpediente.aspx?pacienteId={pacienteId}&nuevo=true");
                    }
                    else
                    {
                        // Mostrar mensaje y redirigir al inicio
                        Session["MensajeExito"] = "Paciente registrado exitosamente.";
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    MostrarMensaje("No se pudo registrar el paciente. Por favor intente nuevamente.", false);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al registrar el paciente: " + ex.Message, false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private bool ExisteCedula(string cedula)
        {
            string query = "SELECT COUNT(*) FROM Pacientes WHERE Cedula = @Cedula";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new[] { new System.Data.SqlClient.SqlParameter("@Cedula", cedula) });

            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        private int CrearPaciente()
        {
            try
            {
                // Crear objeto Paciente
                Paciente paciente = new Paciente
                {
                    Cedula = txtCedula.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                    Sexo = ddlSexo.SelectedValue,
                    Email = txtEmail.Text.Trim(),
                    Telefono = string.IsNullOrEmpty(txtTelefono.Text.Trim()) ? null : txtTelefono.Text.Trim(),
                    Direccion = string.IsNullOrEmpty(txtDireccion.Text.Trim()) ? null : txtDireccion.Text.Trim()
                };

                // Usar el método Crear de la clase Paciente
                return Paciente.Crear(paciente);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al crear paciente: " + ex.Message);
                throw; // Re-lanzar la excepción para que se muestre el mensaje al usuario
            }
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