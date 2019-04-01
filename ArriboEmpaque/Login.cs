using arrivov2.helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArriboEmpaque.Classes;
using ArriboEmpaque.CapturaArriboEmpaque;

namespace ArriboEmpaque
{
    public partial class frmLogin : Form
    {
        Boolean english = false;
        CultureInfo culture;
        ResourceManager resourceManager;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            pgLogin.Show();
            pgLogin.Value = 50;
            lblLoginLoading.Show();
            lblLoginLoading.Text = "Cargando...";
            backgroundWorkerLogin.RunWorkerAsync();
        }

        private Boolean Login(String vUser, String vPassword)
        {
            try
            {
                int response = 0;
                Boolean userLogged = false;
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" +  config.webMethodLogin;
                String postString = String.Format("user={0}&password={1}", vUser, vPassword);

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = postString.Length;

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                responseReader.Close();
                webRequest.GetResponse().Close();

                DataSet ds = (DataSet)JsonConvert.DeserializeObject(responseData, typeof(DataSet));
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    response = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
                    if(response == 1)
                    {
                        userLogged = true;
                    }
                }

                return userLogged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnLangLogin_Click(object sender, EventArgs e)
        {
            changeLanguage();
        }


        protected void changeLanguage()
        {
            try
            {
                english = !english;
                if (english)
                {
                    culture = CultureInfo.CreateSpecificCulture("en");
                    btnLangLogin.Image = ArriboEmpaque.Properties.Resources.english_flag;
                }
                else
                {
                    culture = CultureInfo.CreateSpecificCulture("es");
                    btnLangLogin.Image = ArriboEmpaque.Properties.Resources.spanish_flag;
                }

                loadTexts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void loadTexts()
        {

            lblUser.Text = resourceManager.GetString("usuario", culture);
            lblPassword.Text = resourceManager.GetString("contrasena", culture);
            btnLogin.Text = resourceManager.GetString("iniciar", culture);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            resourceManager = new ResourceManager("ArriboEmpaque.Language.Res", typeof(frmLogin).Assembly);
            backgroundWorkerLogin.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundLogin_RunWorkerCompleted);
            loadTexts();
        }

        private void backgroundWorkerLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            LoginResponse loginResponse = new LoginResponse();
            UserLogin oUser = new UserLogin();
            
            oUser.userName = txtUser.Text.ToString().Trim();
            oUser.password = txtPassword.Text.ToString().Trim();

        
                if (Login(oUser.userName, oUser.password))
                {
                    loginResponse.loginSuccess = true;
                }

                else
                {
                    loginResponse.loginSuccess = false;
                    loginResponse.message = "Usuario o contraseña incorrectos";
                }

                e.Result = loginResponse;

        }

        private void backgroundLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                LoginResponse response = (LoginResponse)e.Result;
                if (response.loginSuccess)
                {
                    pgLogin.Value = 100;
                    pgLogin.Hide();
                    lblLoginLoading.Hide();
                    this.Hide();
                    CapturaArriboEmpaque.frmCapturaArriboEmpaque cap = new CapturaArriboEmpaque.frmCapturaArriboEmpaque();
                    cap.Show();
                }
                else
                {
                    MessageBox.Show(response.message, "Inicio Sesión Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pgLogin.Value = 100;
                    pgLogin.Hide();
                    lblLoginLoading.Hide();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Arribo Empaque", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
