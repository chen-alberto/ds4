using System;
using System.Data;

namespace SistemaConsultasMedicas
{
    public partial class EditarExpediente : System.Web.UI.Page
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
            }
        }

        private void CargarDatosPaciente()
        {
            DataTable dt = Paciente.BuscarPorCedula(
                DatabaseHelper.ExecuteQuery($"SELECT Cedula FROM Pacientes WHERE Id = {pacienteId}")
                .Rows[0]["Cedula"].ToString()
            );

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblPaciente.Text = $"Paciente: {row["Nombre"]} {row["Apellido"]} - Cédula: {row["Cedula"]}";
            }
        }

        private void CargarExpediente()
        {
            DataTable dt = ExpedienteMedico.ObtenerPorPaciente(pacienteId);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtPeso.Text = row["Peso"].ToString();
                txtAltura.Text = row["Altura"].ToString();

                if (!string.IsNullOrEmpty(row["TipoSangre"].ToString()))
                    ddlTipoSangre.SelectedValue = row["TipoSangre"].ToString();

                txtAlergias.Text = row["Alergias"].ToString();
                txtEnfermedadesCronicas.Text = row["EnfermedadesCronicas"].ToString();
                txtMedicamentos.Text = row["Medicamentos"].ToString();
                txtCirugiasPrevias.Text = row["CirugiasPrevias"].ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ExpedienteMedico expediente = new ExpedienteMedico
                    {
                        PacienteId = pacienteId,
                        Peso = decimal.Parse(txtPeso.Text),
                        Altura = decimal.Parse(txtAltura.Text),
                        TipoSangre = ddlTipoSangre.SelectedValue,
                        Alergias = txtAlergias.Text.Trim(),
                        EnfermedadesCronicas = txtEnfermedadesCronicas.Text.Trim(),
                        Medicamentos = txtMedicamentos.Text.Trim(),
                        CirugiasPrevias = txtCirugiasPrevias.Text.Trim()
                    };

                    ExpedienteMedico.CrearOActualizar(expediente);

                    bool esNuevo = Request.QueryString["nuevo"] == "true";
                    if (esNuevo)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        MostrarMensaje("Expediente actualizado exitosamente", true);
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al guardar el expediente: " + ex.Message, false);
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Expedientes.aspx");
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