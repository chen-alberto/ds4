using System;
using System.Text;
using System.Web.UI;

namespace WebApplication
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Código que se ejecuta al cargar la página
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número ingresado
                int numero = Convert.ToInt32(txtNumero.Text);

                // Construir la tabla de multiplicar
                StringBuilder resultado = new StringBuilder();
                resultado.Append("<h3>Tabla del " + numero + "</h3>");

                for (int i = 1; i <= 25; i++)
                {
                    int multiplicacion = numero * i;
                    resultado.Append(numero + " x " + i + " = " + multiplicacion + "<br/>");
                }

                // Mostrar el resultado
                lblResultado.Text = resultado.ToString();
            }
            catch (Exception)
            {
                lblResultado.Text = "<span style='color:red;'>Por favor ingrese un número válido.</span>";
            }
        }
    }
}