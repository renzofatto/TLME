namespace TLMEGraficos
{
    partial class BusquedaAvanzada
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
            this.dgvPeliculas = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.chkListReparto = new System.Windows.Forms.CheckedListBox();
            this.lblReparto = new System.Windows.Forms.Label();
            this.radioBtnDirector = new System.Windows.Forms.RadioButton();
            this.radioBtnActor = new System.Windows.Forms.RadioButton();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPeliculas
            // 
            this.dgvPeliculas.AllowUserToAddRows = false;
            this.dgvPeliculas.AllowUserToDeleteRows = false;
            this.dgvPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPeliculas.Location = new System.Drawing.Point(128, 99);
            this.dgvPeliculas.Name = "dgvPeliculas";
            this.dgvPeliculas.ReadOnly = true;
            this.dgvPeliculas.RowHeadersWidth = 82;
            this.dgvPeliculas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPeliculas.Size = new System.Drawing.Size(481, 308);
            this.dgvPeliculas.TabIndex = 3;
            this.dgvPeliculas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeliculas_CellContentClick);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(130, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(379, 42);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Busqueda avanzada";
            // 
            // chkListReparto
            // 
            this.chkListReparto.FormattingEnabled = true;
            this.chkListReparto.HorizontalScrollbar = true;
            this.chkListReparto.Location = new System.Drawing.Point(14, 165);
            this.chkListReparto.Name = "chkListReparto";
            this.chkListReparto.Size = new System.Drawing.Size(106, 139);
            this.chkListReparto.TabIndex = 6;
            // 
            // lblReparto
            // 
            this.lblReparto.AutoSize = true;
            this.lblReparto.Location = new System.Drawing.Point(11, 147);
            this.lblReparto.Name = "lblReparto";
            this.lblReparto.Size = new System.Drawing.Size(48, 13);
            this.lblReparto.TabIndex = 7;
            this.lblReparto.Text = "Reparto:";
            // 
            // radioBtnDirector
            // 
            this.radioBtnDirector.AutoSize = true;
            this.radioBtnDirector.Location = new System.Drawing.Point(14, 99);
            this.radioBtnDirector.Name = "radioBtnDirector";
            this.radioBtnDirector.Size = new System.Drawing.Size(62, 17);
            this.radioBtnDirector.TabIndex = 8;
            this.radioBtnDirector.TabStop = true;
            this.radioBtnDirector.Text = "Director";
            this.radioBtnDirector.UseVisualStyleBackColor = true;
            this.radioBtnDirector.CheckedChanged += new System.EventHandler(this.radioBtnDirector_CheckedChanged);
            // 
            // radioBtnActor
            // 
            this.radioBtnActor.AutoSize = true;
            this.radioBtnActor.Location = new System.Drawing.Point(14, 122);
            this.radioBtnActor.Name = "radioBtnActor";
            this.radioBtnActor.Size = new System.Drawing.Size(50, 17);
            this.radioBtnActor.TabIndex = 9;
            this.radioBtnActor.TabStop = true;
            this.radioBtnActor.Text = "Actor";
            this.radioBtnActor.UseVisualStyleBackColor = true;
            this.radioBtnActor.CheckedChanged += new System.EventHandler(this.radioBtnActor_CheckedChanged);
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.Items.AddRange(new object[] {
            "Alfabeticamente",
            "Estreno"});
            this.cmbOrdenar.Location = new System.Drawing.Point(14, 328);
            this.cmbOrdenar.Margin = new System.Windows.Forms.Padding(2);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(106, 21);
            this.cmbOrdenar.TabIndex = 10;
            this.cmbOrdenar.Text = "Ordenar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Orden:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(14, 383);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // BusquedaAvanzada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOrdenar);
            this.Controls.Add(this.radioBtnActor);
            this.Controls.Add(this.radioBtnDirector);
            this.Controls.Add(this.lblReparto);
            this.Controls.Add(this.chkListReparto);
            this.Controls.Add(this.dgvPeliculas);
            this.Controls.Add(this.lblTitulo);
            this.Name = "BusquedaAvanzada";
            this.Size = new System.Drawing.Size(631, 431);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPeliculas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.CheckedListBox chkListReparto;
        private System.Windows.Forms.Label lblReparto;
        private System.Windows.Forms.RadioButton radioBtnDirector;
        private System.Windows.Forms.RadioButton radioBtnActor;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
    }
}
