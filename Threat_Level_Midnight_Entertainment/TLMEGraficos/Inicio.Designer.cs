namespace TLMEGraficos
{
    partial class Inicio
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
            this.dgvPeliculas = new System.Windows.Forms.DataGridView();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.btnPeliculasVisualizadas = new System.Windows.Forms.Button();
            this.btnBusquedaAvanzada = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(156, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ventana principal";
            // 
            // dgvPeliculas
            // 
            this.dgvPeliculas.AllowUserToAddRows = false;
            this.dgvPeliculas.AllowUserToDeleteRows = false;
            this.dgvPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPeliculas.Location = new System.Drawing.Point(23, 102);
            this.dgvPeliculas.Name = "dgvPeliculas";
            this.dgvPeliculas.ReadOnly = true;
            this.dgvPeliculas.RowHeadersWidth = 82;
            this.dgvPeliculas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPeliculas.Size = new System.Drawing.Size(588, 275);
            this.dgvPeliculas.TabIndex = 1;
            this.dgvPeliculas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeliculas_CellContentClick);
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.Items.AddRange(new object[] {
            "Genero",
            "Patrocinadas",
            "Puntaje"});
            this.cmbOrdenar.Location = new System.Drawing.Point(507, 80);
            this.cmbOrdenar.Margin = new System.Windows.Forms.Padding(2);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(106, 21);
            this.cmbOrdenar.TabIndex = 2;
            this.cmbOrdenar.Text = "Ordenar";
            this.cmbOrdenar.SelectedIndexChanged += new System.EventHandler(this.Ordenar_SelectedIndexChanged);
            // 
            // btnPeliculasVisualizadas
            // 
            this.btnPeliculasVisualizadas.Location = new System.Drawing.Point(349, 388);
            this.btnPeliculasVisualizadas.Name = "btnPeliculasVisualizadas";
            this.btnPeliculasVisualizadas.Size = new System.Drawing.Size(195, 23);
            this.btnPeliculasVisualizadas.TabIndex = 3;
            this.btnPeliculasVisualizadas.Text = "Listado de peliculas visualizadas";
            this.btnPeliculasVisualizadas.UseVisualStyleBackColor = true;
            this.btnPeliculasVisualizadas.Click += new System.EventHandler(this.btnPeliculasVisualizadas_Click);
            // 
            // btnBusquedaAvanzada
            // 
            this.btnBusquedaAvanzada.Location = new System.Drawing.Point(135, 388);
            this.btnBusquedaAvanzada.Name = "btnBusquedaAvanzada";
            this.btnBusquedaAvanzada.Size = new System.Drawing.Size(129, 23);
            this.btnBusquedaAvanzada.TabIndex = 4;
            this.btnBusquedaAvanzada.Text = "Busqueda avanzada";
            this.btnBusquedaAvanzada.UseVisualStyleBackColor = true;
            this.btnBusquedaAvanzada.Click += new System.EventHandler(this.btnBusquedaAvanzada_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBusquedaAvanzada);
            this.Controls.Add(this.btnPeliculasVisualizadas);
            this.Controls.Add(this.cmbOrdenar);
            this.Controls.Add(this.dgvPeliculas);
            this.Controls.Add(this.label1);
            this.Name = "Inicio";
            this.Size = new System.Drawing.Size(631, 431);
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPeliculas;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Button btnPeliculasVisualizadas;
        private System.Windows.Forms.Button btnBusquedaAvanzada;
    }
}
