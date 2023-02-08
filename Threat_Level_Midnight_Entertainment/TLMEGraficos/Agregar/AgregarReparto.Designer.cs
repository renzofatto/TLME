namespace TLMEGraficos
{
    partial class AgregarReparto
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnImagen = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.path = new System.Windows.Forms.Label();
            this.radioBtnDirector = new System.Windows.Forms.RadioButton();
            this.radioBtnActor = new System.Windows.Forms.RadioButton();
            this.radioBtnAmbos = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(357, 161);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Fecha de Nacimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nombre";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(267, 324);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(163, 54);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(283, 42);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "Nuevo Reparto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(115, 150);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnImagen
            // 
            this.btnImagen.Location = new System.Drawing.Point(130, 258);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(75, 23);
            this.btnImagen.TabIndex = 16;
            this.btnImagen.Text = "Imagen";
            this.btnImagen.UseVisualStyleBackColor = true;
            this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(357, 198);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 18;
            this.dateTimePicker.Value = new System.DateTime(2022, 11, 12, 0, 0, 0, 0);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(540, 269);
            this.path.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(0, 13);
            this.path.TabIndex = 8;
            this.path.Visible = false;
            // 
            // radioBtnDirector
            // 
            this.radioBtnDirector.AutoSize = true;
            this.radioBtnDirector.Location = new System.Drawing.Point(357, 261);
            this.radioBtnDirector.Name = "radioBtnDirector";
            this.radioBtnDirector.Size = new System.Drawing.Size(62, 17);
            this.radioBtnDirector.TabIndex = 19;
            this.radioBtnDirector.TabStop = true;
            this.radioBtnDirector.Text = "Director";
            this.radioBtnDirector.UseVisualStyleBackColor = true;
            // 
            // radioBtnActor
            // 
            this.radioBtnActor.AutoSize = true;
            this.radioBtnActor.Location = new System.Drawing.Point(435, 261);
            this.radioBtnActor.Name = "radioBtnActor";
            this.radioBtnActor.Size = new System.Drawing.Size(50, 17);
            this.radioBtnActor.TabIndex = 20;
            this.radioBtnActor.TabStop = true;
            this.radioBtnActor.Text = "Actor";
            this.radioBtnActor.UseVisualStyleBackColor = true;
            // 
            // radioBtnAmbos
            // 
            this.radioBtnAmbos.AutoSize = true;
            this.radioBtnAmbos.Location = new System.Drawing.Point(500, 261);
            this.radioBtnAmbos.Name = "radioBtnAmbos";
            this.radioBtnAmbos.Size = new System.Drawing.Size(57, 17);
            this.radioBtnAmbos.TabIndex = 21;
            this.radioBtnAmbos.TabStop = true;
            this.radioBtnAmbos.Text = "Ambos";
            this.radioBtnAmbos.UseVisualStyleBackColor = true;
            // 
            // AgregarReparto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioBtnAmbos);
            this.Controls.Add(this.radioBtnActor);
            this.Controls.Add(this.radioBtnDirector);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnImagen);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "AgregarReparto";
            this.Size = new System.Drawing.Size(631, 431);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.RadioButton radioBtnDirector;
        private System.Windows.Forms.RadioButton radioBtnActor;
        private System.Windows.Forms.RadioButton radioBtnAmbos;
    }
}
