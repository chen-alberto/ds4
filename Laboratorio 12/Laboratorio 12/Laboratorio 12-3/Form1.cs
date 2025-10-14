using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_12_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_SMP_Click(object sender, EventArgs e)
        {
            Triangulo triangulo = new Triangulo();
            double resultado = triangulo.Semiperimetro(txt_1.Text, txt_2.Text, txt_3.Text);
            txt_4.Text = resultado.ToString();
        }

        private void btn_area_Click(object sender, EventArgs e)
        {
            Triangulo triangulo = new Triangulo();
            double resultado = triangulo.Area(txt_1.Text, txt_2.Text, txt_3.Text);
            txt_5.Text = resultado.ToString();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_1.Text = "";
            txt_2.Text = "";
            txt_3.Text = "";
            txt_4.Text = "";
            txt_5.Text = "";
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
