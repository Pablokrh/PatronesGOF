
namespace TemplateWF
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_Clientes = new System.Windows.Forms.ComboBox();
            this.cb_Creditos = new System.Windows.Forms.ComboBox();
            this.Lbl_Clientes = new System.Windows.Forms.Label();
            this.lbl_Creditos = new System.Windows.Forms.Label();
            this.btn_Solicitar = new System.Windows.Forms.Button();
            this.txt_Display = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cb_Clientes
            // 
            this.cb_Clientes.FormattingEnabled = true;
            this.cb_Clientes.Location = new System.Drawing.Point(104, 42);
            this.cb_Clientes.Name = "cb_Clientes";
            this.cb_Clientes.Size = new System.Drawing.Size(121, 21);
            this.cb_Clientes.TabIndex = 1;
            // 
            // cb_Creditos
            // 
            this.cb_Creditos.FormattingEnabled = true;
            this.cb_Creditos.Location = new System.Drawing.Point(104, 123);
            this.cb_Creditos.Name = "cb_Creditos";
            this.cb_Creditos.Size = new System.Drawing.Size(121, 21);
            this.cb_Creditos.TabIndex = 2;
            // 
            // Lbl_Clientes
            // 
            this.Lbl_Clientes.AutoSize = true;
            this.Lbl_Clientes.Location = new System.Drawing.Point(137, 26);
            this.Lbl_Clientes.Name = "Lbl_Clientes";
            this.Lbl_Clientes.Size = new System.Drawing.Size(44, 13);
            this.Lbl_Clientes.TabIndex = 3;
            this.Lbl_Clientes.Text = "Clientes";
            // 
            // lbl_Creditos
            // 
            this.lbl_Creditos.AutoSize = true;
            this.lbl_Creditos.Location = new System.Drawing.Point(117, 107);
            this.lbl_Creditos.Name = "lbl_Creditos";
            this.lbl_Creditos.Size = new System.Drawing.Size(102, 13);
            this.lbl_Creditos.TabIndex = 4;
            this.lbl_Creditos.Text = "Créditos Disponibles";
            // 
            // btn_Solicitar
            // 
            this.btn_Solicitar.Location = new System.Drawing.Point(120, 180);
            this.btn_Solicitar.Name = "btn_Solicitar";
            this.btn_Solicitar.Size = new System.Drawing.Size(75, 23);
            this.btn_Solicitar.TabIndex = 5;
            this.btn_Solicitar.Text = "Solicitar";
            this.btn_Solicitar.UseVisualStyleBackColor = true;
            this.btn_Solicitar.Click += new System.EventHandler(this.btn_Solicitar_Click);
            // 
            // txt_Display
            // 
            this.txt_Display.Location = new System.Drawing.Point(21, 209);
            this.txt_Display.Multiline = true;
            this.txt_Display.Name = "txt_Display";
            this.txt_Display.Size = new System.Drawing.Size(273, 126);
            this.txt_Display.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 370);
            this.Controls.Add(this.txt_Display);
            this.Controls.Add(this.btn_Solicitar);
            this.Controls.Add(this.lbl_Creditos);
            this.Controls.Add(this.Lbl_Clientes);
            this.Controls.Add(this.cb_Creditos);
            this.Controls.Add(this.cb_Clientes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Clientes;
        private System.Windows.Forms.ComboBox cb_Creditos;
        private System.Windows.Forms.Label Lbl_Clientes;
        private System.Windows.Forms.Label lbl_Creditos;
        private System.Windows.Forms.Button btn_Solicitar;
        private System.Windows.Forms.TextBox txt_Display;
    }
}

