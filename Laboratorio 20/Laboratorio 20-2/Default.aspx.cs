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

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la dimensión N
                int n = Convert.ToInt32(txtDimension.Text);

                // Validar que N sea mayor a 0
                if (n <= 0)
                {
                    litMatriz.Text = "<p style='color:red; text-align:center;'>Por favor ingrese un número mayor a 0.</p>";
                    return;
                }

                // Validar que N no sea muy grande
                if (n > 20)
                {
                    litMatriz.Text = "<p style='color:red; text-align:center;'>Por favor ingrese un número menor o igual a 20.</p>";
                    return;
                }

                // Generar la tabla HTML con la matriz
                StringBuilder tabla = new StringBuilder();
                tabla.Append("<table>");

                for (int i = 0; i < n; i++)
                {
                    tabla.Append("<tr>");

                    for (int j = 0; j < n; j++)
                    {
                        // Determinar el valor de la celda
                        int valor;
                        string cssClass = "";

                        // Diagonal: posiciones donde i == j
                        if (i == j)
                        {
                            valor = 1;
                            cssClass = "diagonal numero-uno";
                        }
                        else
                        {
                            valor = 0;
                            cssClass = "numero-cero";
                        }

                        tabla.Append($"<td class='{cssClass}'>{valor}</td>");
                    }

                    tabla.Append("</tr>");
                }

                tabla.Append("</table>");

                // Mostrar la tabla
                litMatriz.Text = tabla.ToString();
            }
            catch (Exception)
            {
                litMatriz.Text = "<p style='color:red; text-align:center;'>Por favor ingrese un número válido.</p>";
            }
        }
    }
}