using arrivov2.helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace ArriboEmpaque.Classes
{
    class Database
    {

        public bool checkDBExists()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = System.IO.Path.Combine(folder, config.dbLocalName + ".db");
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean createDatabase()
        {
            try
            {
                String folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                String path = System.IO.Path.Combine(folder, config.dbLocalName + ".db");

                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    SQLiteConnection.CreateFile(path);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                SQLiteConnection connection = openConnection();


                String tblPorts = "CREATE TABLE IF NOT EXISTS tblPorts(idPort INTEGER PRIMARY KEY AUTOINCREMENT, vPortName TEXT, bActive INTEGER)";

                executeSQL(tblPorts, connection);

                connection.Close();

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public SQLiteConnection openConnection()
        {
            String folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            String path = System.IO.Path.Combine(folder, config.dbLocalName + ".db");

            SQLiteConnection connection = new SQLiteConnection("Data Source=" + path + ";Version=3;");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public void executeSQL(String sql, SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        public SQLiteDataReader executeSQLReader(String sql, SQLiteConnection conn)
        {
            SQLiteCommand command = new SQLiteCommand(sql, conn);

            return command.ExecuteReader();
        }

    }
}
