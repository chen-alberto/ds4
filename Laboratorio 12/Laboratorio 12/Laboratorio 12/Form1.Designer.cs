namespace Laboratorio_12
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblVel = new System.Windows.Forms.Label();
            this.lblTim = new System.Windows.Forms.Label();
            this.lblTotDis = new System.Windows.Forms.Label();
            this.btnCal = new System.Windows.Forms.Button();
            this.btnRes = new System.Windows.Forms.Button();
            this.btnSal = new System.Windows.Forms.Button();
            this.txt_Vel = new System.Windows.Forms.TextBox();
            this.txt_Tim = new System.Windows.Forms.TextBox();
            this.txt_TotDis = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculadora de distancia";
            // 
            // lblVel
            // 
            this.lblVel.AutoSize = true;
            this.lblVel.Location = new System.Drawing.Point(96, 120);
            this.lblVel.Name = "lblVel";
            this.lblVel.Size = new System.Drawing.Size(69, 16);
            this.lblVel.TabIndex = 1;
            this.lblVel.Text = "Velocidad";
            this.lblVel.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Location = new System.Drawing.Point(96, 194);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(54, 16);
            this.lblTim.TabIndex = 2;
            this.lblTim.Text = "Tiempo";
            // 
            // lblTotDis
            // 
            this.lblTotDis.AutoSize = true;
            this.lblTotDis.Location = new System.Drawing.Point(99, 327);
            this.lblTotDis.Name = "lblTotDis";
            this.lblTotDis.Size = new System.Drawing.Size(95, 16);
            this.lblTotDis.TabIndex = 3;
            this.lblTotDis.Text = "Total distancia";
            // 
            // btnCal
            // 
            this.btnCal.Location = new System.Drawing.Point(138, 256);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(75, 23);
            this.btnCal.TabIndex = 4;
            this.btnCal.Text = "Calcular";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // btnRes
            // 
            this.btnRes.Location = new System.Drawing.Point(256, 256);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(75, 23);
            this.btnRes.TabIndex = 5;
            this.btnRes.Text = "Reset";
            this.btnRes.UseVisualStyleBackColor = true;
            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
            // 
            // btnSal
            // 
            this.btnSal.Location = new System.Drawing.Point(381, 256);
            this.btnSal.Name = "btnSal";
            this.btnSal.Size = new System.Drawing.Size(75, 23);
            this.btnSal.TabIndex = 6;
            this.btnSal.Text = "Salir";
            this.btnSal.UseVisualStyleBackColor = true;
            this.btnSal.Click += new System.EventHandler(this.btnSal_Click);
            // 
            // txt_Vel
            // 
            this.txt_Vel.Location = new System.Drawing.Point(233, 113);
            this.txt_Vel.Name = "txt_Vel";
            this.txt_Vel.Size = new System.Drawing.Size(100, 22);
            this.txt_Vel.TabIndex = 7;
            // 
            // txt_Tim
            // 
            this.txt_Tim.Location = new System.Drawing.Point(233, 194);
            this.txt_Tim.Name = "txt_Tim";
            this.txt_Tim.Size = new System.Drawing.Size(100, 22);
            this.txt_Tim.TabIndex = 8;
            // 
            // txt_TotDis
            // 
            this.txt_TotDis.Location = new System.Drawing.Point(233, 321);
            this.txt_TotDis.Name = "txt_TotDis";
            this.txt_TotDis.Size = new System.Drawing.Size(100, 22);
            this.txt_TotDis.TabIndex = 9;
            this.txt_TotDis.TextChanged += new System.EventHandler(this.txt_TotDis_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_TotDis);
            this.Controls.Add(this.txt_Tim);
            this.Controls.Add(this.txt_Vel);
            this.Controls.Add(this.btnSal);
            this.Controls.Add(this.btnRes);
            this.Controls.Add(this.btnCal);
            this.Controls.Add(this.lblTotDis);
            this.Controls.Add(this.lblTim);
            this.Controls.Add(this.lblVel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVel;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.Label lblTotDis;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.Button btnRes;
        private System.Windows.Forms.Button btnSal;
        private System.Windows.Forms.TextBox txt_Vel;
        private System.Windows.Forms.TextBox txt_Tim;
        private System.Windows.Forms.TextBox txt_TotDis;
    }
}

