using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pARCIAL_2
{
    public partial class Form1 : Form
    {
        bool nuevo = true;
        string connectionString = @"Server=.\sqlexpress; Database=Conversion; Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conversion conversion = new Conversion();
            double monto = double.Parse(txtEntradaPeso.Text);
            double resultado = conversion.ConversionPesoEuro(monto);
            txtPesoSalidaEuro.Text = resultado.ToString("F2");

            Conversion conversionDolar = new Conversion();
            double montoDolar = double.Parse(txtEntradaPeso.Text);
            double resultadoDolar = conversionDolar.ConversionPesoDolar(montoDolar);
            txtPesoSalidaDolar.Text = resultadoDolar.ToString("F2");

            txtPesoSalidaPeso.Text = txtEntradaPeso.Text;

            txtBdPeso.Text = txtPesoSalidaPeso.Text;
            txtBdEuro.Text = txtPesoSalidaEuro.Text;
            txtBdDolar.Text = txtPesoSalidaDolar.Text;
        }

        private void btnEuro_Click(object sender, EventArgs e)
        {
            Conversion conversion = new Conversion();
            double monto = double.Parse(txtEntradaEuro.Text);
            double resultado = conversion.ConversionEuroDolar(monto);
            txtSalidaDolar.Text = resultado.ToString("F2");

            Conversion conversionPeso = new Conversion();
            double montoPeso = double.Parse(txtEntradaEuro.Text);
            double resultadoPeso = conversionPeso.ConversionEuroPeso(montoPeso);
            txtSalidaPeso.Text = resultadoPeso.ToString("F3");

            txtSalidaEuro.Text = txtEntradaEuro.Text;

            txtBdDolar.Text = txtSalidaDolar.Text;
            txtBdEuro.Text = txtSalidaEuro.Text;
            txtBdPeso.Text = txtSalidaPeso.Text;
        }

        private void txtEntradaEuro_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDolar_Click(object sender, EventArgs e)
        {
            Conversion conversion = new Conversion();
            double monto = double.Parse(txtEntradaDolar.Text);
            double resultado = conversion.ConversionDolarEuro(monto);
            txtDolarSalidaEuro.Text = resultado.ToString();

            txtDolarSalidaDolar.Text = txtEntradaDolar.Text;

            Conversion conversionPeso = new Conversion();
            double montoPeso = double.Parse(txtEntradaDolar.Text);
            double resultadoPeso = conversionPeso.ConversionDolarPeso(montoPeso);
            txtDolarSalidaPeso.Text = resultadoPeso.ToString("F3");

            txtBdDolar.Text = txtDolarSalidaDolar.Text;
            txtBdEuro.Text = txtDolarSalidaEuro.Text;
            txtBdPeso.Text = txtDolarSalidaPeso.Text;
        }

        private void txtEntradaDolar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDolarSalidaEuro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDolarSalidaDolar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalidaEuro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPesoSalidaEuro_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (nuevo)
            {
                string sql = "INSERT INTO RESULTADO (EURO, DOLAR, PESO)"
        + "VALUES ('" + txtBdEuro.Text + "', '" + txtBdDolar.Text + "', '" + txtBdPeso.Text + "')";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Registro ingresado correctamente !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }

                finally
                {
                    con.Close();
                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            {
                listBox1.Items.Clear();

                string connectionString = @"Server=.\SQLEXPRESS;Database=Conversion;TrustServerCertificate=true;Integrated Security=SSPI;";

                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");

                string query = "SELECT Peso,Dolar,Euro FROM [dbo].[RESULTADO]";

                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                listBox1.Items.Clear();

                while (lector.Read())
                {
                    string fila = $"Peso: {lector["Peso"]} | Dólar: {lector["Dolar"]} | Euro: {lector["Euro"]}";
                    listBox1.Items.Add(fila);
                }

                lector.Close();

                conexion.Close();
            }
        }
    }
}
