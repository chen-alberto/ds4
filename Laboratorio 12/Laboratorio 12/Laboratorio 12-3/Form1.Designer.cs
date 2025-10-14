namespace Laboratorio_12_3
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
            this.lbl_B = new System.Windows.Forms.Label();
            this.lbl_C = new System.Windows.Forms.Label();
            this.lbl_cs = new System.Windows.Forms.Label();
            this.lbl_AT = new System.Windows.Forms.Label();
            this.btn_SMP = new System.Windows.Forms.Button();
            this.btn_area = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.txt_2 = new System.Windows.Forms.TextBox();
            this.txt_3 = new System.Windows.Forms.TextBox();
            this.txt_4 = new System.Windows.Forms.TextBox();
            this.txt_5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresa la longitud del lado A";
            // 
            // lbl_B
            // 
            this.lbl_B.AutoSize = true;
            this.lbl_B.Location = new System.Drawing.Point(73, 123);
            this.lbl_B.Name = "lbl_B";
            this.lbl_B.Size = new System.Drawing.Size(180, 16);
            this.lbl_B.TabIndex = 1;
            this.lbl_B.Text = "Ingresa la longitud del lado B";
            // 
            // lbl_C
            // 
            this.lbl_C.AutoSize = true;
            this.lbl_C.Location = new System.Drawing.Point(73, 170);
            this.lbl_C.Name = "lbl_C";
            this.lbl_C.Size = new System.Drawing.Size(180, 16);
            this.lbl_C.TabIndex = 2;
            this.lbl_C.Text = "Ingrese la longitud del lado C";
            // 
            // lbl_cs
            // 
            this.lbl_cs.AutoSize = true;
            this.lbl_cs.Location = new System.Drawing.Point(106, 281);
            this.lbl_cs.Name = "lbl_cs";
            this.lbl_cs.Size = new System.Drawing.Size(147, 16);
            this.lbl_cs.TabIndex = 3;
            this.lbl_cs.Text = "Calcular Semiperimetro";
            // 
            // lbl_AT
            // 
            this.lbl_AT.AutoSize = true;
            this.lbl_AT.Location = new System.Drawing.Point(135, 335);
            this.lbl_AT.Name = "lbl_AT";
            this.lbl_AT.Size = new System.Drawing.Size(118, 16);
            this.lbl_AT.TabIndex = 4;
            this.lbl_AT.Text = "Area del Triangulo";
            // 
            // btn_SMP
            // 
            this.btn_SMP.Location = new System.Drawing.Point(109, 222);
            this.btn_SMP.Name = "btn_SMP";
            this.btn_SMP.Size = new System.Drawing.Size(128, 23);
            this.btn_SMP.TabIndex = 5;
            this.btn_SMP.Text = "Semiperimetro";
            this.btn_SMP.UseVisualStyleBackColor = true;
            this.btn_SMP.Click += new System.EventHandler(this.btn_SMP_Click);
            // 
            // btn_area
            // 
            this.btn_area.Location = new System.Drawing.Point(273, 222);
            this.btn_area.Name = "btn_area";
            this.btn_area.Size = new System.Drawing.Size(75, 23);
            this.btn_area.TabIndex = 6;
            this.btn_area.Text = "Area";
            this.btn_area.UseVisualStyleBackColor = true;
            this.btn_area.Click += new System.EventHandler(this.btn_area_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(387, 222);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 7;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(494, 222);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 23);
            this.btn_salir.TabIndex = 8;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // txt_1
            // 
            this.txt_1.Location = new System.Drawing.Point(273, 72);
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(163, 22);
            this.txt_1.TabIndex = 9;
            // 
            // txt_2
            // 
            this.txt_2.Location = new System.Drawing.Point(273, 123);
            this.txt_2.Name = "txt_2";
            this.txt_2.Size = new System.Drawing.Size(163, 22);
            this.txt_2.TabIndex = 10;
            // 
            // txt_3
            // 
            this.txt_3.Location = new System.Drawing.Point(273, 167);
            this.txt_3.Name = "txt_3";
            this.txt_3.Size = new System.Drawing.Size(163, 22);
            this.txt_3.TabIndex = 11;
            // 
            // txt_4
            // 
            this.txt_4.Location = new System.Drawing.Point(273, 275);
            this.txt_4.Name = "txt_4";
            this.txt_4.Size = new System.Drawing.Size(163, 22);
            this.txt_4.TabIndex = 12;
            this.txt_4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txt_5
            // 
            this.txt_5.Location = new System.Drawing.Point(273, 329);
            this.txt_5.Name = "txt_5";
            this.txt_5.Size = new System.Drawing.Size(163, 22);
            this.txt_5.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_5);
            this.Controls.Add(this.txt_4);
            this.Controls.Add(this.txt_3);
            this.Controls.Add(this.txt_2);
            this.Controls.Add(this.txt_1);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_area);
            this.Controls.Add(this.btn_SMP);
            this.Controls.Add(this.lbl_AT);
            this.Controls.Add(this.lbl_cs);
            this.Controls.Add(this.lbl_C);
            this.Controls.Add(this.lbl_B);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_B;
        private System.Windows.Forms.Label lbl_C;
        private System.Windows.Forms.Label lbl_cs;
        private System.Windows.Forms.Label lbl_AT;
        private System.Windows.Forms.Button btn_SMP;
        private System.Windows.Forms.Button btn_area;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TextBox txt_1;
        private System.Windows.Forms.TextBox txt_2;
        private System.Windows.Forms.TextBox txt_3;
        private System.Windows.Forms.TextBox txt_4;
        private System.Windows.Forms.TextBox txt_5;
    }
}

