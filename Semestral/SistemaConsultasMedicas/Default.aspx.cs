using System;

namespace SistemaConsultasMedicas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrarPaciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarPaciente.aspx");
        }

        protected void btnCrearConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearConsulta.aspx");
        }

        protected void btnConsultasPendientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultasPendientes.aspx");
        }

        protected void btnExpedientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Expedientes.aspx");
        }
    }
}