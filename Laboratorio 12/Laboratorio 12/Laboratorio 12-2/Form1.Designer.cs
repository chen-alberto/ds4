namespace Laboratorio_12_2
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
            this.lbl_NP = new System.Windows.Forms.Label();
            this.lbl_n1 = new System.Windows.Forms.Label();
            this.lbl_N2 = new System.Windows.Forms.Label();
            this.lbl_N3 = new System.Windows.Forms.Label();
            this.lbl_NPT = new System.Windows.Forms.Label();
            this.btn_P = new System.Windows.Forms.Button();
            this.btn_R = new System.Windows.Forms.Button();
            this.btn_S = new System.Windows.Forms.Button();
            this.txt_n1 = new System.Windows.Forms.TextBox();
            this.txt_n2 = new System.Windows.Forms.TextBox();
            this.txt_n3 = new System.Windows.Forms.TextBox();
            this.txt_n4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_NP
            // 
            this.lbl_NP.AutoSize = true;
            this.lbl_NP.Location = new System.Drawing.Point(392, 44);
            this.lbl_NP.Name = "lbl_NP";
            this.lbl_NP.Size = new System.Drawing.Size(98, 16);
            this.lbl_NP.TabIndex = 0;
            this.lbl_NP.Text = "Nota Promedio";
            this.lbl_NP.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_n1
            // 
            this.lbl_n1.AutoSize = true;
            this.lbl_n1.Location = new System.Drawing.Point(96, 122);
            this.lbl_n1.Name = "lbl_n1";
            this.lbl_n1.Size = new System.Drawing.Size(76, 16);
            this.lbl_n1.TabIndex = 1;
            this.lbl_n1.Text = "NOTA no 1.";
            this.lbl_n1.Click += new System.EventHandler(this.lbl_n1_Click);
            // 
            // lbl_N2
            // 
            this.lbl_N2.AutoSize = true;
            this.lbl_N2.Location = new System.Drawing.Point(99, 179);
            this.lbl_N2.Name = "lbl_N2";
            this.lbl_N2.Size = new System.Drawing.Size(73, 16);
            this.lbl_N2.TabIndex = 2;
            this.lbl_N2.Text = "NOTA no2.";
            // 
            // lbl_N3
            // 
            this.lbl_N3.AutoSize = true;
            this.lbl_N3.Location = new System.Drawing.Point(102, 235);
            this.lbl_N3.Name = "lbl_N3";
            this.lbl_N3.Size = new System.Drawing.Size(76, 16);
            this.lbl_N3.TabIndex = 3;
            this.lbl_N3.Text = "NOTA no 3.";
            // 
            // lbl_NPT
            // 
            this.lbl_NPT.AutoSize = true;
            this.lbl_NPT.Location = new System.Drawing.Point(102, 371);
            this.lbl_NPT.Name = "lbl_NPT";
            this.lbl_NPT.Size = new System.Drawing.Size(98, 16);
            this.lbl_NPT.TabIndex = 4;
            this.lbl_NPT.Text = "Nota Promedio";
            // 
            // btn_P
            // 
            this.btn_P.Location = new System.Drawing.Point(159, 300);
            this.btn_P.Name = "btn_P";
            this.btn_P.Size = new System.Drawing.Size(93, 23);
            this.btn_P.TabIndex = 5;
            this.btn_P.Text = "Promedio";
            this.btn_P.UseVisualStyleBackColor = true;
            this.btn_P.Click += new System.EventHandler(this.btn_P_Click);
            // 
            // btn_R
            // 
            this.btn_R.Location = new System.Drawing.Point(258, 300);
            this.btn_R.Name = "btn_R";
            this.btn_R.Size = new System.Drawing.Size(104, 23);
            this.btn_R.TabIndex = 6;
            this.btn_R.Text = "Reset";
            this.btn_R.UseVisualStyleBackColor = true;
            this.btn_R.Click += new System.EventHandler(this.btn_R_Click);
            // 
            // btn_S
            // 
            this.btn_S.Location = new System.Drawing.Point(368, 300);
            this.btn_S.Name = "btn_S";
            this.btn_S.Size = new System.Drawing.Size(122, 23);
            this.btn_S.TabIndex = 7;
            this.btn_S.Text = "Salir";
            this.btn_S.UseVisualStyleBackColor = true;
            this.btn_S.Click += new System.EventHandler(this.btn_S_Click);
            // 
            // txt_n1
            // 
            this.txt_n1.Location = new System.Drawing.Point(258, 122);
            this.txt_n1.Name = "txt_n1";
            this.txt_n1.Size = new System.Drawing.Size(232, 22);
            this.txt_n1.TabIndex = 8;
            // 
            // txt_n2
            // 
            this.txt_n2.Location = new System.Drawing.Point(258, 172);
            this.txt_n2.Name = "txt_n2";
            this.txt_n2.Size = new System.Drawing.Size(232, 22);
            this.txt_n2.TabIndex = 9;
            // 
            // txt_n3
            // 
            this.txt_n3.Location = new System.Drawing.Point(258, 235);
            this.txt_n3.Name = "txt_n3";
            this.txt_n3.Size = new System.Drawing.Size(232, 22);
            this.txt_n3.TabIndex = 10;
            // 
            // txt_n4
            // 
            this.txt_n4.Location = new System.Drawing.Point(258, 371);
            this.txt_n4.Name = "txt_n4";
            this.txt_n4.Size = new System.Drawing.Size(232, 22);
            this.txt_n4.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_n4);
            this.Controls.Add(this.txt_n3);
            this.Controls.Add(this.txt_n2);
            this.Controls.Add(this.txt_n1);
            this.Controls.Add(this.btn_S);
            this.Controls.Add(this.btn_R);
            this.Controls.Add(this.btn_P);
            this.Controls.Add(this.lbl_NPT);
            this.Controls.Add(this.lbl_N3);
            this.Controls.Add(this.lbl_N2);
            this.Controls.Add(this.lbl_n1);
            this.Controls.Add(this.lbl_NP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_NP;
        private System.Windows.Forms.Label lbl_n1;
        private System.Windows.Forms.Label lbl_N2;
        private System.Windows.Forms.Label lbl_N3;
        private System.Windows.Forms.Label lbl_NPT;
        private System.Windows.Forms.Button btn_P;
        private System.Windows.Forms.Button btn_R;
        private System.Windows.Forms.Button btn_S;
        private System.Windows.Forms.TextBox txt_n1;
        private System.Windows.Forms.TextBox txt_n2;
        private System.Windows.Forms.TextBox txt_n3;
        private System.Windows.Forms.TextBox txt_n4;
    }
}

