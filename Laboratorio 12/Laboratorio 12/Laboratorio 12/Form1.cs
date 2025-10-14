using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            CalcularDistancia calc = new CalcularDistancia();

            double resultado = calc.Calcular(txt_Tim.Text, txt_Vel.Text);
            txt_TotDis.Text = resultado.ToString();
        }


        public void txt_TotDis_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            txt_Tim.Text = "";
            txt_Vel.Text = "";
            txt_TotDis.Text = "";
        }

        private void btnSal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
