namespace TLMEGraficos
{
    partial class PeliculasVistas
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
            this.lBoxPeliculas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(122, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Peliculas visualizadas";
            // 
            // lBoxPeliculas
            // 
            this.lBoxPeliculas.FormattingEnabled = true;
            this.lBoxPeliculas.HorizontalScrollbar = true;
            this.lBoxPeliculas.Location = new System.Drawing.Point(20, 97);
            this.lBoxPeliculas.Name = "lBoxPeliculas";
            this.lBoxPeliculas.Size = new System.Drawing.Size(596, 303);
            this.lBoxPeliculas.TabIndex = 2;
            // 
            // PeliculasVistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lBoxPeliculas);
            this.Controls.Add(this.label1);
            this.Name = "PeliculasVistas";
            this.Size = new System.Drawing.Size(631, 431);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lBoxPeliculas;
    }
}
