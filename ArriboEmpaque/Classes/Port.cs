using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArriboEmpaque.Classes
{
    class Port
    {
        public int idPort { get; set; }
        public String portName { get; set; }

        private Database database = new Database();

        public DataTable getPorts()
        {
            String sql = "SELECT idPort, vPortName, bActive FROM tblPorts WHERE bActive = 1";

            SQLiteConnection con = database.openConnection();

            SQLiteDataReader reader = database.executeSQLReader(sql, con);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("idPort", typeof(Int32)));
            dt.Columns.Add(new DataColumn("vPortName", typeof(String)));
            dt.Columns.Add(new DataColumn("active", typeof(Boolean)));

            DataRow row = null;
            using (SQLiteDataReader r = reader)
            {
                while (r.Read())
                {
                    row = dt.NewRow();
                    row["idPort"] = Convert.ToInt32(r["idPort"].ToString());
                    row["vPortName"] = r["vPortName"].ToString();
                    row["active"] = Convert.ToInt32(r["bActive"].ToString()) != 0;
                    dt.Rows.Add(row);
                }
                r.Close();
            }
            con.Close();

            return dt;
        }

        public bool savePorts(int idPort, String portName, int active)
        {
            try
            {
                //int idPort = Convert.ToInt32(row["idPort"].ToString());
                //String portName = row["portName"].ToString();
                //int active = Convert.ToInt32(row["active"].ToString());

                String sqlString = "SELECT * FROM tblPorts WHERE idPort='" + idPort + "'";
                SQLiteConnection connection = database.openConnection();
                SQLiteDataReader reader = database.executeSQLReader(sqlString, connection);

                int rowCount = 0;
                using (SQLiteDataReader r = reader)
                {
                    while (r.Read())
                    {
                        rowCount++;
                    }
                    r.Close();
                }

                if (rowCount > 0)
                {
                    sqlString = "UPDATE tblPorts SET bActive='" + active + "' WHERE idPort='" + idPort + "'";
                    database.executeSQL(sqlString, connection);
                }
                else
                {
                    sqlString = "DELETE FROM tblPorts";

                    database.executeSQL(sqlString, connection);
                    sqlString = "INSERT INTO tblPorts(vPortName, bActive)VALUES(" +
                                    "'" + portName + "'," +
                                            active +
                                ")";


                    database.executeSQL(sqlString, connection);
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public String getSerialPort()
        {
            String port = "";
            SQLiteConnection con = database.openConnection();

            String sql = "SELECT idPort, vPortName, bActive FROM tblPorts WHERE bActive = 1";

            SQLiteDataReader read = database.executeSQLReader(sql, con);
            using (SQLiteDataReader r = read)
            {
                while (r.Read())
                {
                    port = r["vPortName"].ToString();
                }
                r.Close();
            }
            con.Close();

            return port;
        }


    }
}
