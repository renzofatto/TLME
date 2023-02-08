namespace TLMEGraficos
{
    partial class MostrarPelicula
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picBoxImagen = new System.Windows.Forms.PictureBox();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.comboCalificacion = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblVisualizar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGeneroPrincipal = new System.Windows.Forms.Label();
            this.btnAgregarDirector = new System.Windows.Forms.Button();
            this.btnAgregarActor = new System.Windows.Forms.Button();
            this.btnEliminarActor = new System.Windows.Forms.Button();
            this.btnEliminarDirector = new System.Windows.Forms.Button();
            this.lblMostrarGenerosSecundarios = new System.Windows.Forms.Label();
            this.lblGenerosSecundarios = new System.Windows.Forms.Label();
            this.lblTituloDescripcion = new System.Windows.Forms.Label();
            this.lblDirectores = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lBoxReparto = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(83, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(115, 42);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Titulo";
            // 
            // picBoxImagen
            // 
            this.picBoxImagen.Location = new System.Drawing.Point(90, 155);
            this.picBoxImagen.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxImagen.Name = "picBoxImagen";
            this.picBoxImagen.Size = new System.Drawing.Size(141, 168);
            this.picBoxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImagen.TabIndex = 10;
            this.picBoxImagen.TabStop = false;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(156, 328);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 1;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnCalificar
            // 
            this.btnCalificar.Location = new System.Drawing.Point(472, 328);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(75, 23);
            this.btnCalificar.TabIndex = 3;
            this.btnCalificar.Text = "Calificar";
            this.btnCalificar.UseVisualStyleBackColor = true;
            this.btnCalificar.Click += new System.EventHandler(this.btnCalificar_Click);
            // 
            // comboCalificacion
            // 
            this.comboCalificacion.FormattingEnabled = true;
            this.comboCalificacion.Items.AddRange(new object[] {
            "Negativa",
            "Positiva",
            "Muy Positiva"});
            this.comboCalificacion.Location = new System.Drawing.Point(275, 330);
            this.comboCalificacion.Name = "comboCalificacion";
            this.comboCalificacion.Size = new System.Drawing.Size(180, 21);
            this.comboCalificacion.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(272, 155);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(163, 168);
            this.lblDescripcion.TabIndex = 14;
            this.lblDescripcion.Text = "Sin descripcion";
            // 
            // lblVisualizar
            // 
            this.lblVisualizar.AutoSize = true;
            this.lblVisualizar.Location = new System.Drawing.Point(87, 333);
            this.lblVisualizar.Name = "lblVisualizar";
            this.lblVisualizar.Size = new System.Drawing.Size(68, 13);
            this.lblVisualizar.TabIndex = 15;
            this.lblVisualizar.Text = "Sin visualizar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Genero principal:";
            // 
            // lblGeneroPrincipal
            // 
            this.lblGeneroPrincipal.AutoSize = true;
            this.lblGeneroPrincipal.Location = new System.Drawing.Point(178, 96);
            this.lblGeneroPrincipal.Name = "lblGeneroPrincipal";
            this.lblGeneroPrincipal.Size = new System.Drawing.Size(35, 13);
            this.lblGeneroPrincipal.TabIndex = 16;
            this.lblGeneroPrincipal.Text = "label2";
            // 
            // btnAgregarDirector
            // 
            this.btnAgregarDirector.Location = new System.Drawing.Point(62, 374);
            this.btnAgregarDirector.Name = "btnAgregarDirector";
            this.btnAgregarDirector.Size = new System.Drawing.Size(108, 23);
            this.btnAgregarDirector.TabIndex = 17;
            this.btnAgregarDirector.Text = "Agregar Director";
            this.btnAgregarDirector.UseVisualStyleBackColor = true;
            this.btnAgregarDirector.Click += new System.EventHandler(this.btnAgregarDirector_Click);
            // 
            // btnAgregarActor
            // 
            this.btnAgregarActor.Location = new System.Drawing.Point(196, 374);
            this.btnAgregarActor.Name = "btnAgregarActor";
            this.btnAgregarActor.Size = new System.Drawing.Size(108, 23);
            this.btnAgregarActor.TabIndex = 18;
            this.btnAgregarActor.Text = "Agregar Actor";
            this.btnAgregarActor.UseVisualStyleBackColor = true;
            this.btnAgregarActor.Click += new System.EventHandler(this.btnAgregarActor_Click);
            // 
            // btnEliminarActor
            // 
            this.btnEliminarActor.Location = new System.Drawing.Point(461, 374);
            this.btnEliminarActor.Name = "btnEliminarActor";
            this.btnEliminarActor.Size = new System.Drawing.Size(108, 23);
            this.btnEliminarActor.TabIndex = 20;
            this.btnEliminarActor.Text = "Eliminar Actor";
            this.btnEliminarActor.UseVisualStyleBackColor = true;
            this.btnEliminarActor.Click += new System.EventHandler(this.btnEliminarActor_Click);
            // 
            // btnEliminarDirector
            // 
            this.btnEliminarDirector.Location = new System.Drawing.Point(327, 374);
            this.btnEliminarDirector.Name = "btnEliminarDirector";
            this.btnEliminarDirector.Size = new System.Drawing.Size(108, 23);
            this.btnEliminarDirector.TabIndex = 19;
            this.btnEliminarDirector.Text = "Eliminar Director";
            this.btnEliminarDirector.UseVisualStyleBackColor = true;
            this.btnEliminarDirector.Click += new System.EventHandler(this.btnEliminarDirector_Click);
            // 
            // lblMostrarGenerosSecundarios
            // 
            this.lblMostrarGenerosSecundarios.AutoSize = true;
            this.lblMostrarGenerosSecundarios.Location = new System.Drawing.Point(201, 120);
            this.lblMostrarGenerosSecundarios.Name = "lblMostrarGenerosSecundarios";
            this.lblMostrarGenerosSecundarios.Size = new System.Drawing.Size(35, 13);
            this.lblMostrarGenerosSecundarios.TabIndex = 22;
            this.lblMostrarGenerosSecundarios.Text = "label2";
            // 
            // lblGenerosSecundarios
            // 
            this.lblGenerosSecundarios.AutoSize = true;
            this.lblGenerosSecundarios.Location = new System.Drawing.Point(85, 120);
            this.lblGenerosSecundarios.Name = "lblGenerosSecundarios";
            this.lblGenerosSecundarios.Size = new System.Drawing.Size(110, 13);
            this.lblGenerosSecundarios.TabIndex = 21;
            this.lblGenerosSecundarios.Text = "Generos secundarios:";
            // 
            // lblTituloDescripcion
            // 
            this.lblTituloDescripcion.AutoSize = true;
            this.lblTituloDescripcion.Location = new System.Drawing.Point(272, 141);
            this.lblTituloDescripcion.Name = "lblTituloDescripcion";
            this.lblTituloDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblTituloDescripcion.TabIndex = 23;
            this.lblTituloDescripcion.Text = "Descripcion:";
            // 
            // lblDirectores
            // 
            this.lblDirectores.AutoSize = true;
            this.lblDirectores.Location = new System.Drawing.Point(149, 73);
            this.lblDirectores.Name = "lblDirectores";
            this.lblDirectores.Size = new System.Drawing.Size(65, 13);
            this.lblDirectores.TabIndex = 25;
            this.lblDirectores.Text = "lblDirectores";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Directores:";
            // 
            // lBoxReparto
            // 
            this.lBoxReparto.FormattingEnabled = true;
            this.lBoxReparto.Location = new System.Drawing.Point(450, 157);
            this.lBoxReparto.Name = "lBoxReparto";
            this.lBoxReparto.Size = new System.Drawing.Size(148, 147);
            this.lBoxReparto.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Reparto:";
            // 
            // MostrarPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lBoxReparto);
            this.Controls.Add(this.lblDirectores);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTituloDescripcion);
            this.Controls.Add(this.lblMostrarGenerosSecundarios);
            this.Controls.Add(this.lblGenerosSecundarios);
            this.Controls.Add(this.btnEliminarActor);
            this.Controls.Add(this.btnEliminarDirector);
            this.Controls.Add(this.btnAgregarActor);
            this.Controls.Add(this.btnAgregarDirector);
            this.Controls.Add(this.lblGeneroPrincipal);
            this.Controls.Add(this.lblVisualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.comboCalificacion);
            this.Controls.Add(this.btnCalificar);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.picBoxImagen);
            this.Controls.Add(this.lblTitulo);
            this.Name = "MostrarPelicula";
            this.Size = new System.Drawing.Size(631, 431);
            this.Load += new System.EventHandler(this.MostrarPelicula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picBoxImagen;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.ComboBox comboCalificacion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblVisualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGeneroPrincipal;
        private System.Windows.Forms.Button btnAgregarDirector;
        private System.Windows.Forms.Button btnAgregarActor;
        private System.Windows.Forms.Button btnEliminarActor;
        private System.Windows.Forms.Button btnEliminarDirector;
        private System.Windows.Forms.Label lblMostrarGenerosSecundarios;
        private System.Windows.Forms.Label lblGenerosSecundarios;
        private System.Windows.Forms.Label lblTituloDescripcion;
        private System.Windows.Forms.Label lblDirectores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lBoxReparto;
        private System.Windows.Forms.Label label2;
    }
}
