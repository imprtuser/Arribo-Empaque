namespace ArriboEmpaque
{
    partial class frmLogin
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
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pbLogin = new System.Windows.Forms.PictureBox();
            this.btnLangLogin = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerLogin = new System.ComponentModel.BackgroundWorker();
            this.pgLogin = new System.Windows.Forms.ProgressBar();
            this.lblLoginLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLangLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(165, 209);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(102, 19);
            this.lblPassword.TabIndex = 22;
            this.lblPassword.Text = "Contraseña";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(165, 146);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(71, 19);
            this.lblUser.TabIndex = 21;
            this.lblUser.Text = "Usuario";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(168, 230);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(296, 30);
            this.txtPassword.TabIndex = 20;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(168, 167);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(296, 30);
            this.txtUser.TabIndex = 19;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(240, 292);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(141, 46);
            this.btnLogin.TabIndex = 23;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pbLogin
            // 
            this.pbLogin.BackColor = System.Drawing.Color.Transparent;
            this.pbLogin.Image = global::ArriboEmpaque.Properties.Resources.logo;
            this.pbLogin.Location = new System.Drawing.Point(240, 29);
            this.pbLogin.Margin = new System.Windows.Forms.Padding(2);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new System.Drawing.Size(171, 97);
            this.pbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogin.TabIndex = 25;
            this.pbLogin.TabStop = false;
            // 
            // btnLangLogin
            // 
            this.btnLangLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLangLogin.Image = global::ArriboEmpaque.Properties.Resources.spanish_flag;
            this.btnLangLogin.Location = new System.Drawing.Point(558, 360);
            this.btnLangLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLangLogin.Name = "btnLangLogin";
            this.btnLangLogin.Size = new System.Drawing.Size(48, 45);
            this.btnLangLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLangLogin.TabIndex = 24;
            this.btnLangLogin.TabStop = false;
            this.btnLangLogin.Click += new System.EventHandler(this.btnLangLogin_Click);
            // 
            // backgroundWorkerLogin
            // 
            this.backgroundWorkerLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLogin_DoWork);
            // 
            // pgLogin
            // 
            this.pgLogin.Location = new System.Drawing.Point(202, 360);
            this.pgLogin.Name = "pgLogin";
            this.pgLogin.Size = new System.Drawing.Size(216, 23);
            this.pgLogin.TabIndex = 26;
            this.pgLogin.Visible = false;
            // 
            // lblLoginLoading
            // 
            this.lblLoginLoading.AutoSize = true;
            this.lblLoginLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginLoading.Location = new System.Drawing.Point(282, 390);
            this.lblLoginLoading.Name = "lblLoginLoading";
            this.lblLoginLoading.Size = new System.Drawing.Size(62, 13);
            this.lblLoginLoading.TabIndex = 27;
            this.lblLoginLoading.Text = "Cargando...";
            this.lblLoginLoading.Visible = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ArriboEmpaque.Properties.Resources.background_planning;
            this.ClientSize = new System.Drawing.Size(617, 417);
            this.Controls.Add(this.lblLoginLoading);
            this.Controls.Add(this.pgLogin);
            this.Controls.Add(this.pbLogin);
            this.Controls.Add(this.btnLangLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Name = "frmLogin";
            this.Text = "Inicio de Sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLangLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox btnLangLogin;
        private System.Windows.Forms.PictureBox pbLogin;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLogin;
        private System.Windows.Forms.ProgressBar pgLogin;
        private System.Windows.Forms.Label lblLoginLoading;
    }
}

