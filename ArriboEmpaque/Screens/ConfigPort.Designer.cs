namespace ArriboEmpaque.Screens
{
    partial class ConfigPort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigPort));
            this.dgvPorts = new System.Windows.Forms.DataGridView();
            this.btnSavePorts = new System.Windows.Forms.Button();
            this.pbLoadingPorts = new System.Windows.Forms.ProgressBar();
            this.lblLoadingPorts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPorts
            // 
            this.dgvPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorts.Location = new System.Drawing.Point(0, -1);
            this.dgvPorts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPorts.Name = "dgvPorts";
            this.dgvPorts.RowTemplate.Height = 28;
            this.dgvPorts.Size = new System.Drawing.Size(471, 161);
            this.dgvPorts.TabIndex = 1;
            // 
            // btnSavePorts
            // 
            this.btnSavePorts.Location = new System.Drawing.Point(126, 173);
            this.btnSavePorts.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePorts.Name = "btnSavePorts";
            this.btnSavePorts.Size = new System.Drawing.Size(229, 34);
            this.btnSavePorts.TabIndex = 7;
            this.btnSavePorts.Text = "Guardar";
            this.btnSavePorts.UseVisualStyleBackColor = true;
            this.btnSavePorts.Click += new System.EventHandler(this.btnSavePorts_Click);
            // 
            // pbLoadingPorts
            // 
            this.pbLoadingPorts.Location = new System.Drawing.Point(13, 248);
            this.pbLoadingPorts.Name = "pbLoadingPorts";
            this.pbLoadingPorts.Size = new System.Drawing.Size(445, 23);
            this.pbLoadingPorts.TabIndex = 8;
            this.pbLoadingPorts.Visible = false;
            // 
            // lblLoadingPorts
            // 
            this.lblLoadingPorts.AutoSize = true;
            this.lblLoadingPorts.Location = new System.Drawing.Point(13, 229);
            this.lblLoadingPorts.Name = "lblLoadingPorts";
            this.lblLoadingPorts.Size = new System.Drawing.Size(69, 13);
            this.lblLoadingPorts.TabIndex = 9;
            this.lblLoadingPorts.Text = "Guardando...";
            this.lblLoadingPorts.Visible = false;
            // 
            // ConfigPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 283);
            this.Controls.Add(this.lblLoadingPorts);
            this.Controls.Add(this.pbLoadingPorts);
            this.Controls.Add(this.btnSavePorts);
            this.Controls.Add(this.dgvPorts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigPort";
            this.Text = "Configuración puerto báscula";
            this.Load += new System.EventHandler(this.ConfigPort_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPorts;
        private System.Windows.Forms.Button btnSavePorts;
        private System.Windows.Forms.ProgressBar pbLoadingPorts;
        private System.Windows.Forms.Label lblLoadingPorts;
    }
}