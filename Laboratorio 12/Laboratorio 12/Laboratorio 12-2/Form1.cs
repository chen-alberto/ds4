using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_12_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_P_Click(object sender, EventArgs e)
        {
            Promedio promedio = new Promedio();
            double resultado = promedio.calcularPromedio(txt_n1.Text, txt_n2.Text, txt_n3.Text);
            txt_n4.Text = resultado.ToString();
        }

        private void lbl_n1_Click(object sender, EventArgs e)
        {

        }

        private void btn_R_Click(object sender, EventArgs e)
        {
            txt_n1.Text = "";
            txt_n2.Text = "";
            txt_n3.Text = "";
            txt_n4.Text = "";
        }

        private void btn_S_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
