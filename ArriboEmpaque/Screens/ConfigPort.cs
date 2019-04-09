using ArriboEmpaque.Classes;
using arrivov2.helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArriboEmpaque.Screens
{
    public partial class ConfigPort : Form
    {
        Port port = new Port();
        public ConfigPort()
        {
            InitializeComponent();
        }

        private void ConfigPort_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            generatePortTable();
            fillGridViewPorts();
        }

        protected void generatePortTable()
        {
            Font font = new Font("Tahoma", 8, FontStyle.Bold);

            dgvPorts.AutoGenerateColumns = false;
            dgvPorts.AllowUserToAddRows = false;
            dgvPorts.AllowUserToDeleteRows = false;
            dgvPorts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPorts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPorts.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvPorts.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvPorts.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPorts.Font = font;
            dgvPorts.DefaultCellStyle.SelectionBackColor = (Color)System.Drawing.ColorTranslator.FromHtml("#78B266");
            dgvPorts.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPorts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPorts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPorts.AllowUserToResizeColumns = false;
            dgvPorts.AllowUserToAddRows = false;
            dgvPorts.AllowUserToDeleteRows = false;
            dgvPorts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn idPortCol = new DataGridViewTextBoxColumn();
            idPortCol.HeaderText = "idPort";
            idPortCol.DataPropertyName = "idPort";
            idPortCol.Name = "idPort";
            idPortCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idPortCol.ReadOnly = true;
            idPortCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idPortCol.Visible = false;
            dgvPorts.Columns.Add(idPortCol);
            dgvPorts.Columns[0].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn portCol = new DataGridViewTextBoxColumn();
            portCol.HeaderText = "Puerto";
            portCol.DataPropertyName = "portName";
            portCol.Name = "portName";
            portCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            portCol.ReadOnly = true;
            portCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPorts.Columns.Add(portCol);
            dgvPorts.Columns[1].HeaderCell.Style.Font = font;

            DataGridViewCheckBoxColumn activeCol = new DataGridViewCheckBoxColumn();
            activeCol.Width = 100;
            activeCol.HeaderText = "Activo";
            activeCol.DataPropertyName = "active";
            activeCol.Name = "active";
            activeCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            activeCol.ReadOnly = false;
            activeCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPorts.Columns.Add(activeCol);
            dgvPorts.Columns[2].HeaderCell.Style.Font = font;
        }

        protected void fillGridViewPorts()
        {
            try
            {
                DataTable dtPorts = new DataTable();
                DataTable dtPortsDB = port.getPorts();
                String[] ports = SerialPort.GetPortNames();

                dtPorts.Columns.Add(new DataColumn("idPort", typeof(Int32)));
                dtPorts.Columns.Add(new DataColumn("portName", typeof(String)));
                dtPorts.Columns.Add(new DataColumn("active", typeof(Boolean)));

                DataRow row = null;

                foreach (String port in ports)
                {
                    row = dtPorts.NewRow();
                    
                    if (dtPortsDB.Rows.Count > 0)
                    {
                        DataRow[] drPort = dtPortsDB.Select("vPortName = '" + port + "'");
                        if (drPort.Length>0)
                        {
                            row["idPort"] = Convert.ToInt32(drPort[0]["idPort"].ToString());
                            row["portName"] = drPort[0]["vPortName"].ToString();
                            row["active"] = drPort[0]["active"];
                        }
                        else
                        {
                            row["idPort"] = 0;
                            row["portName"] = port;
                            row["active"] = 0;
                        }
                    }
                    else
                    {
                        row["idPort"] = 0;
                        row["portName"] = port;
                        row["active"]= 0;
                    }

                    dtPorts.Rows.Add(row);
                }

                int rowIndex = 0;
                DataGridViewRow gridRow = null;
                foreach(DataRow dr in dtPorts.Rows)
                {
                    rowIndex = dgvPorts.Rows.Add();
                    gridRow = dgvPorts.Rows[rowIndex];
                    gridRow.Cells[0].Value = dr["idPort"].ToString();
                    gridRow.Cells[1].Value = dr["portName"].ToString();
                    gridRow.Cells[2].Value = dr["active"].ToString();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnSavePorts_Click(object sender, EventArgs e)
        {
            ResponseType response = new ResponseType();

            if (selectedPorts())
            {
                pbLoadingPorts.Show();
                pbLoadingPorts.Value = 50;
                lblLoadingPorts.Show();
                lblLoadingPorts.Text = "Guardando...";

                if (savePorts())
                {
                    response.responseType = 1;
                    response.message = "Puertos guardados correctamente";
                    MessageBox.Show(response.message, "Configuración puerto báscula", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbLoadingPorts.Value = 100;
                    pbLoadingPorts.Hide();
                    lblLoadingPorts.Hide();
                }
                else
                {
                    response.responseType = 2;
                    response.message = "No se pudieron guardar los puertos";
                    MessageBox.Show(response.message, "Configuración puerto báscula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pbLoadingPorts.Hide();
                    pbLoadingPorts.Value = 100;
                    lblLoadingPorts.Hide();
                }
            }
            else
            {
                MessageBox.Show("Debes de seleccionar un puerto serial por lo menos.", "Configuración puerto báscula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pbLoadingPorts.Hide();
                pbLoadingPorts.Value = 100;
                lblLoadingPorts.Hide();
            }
        }

        protected Boolean selectedPorts()
        {
            try
            {
                Boolean selectedPort = false;
                for(int x = 0; x < dgvPorts.RowCount; x++)
                {
                    if(Convert.ToBoolean(dgvPorts["active", x].Value))
                    {
                        selectedPort = true;
                    }
                }

                return selectedPort;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected Boolean savePorts()
        {
            try
            {
                Boolean flag = false;
                for (int i = 0; i < dgvPorts.RowCount; i++)
                {
                    int idPort = Convert.ToInt32(dgvPorts["idPort", i].Value.ToString());
                    String portName = dgvPorts["portName", i].Value.ToString();
                    int active = Convert.ToBoolean(dgvPorts["active", i].Value) ? 1 : 0;

                    if (active == 1)
                    {
                        flag = port.savePorts(idPort, portName, active);
                    }
                }
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
