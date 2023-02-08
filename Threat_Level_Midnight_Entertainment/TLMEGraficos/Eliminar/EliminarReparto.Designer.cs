namespace TLMEGraficos
{
    partial class EliminarReparto
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbReparto = new System.Windows.Forms.ComboBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuevoNombre = new System.Windows.Forms.TextBox();
            this.dateFechaNacimientoNueva = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.radioBtnAmbos = new System.Windows.Forms.RadioButton();
            this.radioBtnActor = new System.Windows.Forms.RadioButton();
            this.radioBtnDirector = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Reparto:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(180, 339);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(152, 55);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(310, 42);
            this.lblTitulo.TabIndex = 21;
            this.lblTitulo.Text = "Eliminar Reparto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(428, 144);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // cmbReparto
            // 
            this.cmbReparto.FormattingEnabled = true;
            this.cmbReparto.Location = new System.Drawing.Point(154, 144);
            this.cmbReparto.Name = "cmbReparto";
            this.cmbReparto.Size = new System.Drawing.Size(196, 21);
            this.cmbReparto.TabIndex = 24;
            this.cmbReparto.SelectedIndexChanged += new System.EventHandler(this.cmbReparto_SelectedIndexChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(358, 339);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 25;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nombre:";
            // 
            // txtNuevoNombre
            // 
            this.txtNuevoNombre.Location = new System.Drawing.Point(154, 186);
            this.txtNuevoNombre.Name = "txtNuevoNombre";
            this.txtNuevoNombre.Size = new System.Drawing.Size(196, 20);
            this.txtNuevoNombre.TabIndex = 27;
            // 
            // dateFechaNacimientoNueva
            // 
            this.dateFechaNacimientoNueva.Location = new System.Drawing.Point(154, 226);
            this.dateFechaNacimientoNueva.Name = "dateFechaNacimientoNueva";
            this.dateFechaNacimientoNueva.Size = new System.Drawing.Size(196, 20);
            this.dateFechaNacimientoNueva.TabIndex = 29;
            this.dateFechaNacimientoNueva.Value = new System.DateTime(2022, 11, 12, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Fecha de Nacimiento:";
            // 
            // radioBtnAmbos
            // 
            this.radioBtnAmbos.AutoSize = true;
            this.radioBtnAmbos.Location = new System.Drawing.Point(293, 279);
            this.radioBtnAmbos.Name = "radioBtnAmbos";
            this.radioBtnAmbos.Size = new System.Drawing.Size(57, 17);
            this.radioBtnAmbos.TabIndex = 32;
            this.radioBtnAmbos.TabStop = true;
            this.radioBtnAmbos.Text = "Ambos";
            this.radioBtnAmbos.UseVisualStyleBackColor = true;
            // 
            // radioBtnActor
            // 
            this.radioBtnActor.AutoSize = true;
            this.radioBtnActor.Location = new System.Drawing.Point(226, 279);
            this.radioBtnActor.Name = "radioBtnActor";
            this.radioBtnActor.Size = new System.Drawing.Size(50, 17);
            this.radioBtnActor.TabIndex = 31;
            this.radioBtnActor.TabStop = true;
            this.radioBtnActor.Text = "Actor";
            this.radioBtnActor.UseVisualStyleBackColor = true;
            // 
            // radioBtnDirector
            // 
            this.radioBtnDirector.AutoSize = true;
            this.radioBtnDirector.Location = new System.Drawing.Point(154, 279);
            this.radioBtnDirector.Name = "radioBtnDirector";
            this.radioBtnDirector.Size = new System.Drawing.Size(62, 17);
            this.radioBtnDirector.TabIndex = 30;
            this.radioBtnDirector.TabStop = true;
            this.radioBtnDirector.Text = "Director";
            this.radioBtnDirector.UseVisualStyleBackColor = true;
            // 
            // EliminarReparto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioBtnAmbos);
            this.Controls.Add(this.radioBtnActor);
            this.Controls.Add(this.radioBtnDirector);
            this.Controls.Add(this.dateFechaNacimientoNueva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNuevoNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.cmbReparto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "EliminarReparto";
            this.Size = new System.Drawing.Size(631, 431);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbReparto;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNuevoNombre;
        private System.Windows.Forms.DateTimePicker dateFechaNacimientoNueva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioBtnAmbos;
        private System.Windows.Forms.RadioButton radioBtnActor;
        private System.Windows.Forms.RadioButton radioBtnDirector;
    }
}
