namespace TLMEGraficos
{
    partial class RegistrarPerfil
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.chkInfantil = new System.Windows.Forms.CheckBox();
            this.lblConfirmarPin = new System.Windows.Forms.Label();
            this.txtConfirmarPin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(163, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar un perfil";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alias";
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(229, 149);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(246, 20);
            this.txtAlias.TabIndex = 0;
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(167, 190);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(22, 13);
            this.lblPin.TabIndex = 2;
            this.lblPin.Text = "Pin";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(229, 187);
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '*';
            this.txtPin.Size = new System.Drawing.Size(246, 20);
            this.txtPin.TabIndex = 1;
            // 
            // chkInfantil
            // 
            this.chkInfantil.AutoSize = true;
            this.chkInfantil.Location = new System.Drawing.Point(229, 324);
            this.chkInfantil.Name = "chkInfantil";
            this.chkInfantil.Size = new System.Drawing.Size(57, 17);
            this.chkInfantil.TabIndex = 3;
            this.chkInfantil.Text = "Infantil";
            this.chkInfantil.UseVisualStyleBackColor = true;
            this.chkInfantil.CheckedChanged += new System.EventHandler(this.chkInfantil_CheckedChanged);
            // 
            // lblConfirmarPin
            // 
            this.lblConfirmarPin.AutoSize = true;
            this.lblConfirmarPin.Location = new System.Drawing.Point(120, 234);
            this.lblConfirmarPin.Name = "lblConfirmarPin";
            this.lblConfirmarPin.Size = new System.Drawing.Size(69, 13);
            this.lblConfirmarPin.TabIndex = 2;
            this.lblConfirmarPin.Text = "Confirmar Pin";
            // 
            // txtConfirmarPin
            // 
            this.txtConfirmarPin.Location = new System.Drawing.Point(229, 231);
            this.txtConfirmarPin.Name = "txtConfirmarPin";
            this.txtConfirmarPin.PasswordChar = '*';
            this.txtConfirmarPin.Size = new System.Drawing.Size(246, 20);
            this.txtConfirmarPin.TabIndex = 2;
            // 
            // RegistrarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkInfantil);
            this.Controls.Add(this.txtConfirmarPin);
            this.Controls.Add(this.lblConfirmarPin);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarPerfil";
            this.Size = new System.Drawing.Size(631, 431);
            this.Load += new System.EventHandler(this.RegistrarPerfil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.CheckBox chkInfantil;
        private System.Windows.Forms.Label lblConfirmarPin;
        private System.Windows.Forms.TextBox txtConfirmarPin;
    }
}
